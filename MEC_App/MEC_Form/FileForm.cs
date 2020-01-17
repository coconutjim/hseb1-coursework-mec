using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MEC_CL;

namespace MEC_Form
{
    public partial class FileForm : Form
    {
        public FileForm(Population pop, MainForm mf, string func)
        {
            InitializeComponent();
            population = pop;
            function = func;
            mainform = mf;
            labelSession.Text = "Текущий сеанс: " + func+"\n"+population.Xmin.ToString() + "." + population.Xmax.ToString() + "." +
                population.SGC.ToString() + "." + population.TGC.ToString() + "." + population.IC.ToString() + "." + population.FAM.Omega.ToString() + ".";
            checkBoxIfAMM.Checked = checkBoxIter.Checked = checkBoxResult.Checked = checkBoxTime.Checked = true;
            bwAlg.DoWork += bwAlg_DoWork;
            bwAlg.WorkerReportsProgress = true;
            bwAlg.RunWorkerCompleted += bwAlg_RunWorkerCompleted;
            textBoxCount.Text = "100000";
            comboBoxNumber.SelectedIndex = 5;
        }
        string function;
        string accurancy;
        int iterCount;
        bool ifSuccess;
        static MainForm mainform;
        StreamWriter writeFile;
        Population population;
        BackgroundWorker bwAlg = new BackgroundWorker();
        string fileName;

        private void buttonDo_Click(object sender, EventArgs e)
        {
            if (!checkBoxResult.Checked && !checkBoxIter.Checked && !checkBoxTime.Checked)
            {
                MessageBox.Show("Выберите хотя бы один из параметров для записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(textBoxCount.Text, out iterCount) || iterCount < 1 || iterCount > 1000000000)
            {
                MessageBox.Show("Неверное значение количества выполнений! Значение количества выполнений должно быть целым числом от 1 до 1 000 000 000.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //
            progressBarWriting.Minimum = 0;
            progressBarWriting.Maximum = iterCount;
            accurancy = "F" + comboBoxNumber.SelectedIndex;
            SaveFileDialog saveFileDialogData = new SaveFileDialog();
            saveFileDialogData.Filter = "text files (.txt)|*txt";
            saveFileDialogData.Title = "Сохранить данные в файл";
            DialogResult resres = saveFileDialogData.ShowDialog();
            if (resres != DialogResult.OK) return;
            fileName = saveFileDialogData.FileName;
            string[] ar = fileName.Split('.');
            if (ar[ar.Length - 1] == "txt")
            {
                buttonDo.Enabled = false;
                bwAlg.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Файл неверного формата!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void bwAlg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ifSuccess = true;
                bool add = true;
                DialogResult res = MessageBox.Show("Перезаписать файл?",
                        "Сохранение или добавление данных", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes) add = false;
                if (res == DialogResult.Cancel) return;
                //
                writeFile = new StreamWriter(fileName, add);
                string s = "------------------------------------------------------";
                writeFile.WriteLine(s); writeFile.WriteLine(s); writeFile.WriteLine(s);
                writeFile.WriteLine("Функция: {0}", function);
                writeFile.WriteLine("Минимальное значение аргумента: {0}", population.Xmin);
                writeFile.WriteLine("Максимальное значение аргумента: {0}", population.Xmax);
                writeFile.WriteLine("Количество лидирующих групп: {0}", population.SGC);
                writeFile.WriteLine("Количество отстающих групп: {0}", population.TGC);
                writeFile.WriteLine("Количество агентов в каждой группе: {0}", population.IC);
                writeFile.WriteLine("Омега: {0}", population.FAM.Omega);
                writeFile.WriteLine("Количество выполнений алгоритма: {0}", iterCount);
                writeFile.WriteLine(s);
                //
                int count;
                Stopwatch time = Stopwatch.StartNew();
                double rAve, rMin, rMax;
                int iAve, iMin, iMax;
                rAve = rMax = rMin = iAve = iMax = iMin = 0;
                TimeSpan tAve, tMin, tMax;
                tAve = tMax = tMin = new TimeSpan();
                for (int k = 0; k < iterCount; k++)
                {
                    double[][] SG = new double[population.SGC][];
                    double[][] TG = new double[population.TGC][];
                    Billboard[][] SGLBB = new Billboard[SG.Length][];
                    Billboard[][] TGLBB = new Billboard[TG.Length][];
                    time.Reset();
                    time.Start();
                    for (int i = 0; i < SG.Length; i++)
                    {
                        SG[i] = population.Initialization();
                        SGLBB[i] = population.FormLocalBillboard(SG[i]);
                    }
                    for (int i = 0; i < TG.Length; i++)
                    {
                        TG[i] = population.Initialization();
                        TGLBB[i] = population.FormLocalBillboard(TG[i]);
                    }
                    Billboard[] GLBB = population.FormGlobalBillboard(SGLBB, TGLBB);
                    double oldScore = population.FindMax(GLBB), newScore = 0;
                    count = 1;
                    do
                    {
                        if (count > 1)
                            oldScore = newScore;
                        population.SimilarTaxis(GLBB, SG, SGLBB, TG, TGLBB);
                        population.Dissimilation(GLBB, SG, SGLBB, TG, TGLBB);
                        newScore = population.FindMax(GLBB);
                        count++;
                    } while (newScore > oldScore);
                    time.Stop();
                    if (checkBoxIfAMM.Checked)
                    {
                        if (k == 0)
                        {
                            iMax = iMin = count;
                            rMax = rMin = newScore;
                            tMax = tMin = time.Elapsed;
                        }
                        else
                        {
                            if (count > iMax) iMax = count;
                            if (count < iMin) iMin = count;
                            if (newScore > rMax) rMax = newScore;
                            if (newScore < rMin) rMin = newScore;
                            if (time.Elapsed > tMax) tMax = time.Elapsed;
                            if (time.Elapsed < tMin) tMin = time.Elapsed;
                        }
                        iAve += count;
                        rAve += newScore;
                        tAve += time.Elapsed;
                    }
                    if (!checkBoxAMMOnly.Checked)
                    {
                        if (checkBoxIter.Checked) writeFile.WriteLine("Кол-во итераций: {0}", count);
                        if (checkBoxResult.Checked) writeFile.WriteLine("Максимум функции: {0}", newScore.ToString(accurancy));
                        if (checkBoxTime.Checked) writeFile.WriteLine("Затраченное время: {0}", time.Elapsed);
                        writeFile.WriteLine(s);
                    }
                    progressBarWriting.Invoke(new del(() => progressBarWriting.Value++));
                }
                if (checkBoxIfAMM.Checked)
                {
                    writeFile.WriteLine(s);
                    writeFile.WriteLine("Итог(попыток - {0}):", iterCount);
                    writeFile.WriteLine(s);
                    if (checkBoxIter.Checked)
                    {
                        writeFile.WriteLine("Среднее кол-во итераций: {0}", (iAve / (double)iterCount).ToString(accurancy));
                        writeFile.WriteLine("Минимальное кол-во итераций: {0}", iMin);
                        writeFile.WriteLine("Максимальное кол-во итераций: {0}", iMax);
                        writeFile.WriteLine(s);
                    }
                    if (checkBoxResult.Checked)
                    {
                        writeFile.WriteLine("Средний максимум функции: {0}", (rAve / (double)iterCount).ToString(accurancy));
                        writeFile.WriteLine("Наименьший максимум функции: {0}", rMin.ToString(accurancy));
                        writeFile.WriteLine("Наибольший максимум функции: {0}", rMax.ToString(accurancy));
                        writeFile.WriteLine(s);
                    }
                    if (checkBoxTime.Checked)
                    {
                        writeFile.WriteLine("Среднее затраченное время: {0}", new TimeSpan((long)(tAve.Ticks / (double)iterCount)));
                        writeFile.WriteLine("Минимальное затраченное время: {0}", tMin);
                        writeFile.WriteLine("Максимальное затраченное время: {0}", tMax);
                        writeFile.WriteLine(s);
                    }
                    writeFile.WriteLine(s); writeFile.WriteLine(s);
                }
                writeFile.Flush();
                writeFile.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при записи в файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ifSuccess = false;
                return;
            }
        }
        void bwAlg_RunWorkerCompleted(object sender, EventArgs e)
        {
            buttonDo.Enabled = true;
            progressBarWriting.Value = progressBarWriting.Minimum;
            if (ifSuccess)
            {
                DialogResult res = MessageBox.Show("Операция выполнена успешно.Выйти?", "Готово", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes) this.Close();
                else this.Activate();
            }
        }
        private void checkBoxAMMOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAMMOnly.Checked) if (!checkBoxIfAMM.Checked) checkBoxIfAMM.Checked = true;
        }
        private void checkBoxIfAMM_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxIfAMM.Checked) if (checkBoxAMMOnly.Checked) checkBoxAMMOnly.Checked = false;
        }

        private void FileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainform.buttonFileE();
        }
    }
    delegate void del();
}
