using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MEC_CL;
using OpenTK.Graphics.OpenGL;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace MEC_Form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBoxArn.SelectedIndex = 0;
            labelInfo.Text = "";
            comboBoxFunc.SelectedIndex = 0;
            bwAlg.DoWork += bwAlg_DoWork;
            bwAlg.RunWorkerCompleted += bwAlg_RunWorkerCompleted;
            ConfigForm.Definition = 0;
            textBoxIC.Text = "10";
            textBoxTGC.Text = "10";
            textBoxSGC.Text = "10";
            textBoxMinX1.Text = "-10";
            textBoxMaxX1.Text = "10";
            textBoxMinX2.Text = "-10";
            textBoxMaxX2.Text = "10";
            textBoxMinX3.Text = "-10";
            textBoxMaxX3.Text = "10";
        }
        static int arn;
        static double score;
        static int iterCount;
        static TimeSpan timeAlg;
        static Population population = new Population();
        BackgroundWorker bwAlg = new BackgroundWorker();
        static bool ifDemoLoaded = false;
        static bool ifFileLoaded = false;
        #region errors
        void ErrorData(TextBox textbox)
        {
            textbox.BackColor = Color.Yellow;
            textbox.Focus();
            textbox.SelectAll();
        }
        string CheckAndInput()
        {
            string message = "";
            try
            {
                population.IC = uint.Parse(textBoxIC.Text);
                if (textBoxIC.BackColor != Color.White) textBoxIC.BackColor = Color.White;
            }
            catch
            {
                ErrorData(textBoxIC);
                message = message.Insert(0, "\n-Ошибка в значении количества людей в группах. Значением должно быть ненулевое натуральное число.");
            }
            try
            {
                population.TGC = uint.Parse(textBoxTGC.Text);
                if (textBoxTGC.BackColor != Color.White) textBoxTGC.BackColor = Color.White;
            }
            catch
            {
                ErrorData(textBoxTGC);
                message = message.Insert(0, "\n-Ошибка в значении количества отстающих групп. Значением должно быть ненулевое натуральное число.");
            }
            try
            {
                population.SGC = uint.Parse(textBoxSGC.Text);
                if (textBoxSGC.BackColor != Color.White) textBoxSGC.BackColor = Color.White;
            }
            catch
            {
                ErrorData(textBoxSGC);
                message = message.Insert(0, "\n-Ошибка в значении количества лидирующих групп. Значением должно быть ненулевое натуральное число.");
            }
            if (arn == 2)
            {
                try
                {
                    population.Xmin = int.Parse(textBoxMinX1.Text);
                    population.Xmax = int.Parse(textBoxMaxX1.Text);
                    if (textBoxMinX1.BackColor != Color.White) textBoxMinX1.BackColor = textBoxMaxX1.BackColor = Color.White;
                }
                catch
                {
                    ErrorData(textBoxMaxX1);
                    ErrorData(textBoxMinX1);
                    message = message.Insert(0, "\n-Ошибка в значении интервала аргумента.");
                }
            }
            else
            {
                population.Dimension = arn;
                population.Xmins = new int[arn - 1];
                population.Xmaxs = new int[arn - 1];
                if (arn == 4)
                {
                    try
                    {
                        population.Xmins[2] = int.Parse(textBoxMinX3.Text);
                        population.Xmaxs[2] = int.Parse(textBoxMaxX3.Text);
                        if (textBoxMinX3.BackColor != Color.White) textBoxMinX3.BackColor = textBoxMaxX3.BackColor = Color.White;
                    }
                    catch
                    {
                        tabControlArgs.SelectedIndex = 2;
                        ErrorData(textBoxMaxX3);
                        ErrorData(textBoxMinX3);
                        message = message.Insert(0, "\n-Ошибка в значении интервала третьего аргумента.");
                    }
                }
                try
                {
                    population.Xmins[1] = int.Parse(textBoxMinX2.Text);
                    population.Xmaxs[1] = int.Parse(textBoxMaxX2.Text);
                    if (textBoxMinX2.BackColor != Color.White) textBoxMinX2.BackColor = textBoxMaxX2.BackColor = Color.White;
                }
                catch
                {
                    tabControlArgs.SelectedIndex = 1;
                    ErrorData(textBoxMaxX2);
                    ErrorData(textBoxMinX2);
                    message = message.Insert(0, "\n-Ошибка в значении интервала второго аргумента.");
                }
                try
                {
                    population.Xmins[0] = int.Parse(textBoxMinX1.Text);
                    population.Xmaxs[0] = int.Parse(textBoxMaxX1.Text);
                    if (textBoxMinX1.BackColor != Color.White) textBoxMinX1.BackColor = textBoxMaxX1.BackColor = Color.White;
                }
                catch
                {
                    tabControlArgs.SelectedIndex = 0;
                    ErrorData(textBoxMaxX1);
                    ErrorData(textBoxMinX1);
                    message = message.Insert(0, "\n-Ошибка в значении интервала первого аргумента.");
                }
            }
            if (message=="")
            {
                if (!FunctionsAndMath.OmegaChanged)
                    if (arn == 2)
                        population.FAM.Omega = (double)(population.Xmax - population.Xmin) / 10.0;
                    else
                        population.FAM.Omega = (double)(population.Xmaxs[0] - population.Xmins[0]) / 10.0;
                else population.FAM.Omega = FunctionsAndMath.NewOmega;
            }
            return message;
        }
        #endregion
        private void buttonStart_Click(object sender, EventArgs e)
        {
            string message = CheckAndInput();
            if (message=="")
            {
                buttonDemonstration.Enabled = buttonStart.Enabled = buttonFuncParse.Enabled = toolStripMenuItemConfig.Enabled =
                toolStripMenuItemFile.Enabled = comboBoxArn.Enabled = comboBoxFunc.Enabled = false;
                labelInfo.Text = "";
                labelResult.Text = "Максимум функции: ";
                bwAlg.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("При вводе были допущены следующие ошибки:" + message, "Ошибка в входных данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            textBoxSGC.Focus();
        }
        internal void buttonDemoE()
        {
            ifDemoLoaded = !ifDemoLoaded;
            buttonDemonstration.Enabled = !buttonDemonstration.Enabled;
        }
        internal void buttonFileE()
        {
            ifFileLoaded = !ifFileLoaded;
            toolStripMenuItemFile.Enabled = !toolStripMenuItemFile.Enabled;
        }
        private void buttonDemonstration_Click(object sender, EventArgs e)
        {
            string message = CheckAndInput();
            if (message=="")
            {
                if (population.Xmax - population.Xmin > 1000)
                {
                    MessageBox.Show("Слишком большой интервал аргумента для нормальной прорисовки графика. Интервал должен быть не больше 1000." , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (population.Xmax == population.Xmin)
                {
                    MessageBox.Show("В визуализации нет смысла.","Нулевой интервал",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                buttonDemoE();
                DemoForm form1 = new DemoForm(population, this);
                form1.Show();
            }
            else
            {
                MessageBox.Show("При вводе были допущены следующие ошибки:" + message, "Ошибка в входных данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void comboBoxFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (arn)
            {
                case 2:
                    {
                        population.FAM.Func = FunctionsAndMath.ListFunc[comboBoxFunc.SelectedItem.ToString()];
                        break;
                    }
                case 3:
                    {
                        population.FAM.NDfunc = FunctionsAndMath.ListFunc3D[comboBoxFunc.SelectedItem.ToString()];
                        break;
                    }
                case 4:
                    {
                        population.FAM.NDfunc = FunctionsAndMath.ListFunc4D[comboBoxFunc.SelectedItem.ToString()];
                        break;
                    }
            }
        }

        private void toolStripMenuItemFile_Click(object sender, EventArgs e)
        {
            string message = CheckAndInput();
            if (message=="")
            {
                buttonFileE();
                FileForm form1 = new FileForm(population, this,comboBoxFunc.SelectedItem.ToString());
                form1.Show();
            }
            else
            {
                MessageBox.Show("При вводе были допущены следующие ошибки:" + message, "Ошибка в входных данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void toolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            ConfigForm form1 = new ConfigForm();
            form1.ShowDialog();
        }

        private void buttonFuncParse_Click(object sender, EventArgs e)
        {
            string begin = @"using System;
namespace MyNamespace
{
    public delegate double Del(double x);
    public static class LambdaCreator 
    {
        public static Del Create()
        {
            return (x)=>";
           
            string begin3D = @"using System;
namespace MyNamespace
{
    public delegate double Del(params double[] x);
    public static class LambdaCreator 
    {
        public static Del Create()
        {
            return (x)=>{double x1=x[0],x2=x[1]; return ";
            string begin4D = @"using System;
namespace MyNamespace
{
    public delegate double Del(params double[] x);
    public static class LambdaCreator 
    {
        public static Del Create()
        {
            return (x)=>{double x1=x[0],x2=x[1],x3=x[2]; return ";
            string end = @";
        }
    }
}";
            string endND=@";};
        }
    }
}";
            string middle = textBoxFunction.Text;
            middle = middle.Replace("sin", "Math.Sin");
            middle = middle.Replace("cos", "Math.Cos");
            middle = middle.Replace("tg", "Math.Tan");
            middle = middle.Replace("arcsin", "Math.Asin");
            middle = middle.Replace("arccos", "Math.Acos");
            middle = middle.Replace("arctg", "Math.Atan");
            middle = middle.Replace("sqrt", "Math.Sqrt");
            middle = middle.Replace("arctg2", "Math.Atan2");
            middle = middle.Replace("pow", "Math.Pow");
            middle = middle.Replace("abs", "Math.Abs");
            middle = middle.Replace("log", "Math.Log");
            middle = middle.Replace("pi", "Math.PI");
            middle = middle.Replace("e", "Math.E");
            try
            {
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateInMemory = true;
                parameters.ReferencedAssemblies.Add("System.dll");
                CompilerResults results;
                if (arn == 2)
                    results = provider.CompileAssemblyFromSource(parameters, begin + middle + end);
                else
                    if (arn == 3)
                        results = provider.CompileAssemblyFromSource(parameters, begin3D + middle + endND);
                    else
                        results = provider.CompileAssemblyFromSource(parameters, begin4D + middle + endND);
                var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
                var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
                population.FAM.ParsedOne = (method.Invoke(null, null) as Delegate);
                if (arn == 2)
                {
                    population.FAM.Func = population.FAM.CallFunc;
                    double a = population.FAM.Func(0.1);
                    FunctionsAndMath.ListFunc.Add("y = " + textBoxFunction.Text, population.FAM.CallFunc);
                }
                else
                {
                    population.FAM.NDfunc = population.FAM.CallFuncND;
                    if (arn == 3)
                    {
                        double a = population.FAM.NDfunc(0.1, 0.1);
                        FunctionsAndMath.ListFunc3D.Add("y = " + textBoxFunction.Text, population.FAM.CallFuncND);
                    }
                    else
                    {
                        double a = population.FAM.NDfunc(0.1, 0.1, 0.1);
                        FunctionsAndMath.ListFunc4D.Add("y = " + textBoxFunction.Text, population.FAM.CallFuncND);
                    }
                }
                comboBoxFunc.Items.Add("y = " + textBoxFunction.Text);
                comboBoxFunc.SelectedIndex = comboBoxFunc.Items.Count - 1;
                textBoxFunction.Clear();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Такая функция уже есть в списке!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch
            {
                MessageBox.Show("Ошибка компиляции! Проверьте синтаксис.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void comboBoxArn_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFunc.Items.Clear();
            arn = comboBoxArn.SelectedIndex + 2;
            if (arn == 2)
            {
                labelArgs.Text = "Введите минимальное и максимальное значения аргумента:";
                if (!ifFileLoaded) toolStripMenuItemFile.Enabled = true;
                if (!ifDemoLoaded) buttonDemonstration.Enabled = true;
                tabPageX2.Parent = tabPageX3.Parent = null;
                tabPageX1.Text = "x";
                comboBoxFunc.Items.Clear();
                foreach (var a in  FunctionsAndMath.ListFunc)
                    comboBoxFunc.Items.Add(a.Key);
                comboBoxFunc.SelectedIndex = 0;
            }
            else
            {
                labelArgs.Text = "Введите минимальное и максимальное значения аргументов:";
                toolStripMenuItemFile.Enabled = buttonDemonstration.Enabled = false;
                tabPageX1.Text = "x1";
                tabPageX2.Parent = tabControlArgs;
                tabPageX3.Parent = null;
                if (arn == 4)
                {
                    tabPageX3.Parent = tabControlArgs;
                    foreach (var a in FunctionsAndMath.ListFunc4D)
                        comboBoxFunc.Items.Add(a.Key);
                }
                else
                    foreach (var a in FunctionsAndMath.ListFunc3D)
                        comboBoxFunc.Items.Add(a.Key);
                comboBoxFunc.SelectedIndex = 0;
            }
        }
        void bwAlg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int count;
                double newScore = 0;
                Stopwatch time = new Stopwatch();
                if (arn == 2)
                {
                    time.Start();
                    double[][] SG = new double[population.SGC][];
                    double[][] TG = new double[population.TGC][];
                    Billboard[][] SGLBB = new Billboard[SG.Length][];
                    Billboard[][] TGLBB = new Billboard[TG.Length][];
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
                    double oldScore = population.FindMax(GLBB);
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
                }
                else
                {
                    time.Start();
                    double[][][] SG = new double[population.SGC][][];
                    double[][][] TG = new double[population.TGC][][];
                    Billboard[][] SGLBB = new Billboard[SG.Length][];
                    Billboard[][] TGLBB = new Billboard[TG.Length][];
                    for (int i = 0; i < SG.Length; i++)
                    {
                        SG[i] = population.InitializationND();
                        SGLBB[i] = population.FormLocalBillboard(SG[i]);
                    }
                    for (int i = 0; i < TG.Length; i++)
                    {
                        TG[i] = population.InitializationND();
                        TGLBB[i] = population.FormLocalBillboard(TG[i]);
                    }
                    Billboard[] GLBB = population.FormGlobalBillboard(SGLBB, TGLBB);
                    double oldScore = population.FindMax(GLBB);
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
                }
                score = newScore;
                iterCount = count;
                timeAlg = time.Elapsed;
                //throw new Exception();
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Популяция слишком велика. Произошло переполнение памяти.", "Память переполнена", MessageBoxButtons.OK);//, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void bwAlg_RunWorkerCompleted(object sender, EventArgs e)
        {
            if (arn == 2)
                buttonDemonstration.Enabled = toolStripMenuItemFile.Enabled = true;
            buttonStart.Enabled = buttonFuncParse.Enabled = toolStripMenuItemConfig.Enabled = 
                comboBoxArn.Enabled = comboBoxFunc.Enabled = true;
            if (double.IsNaN(score) || double.IsInfinity(score))
            {
                MessageBox.Show("В функции был найден разрыв. Проверьте область определения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelInfo.Text = "";
                labelResult.Text = "Максимум функции: ";
            }
            else
            {
                labelResult.Text = "Максимум функции: " + score.ToString("F5");
                labelInfo.Text = "Количество итераций: " + iterCount.ToString() + "\nЗатраченное время: " + timeAlg.ToString();
            }
            textBoxSGC.Focus();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа оптимизации, инспирированная эволюцией разума."+
            "\nАвтор: Осипов Лев Игоревич, студент 1 курса НИУ ВШЭ."+
            "\nНаучный руководитель: Авдошин Сергей Михайлович, кандидат технических наук."+
            "\n2013","Информация",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
