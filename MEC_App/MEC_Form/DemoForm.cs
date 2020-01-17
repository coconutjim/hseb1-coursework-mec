using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using MEC_CL;

namespace MEC_Form
{
    public partial class DemoForm : Form
    {
        public DemoForm(Population pop,MainForm mf)
        {
            InitializeComponent();
            population = pop;
            trackBarSpeed.Maximum = 30;
            trackBarSpeed.Value = 15;
            speed = 0;
            mainform = mf;
            distance = Math.Abs(population.Xmax - population.Xmin);
            radioButtonStep.Checked = true;
            bwAlg.DoWork += bwAlg_DoWork;
            bwAlg.RunWorkerCompleted += bwAlg_RunWorkerCompleted;
            drawpoints = end = false;
            dX = 0;
            dddX = dddY = x = y = 0;
            mIntercept = 1;
            IfAlgWorks(false);
            radioButtonSpeed.Checked = true;
            loaded = ifWrong = false;
            ScaleGL = 1F;
        }
        #region поля и св-ва
        bool loaded;
        int widthGL;
        int heightGL;
        float scaleGL;
        double[][] sx, tx;
        MainForm mainform;
        Billboard[][] sy, ty;
        Billboard[] gl;
        double oldS, newS;
        int dX;
        double x, y;
        double dddX;
        double dddY;
        int distance;
        double m;
        int mIntercept;
        BackgroundWorker bwAlg = new BackgroundWorker();
        static Population population;
        bool drawpoints;
        bool end;
        int speed;
        bool ifWrong;
        float ScaleGL
        {
            get { return scaleGL; }
            set
            {
                if (value < 0.3F || value > 10F)
                {
                    if (value < 0.3F) scaleGL = 0.3F;
                    if (value > 10F) scaleGL = 10F;
                }
                else scaleGL = value;
            }
        }
        #endregion
        #region график
        void GraphicPainting()
        {
            if (distance % 2 != 0) distance++;
            m = 2 * widthGL / distance;
            if (distance > 100) mIntercept = 10;
            GL.NewList(1, ListMode.Compile);
            double dist;
            GL.Color3(Color.Black);
            GL.Begin(BeginMode.Lines);
            dX = -((population.Xmax + population.Xmin) / 2);
            GL.Vertex2(-widthGL, 0);
            GL.Vertex2(widthGL, 0);
            for (int i = 0; i < widthGL; i += mIntercept)
            {
                if (i * m > widthGL) break;
                GL.Vertex2(i * m, -2);
                GL.Vertex2(i * m, 2);
                GL.Vertex2(-i * m, -2);
                GL.Vertex2(-i * m, 2);
            }
            if (!(population.Xmax > 0 && population.Xmin < 0))
            {
                if (population.Xmin > 0)
                {
                    dist = population.Xmin;
                    GL.Vertex2(-widthGL - dist * m, 0);
                    GL.Vertex2(-widthGL, 0);
                    for (int i = 1; i < dist; i += mIntercept)
                    {
                        
                        GL.Vertex2(-widthGL - i * m, -2);
                        GL.Vertex2(-widthGL - i * m, 2);
                    }
                }
                else
                {
                    dist = -population.Xmax;
                    GL.Vertex2(widthGL, 0);
                    GL.Vertex2(widthGL + dist * m, 0);
                    for (int i = 1; i < dist; i += mIntercept)
                    {
                        GL.Vertex2(widthGL + i * m, -2);
                        GL.Vertex2(widthGL + i * m, 2);
                    }
                }

            }
            GL.Vertex2(dX * m, -heightGL);
            GL.Vertex2(dX * m, heightGL);
            for (int i = 0; i < heightGL; i += mIntercept)
            {
                if (i * m > heightGL) break;
                GL.Vertex2(-2 + dX * m, i * m);
                GL.Vertex2(2 + dX * m, i * m);
                GL.Vertex2(-2 + dX * m, -i * m);
                GL.Vertex2(2 + dX * m, -i * m);
            }
            GL.End();
            GL.Begin(BeginMode.LineStrip);
            GL.Color3(Color.Red);
            int n;
            double alpha, dx, x, y;
            alpha = 2.915;
            n = 100;
            dx = alpha / (n - 1);
            x = population.Xmin;
            double ymax = population.FAM.Func(x);
            double ymin = ymax;
            for (double i = -50000; i <= n; i++)
            {
                y = population.FAM.Func(x);
                if (double.IsNaN(y) ||double.IsInfinity(y))
                    ifWrong = true;
                else
                    GL.Vertex2((x + dX) * m, y * m);
                if (y > ymax) ymax = y;
                if (y < ymin) ymin = y;
                x = x + dx;
                if (x > population.Xmax) break;
            }
            GL.End();
            GL.Color3(Color.Black);
            GL.Begin(BeginMode.Lines);
            dist = (int)(ymax - Math.Abs((population.Xmax - population.Xmin) / 2)) + 1;
            if (dist > 1)
            {
                GL.Vertex2(dX * m, heightGL);
                GL.Vertex2(dX * m, heightGL + dist * m);
                for (int i = 1; i < dist; i += mIntercept)
                {
                    GL.Vertex2(-2 + dX * m, heightGL + i * m);
                    GL.Vertex2(2 + dX * m, heightGL + i * m);
                }
            }
            dist = (int)(ymin + Math.Abs((population.Xmax - population.Xmin) / 2)) - 1;
            if (dist < -1)
            {
                dist = Math.Abs(dist);
                GL.Vertex2(dX * m, -heightGL);
                GL.Vertex2(dX * m, -heightGL - dist * m);
                for (int i = 1; i < dist; i += mIntercept)
                {
                    GL.Vertex2(-2 + dX * m, -heightGL - i * m);
                    GL.Vertex2(2 + dX * m, -heightGL - i * m);
                }
            }
            GL.End();
            GL.EndList();
        }
        #endregion
        #region ГЛконтрол
        private void glControlMEC_Load(object sender, EventArgs e)
        {
            glControlMEC.Width =  this.Height - 10;//подработать
            glControlMEC.Left = this.Width - glControlMEC.Width - 10;
            glControlMEC.Height = this.Height - 20;
            glControlMEC.Top = 3;
            panelElements.Height = this.Height;
            panelElements.Width = this.Width - 10 - glControlMEC.Width;
            loaded = true;
            GL.ClearColor(Color.SkyBlue);
            widthGL = glControlMEC.Width;
            heightGL = glControlMEC.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-widthGL, widthGL, -heightGL, heightGL, -1, 1);
            GL.Viewport(0, 0, widthGL, heightGL);
            GraphicPainting();
        }



        private void glControlMEC_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Scale(ScaleGL, ScaleGL, 1);
            GL.Translate(dddX * m, dddY * m, 0);
            GL.CallList(1);
            if (drawpoints)
            {
                GL.PointSize(3);
                GL.Color3(Color.Blue);
                GL.Begin(BeginMode.Points);
                for (int i = 0; i < sx.Length; i++)
                    for (int j = 0; j < sx[i].Length; j++)
                    {
                        GL.Vertex2((sx[i][sy[i][j].Index] + dX) * m, sy[i][j].Score * m);
                    }
                GL.End();
                GL.Color3(Color.Green);
                GL.Begin(BeginMode.Points);
                for (int i = 0; i < tx.Length; i++)
                    for (int j = 0; j < tx[i].Length; j++)
                        GL.Vertex2((tx[i][ty[i][j].Index] + dX) * m, ty[i][j].Score * m);
                GL.End();
                if (end)
                {
                    GL.PointSize(5);
                    GL.Color3(Color.Yellow);
                    GL.Begin(BeginMode.Points);
                    double arg = population.FindArg(gl, sy, sx);
                    double y = population.FAM.Func(arg);
                    GL.Vertex2((arg + dX) * m, y * m);
                    labelResult.Text = string.Format("Точка: ( {0:F3} ; {1:F3} )", arg, y);
                    GL.End();
                }
            }
            GL.Finish();
            glControlMEC.SwapBuffers();
        }
        private void glControlMEC_MouseMove(object sender, MouseEventArgs e)
        {
            if (!loaded)
                return;
            if (e.Button == MouseButtons.Left)
            {
                dddY += (y - e.Y) / (m / 2 * ScaleGL);
                dddX -= (x - e.X) / (m / 2 * ScaleGL);
                glControlMEC.Invalidate();
                x = e.X;
                y = e.Y;
            }

        }

        private void glControlMEC_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        private void glControlMEC_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) ScaleGL += 0.1F;
            else ScaleGL -= 0.1F;
            glControlMEC.Invalidate();
        }
        #endregion
        #region алгоритм
        void IfAlgWorks(bool ifWorks)
        {
            buttonNext.Enabled = buttonSimilarTaxis.Enabled = buttonDissimilation.Enabled = buttonToTheEnd.Enabled = ifWorks;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            end = false;
            labelResult.Text = "Точка: ";
            if (radioButtonSpeed.Checked)
            {
                buttonStart.Enabled = false;
                groupBoxChoice.Enabled = false;
                bwAlg.RunWorkerAsync();
            }
            else
            {
                try
                {
                    IfAlgWorks(true);
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
                    sx = SG;
                    sy = SGLBB;
                    tx = TG;
                    ty = TGLBB;
                    gl = GLBB;
                    drawpoints = true;
                    oldS = population.FindMax(GLBB);
                    newS = 0;
                    glControlMEC.Invalidate();
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
        }
        void bwAlg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
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
                sx = SG;
                sy = SGLBB;
                tx = TG;
                ty = TGLBB;
                drawpoints = true;
                glControlMEC.Invalidate();
                Billboard[] GLBB = population.FormGlobalBillboard(SGLBB, TGLBB);
                double oldScore = population.FindMax(GLBB), newScore = 0;
                int count = 1;
                do
                {
                    if (count > 1)
                        oldScore = newScore;
                    population.SimilarTaxis(GLBB, SG, SGLBB, TG, TGLBB);
                    population.Dissimilation(GLBB, SG, SGLBB, TG, TGLBB);
                    newScore = population.FindMax(GLBB);//GLBB
                    count++;
                    sx = SG;
                    sy = SGLBB;
                    tx = TG;
                    ty = TGLBB;
                    glControlMEC.Invalidate();
                    System.Threading.Thread.Sleep(50 + 30 * (30 - speed));
                } while (newScore > oldScore);
                gl = GLBB;
                end = true;
                glControlMEC.Invalidate();
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
            groupBoxChoice.Enabled = true;
            buttonStart.Enabled = true;
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                oldS = newS;
                population.SimilarTaxis(gl, sx, sy, tx, ty);
                population.Dissimilation(gl, sx, sy, tx, ty);
                newS = population.FindMax(gl);
                if (!(newS > oldS))
                {
                    end = true;
                    IfAlgWorks(false);
                }
                glControlMEC.Invalidate();
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

        private void buttonSimilarTaxis_Click(object sender, EventArgs e)
        {
            try
            {
                oldS = newS;
                population.SimilarTaxis(gl, sx, sy, tx, ty);
                newS = population.FindMax(gl);
                if (!(newS > oldS))
                {
                    end = true;
                    IfAlgWorks(false);
                }
                glControlMEC.Invalidate();
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

        private void buttonDissimilation_Click(object sender, EventArgs e)
        {
            try
            {
                oldS = newS;
                population.Dissimilation(gl, sx, sy, tx, ty);
                newS = population.FindMax(gl);
                glControlMEC.Invalidate();
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

        private void buttonToTheEnd_Click(object sender, EventArgs e)
        {
            try
            {
                do
                {
                    oldS = newS;
                    population.SimilarTaxis(gl, sx, sy, tx, ty);
                    population.Dissimilation(gl, sx, sy, tx, ty);
                    newS = population.FindMax(gl);
                } while (newS > oldS);
                end = true;
                IfAlgWorks(false);
                glControlMEC.Invalidate();
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
        #endregion
        private void radioButtonSpeed_CheckedChanged(object sender, EventArgs e)
        {
            bool b = radioButtonSpeed.Checked;
            buttonToTheEnd.Visible = buttonSimilarTaxis.Visible = buttonDissimilation.Visible = buttonNext.Visible = !b;
            labelSpeed.Visible = trackBarSpeed.Visible = b;
        }

        private void DemoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainform.buttonDemoE();
        }

        private void panelElements_Resize(object sender, EventArgs e)
        {
            int def = 0;
            switch (ConfigForm.Definition)
            {
                case 0:
                    {
                        def = 100;
                        break;
                    }
                case 1:
                    {
                        def = 10;
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        def = 1;
                        break;
                    }
            }
            //
            groupBoxChoice.Width = def * panelElements.Width / (def + 1);
            groupBoxChoice.Height = def * groupBoxChoice.Width / (def + 1);
            groupBoxProcess.Width = (def + 1) * panelElements.Width / (def + 2);
            groupBoxProcess.Height = (def + 1) * groupBoxProcess.Width / (def + 2);
            groupBoxChoice.Top = (panelElements.Height - groupBoxProcess.Height - groupBoxChoice.Height) / 2;
            groupBoxChoice.Left = panelElements.Width / 2 - groupBoxChoice.Width / 2;
            groupBoxProcess.Top = (panelElements.Height - groupBoxProcess.Height - groupBoxChoice.Height) / 2 + groupBoxChoice.Height;
            groupBoxProcess.Left = panelElements.Width / 2 - groupBoxProcess.Width / 2;
            //
            radioButtonSpeed.Top = groupBoxChoice.Height / 4;
            radioButtonStep.Top = 2 * groupBoxChoice.Height / 4;
            buttonStart.Top = 3 * groupBoxChoice.Height / 4;
            buttonStart.Width = groupBoxChoice.Width / 3;
            buttonStart.Height = groupBoxChoice.Height / 5;
            radioButtonStep.Width = radioButtonSpeed.Width = 2 * groupBoxChoice.Width / 3;
            labelResult.Font = groupBoxProcess.Font = groupBoxChoice.Font = new Font("Microsoft Sans Serif", (int)groupBoxChoice.Width / 25, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            radioButtonStep.Left = radioButtonSpeed.Left = groupBoxChoice.Width / 2 - radioButtonSpeed.Width / 2;
            buttonStart.Left = groupBoxChoice.Width / 2 - buttonStart.Width / 2;
            //
            trackBarSpeed.Width = groupBoxProcess.Width / 2;
            trackBarSpeed.Top = groupBoxProcess.Height / 10;
            labelSpeed.Top = groupBoxProcess.Height / 5;
            trackBarSpeed.Left = groupBoxProcess.Width / 4;
            labelSpeed.Left = groupBoxProcess.Width / 2 - labelSpeed.Width / 2;
            buttonSimilarTaxis.Height = buttonDissimilation.Height = buttonToTheEnd.Height = buttonNext.Height = groupBoxProcess.Height / 7;
            buttonSimilarTaxis.Width = buttonDissimilation.Width = buttonToTheEnd.Width = buttonNext.Width = 5 * groupBoxProcess.Width / 6;
            buttonNext.Left = buttonSimilarTaxis.Left = buttonToTheEnd.Left = buttonDissimilation.Left = groupBoxProcess.Width / 2 - 5 * groupBoxProcess.Width / 12;
            buttonNext.Top = groupBoxProcess.Height / 5;
            buttonSimilarTaxis.Top = 2 * groupBoxProcess.Height / 5;
            buttonDissimilation.Top = 3 * groupBoxProcess.Height / 5;
            buttonToTheEnd.Top = 4 * groupBoxProcess.Height / 5;
            //
            labelResult.Top = labelResult.Left = 0;
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            speed = trackBarSpeed.Value;
        }

        private void DemoForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.Top = this.Left = 0;
        }

        private void DemoForm_Shown(object sender, EventArgs e)
        {
            if (ifWrong)
            {
                MessageBox.Show("В функции был найден разрыв. Проверьте область определения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

    }
}
