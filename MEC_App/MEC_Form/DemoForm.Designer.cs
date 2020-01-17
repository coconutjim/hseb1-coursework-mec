namespace MEC_Form
{
    partial class DemoForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControlMEC = new OpenTK.GLControl();
            this.panelElements = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.buttonToTheEnd = new System.Windows.Forms.Button();
            this.buttonSimilarTaxis = new System.Windows.Forms.Button();
            this.buttonDissimilation = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBoxChoice = new System.Windows.Forms.GroupBox();
            this.radioButtonStep = new System.Windows.Forms.RadioButton();
            this.radioButtonSpeed = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelElements.SuspendLayout();
            this.groupBoxProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBoxChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControlMEC
            // 
            this.glControlMEC.BackColor = System.Drawing.Color.Black;
            this.glControlMEC.Location = new System.Drawing.Point(445, 79);
            this.glControlMEC.Name = "glControlMEC";
            this.glControlMEC.Size = new System.Drawing.Size(150, 137);
            this.glControlMEC.TabIndex = 3;
            this.glControlMEC.VSync = false;
            this.glControlMEC.Load += new System.EventHandler(this.glControlMEC_Load);
            this.glControlMEC.Paint += new System.Windows.Forms.PaintEventHandler(this.glControlMEC_Paint);
            this.glControlMEC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControlMEC_MouseDown);
            this.glControlMEC.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControlMEC_MouseMove);
            this.glControlMEC.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControlMEC_MouseWheel);
            // 
            // panelElements
            // 
            this.panelElements.BackColor = System.Drawing.SystemColors.Control;
            this.panelElements.Controls.Add(this.labelResult);
            this.panelElements.Controls.Add(this.groupBoxProcess);
            this.panelElements.Controls.Add(this.groupBoxChoice);
            this.panelElements.Location = new System.Drawing.Point(0, 0);
            this.panelElements.Name = "panelElements";
            this.panelElements.Size = new System.Drawing.Size(419, 366);
            this.panelElements.TabIndex = 4;
            this.panelElements.Resize += new System.EventHandler(this.panelElements_Resize);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(347, 154);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(40, 13);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "Точка:";
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.buttonToTheEnd);
            this.groupBoxProcess.Controls.Add(this.buttonSimilarTaxis);
            this.groupBoxProcess.Controls.Add(this.buttonDissimilation);
            this.groupBoxProcess.Controls.Add(this.labelSpeed);
            this.groupBoxProcess.Controls.Add(this.trackBarSpeed);
            this.groupBoxProcess.Controls.Add(this.buttonNext);
            this.groupBoxProcess.Location = new System.Drawing.Point(81, 170);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Size = new System.Drawing.Size(306, 179);
            this.groupBoxProcess.TabIndex = 8;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "Управление процессом алгоритма";
            // 
            // buttonToTheEnd
            // 
            this.buttonToTheEnd.BackColor = System.Drawing.SystemColors.Control;
            this.buttonToTheEnd.Location = new System.Drawing.Point(60, 150);
            this.buttonToTheEnd.Name = "buttonToTheEnd";
            this.buttonToTheEnd.Size = new System.Drawing.Size(195, 23);
            this.buttonToTheEnd.TabIndex = 10;
            this.buttonToTheEnd.Text = "Выполнить алгоритм до конца";
            this.buttonToTheEnd.UseVisualStyleBackColor = true;
            this.buttonToTheEnd.Click += new System.EventHandler(this.buttonToTheEnd_Click);
            // 
            // buttonSimilarTaxis
            // 
            this.buttonSimilarTaxis.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSimilarTaxis.Location = new System.Drawing.Point(15, 120);
            this.buttonSimilarTaxis.Name = "buttonSimilarTaxis";
            this.buttonSimilarTaxis.Size = new System.Drawing.Size(131, 25);
            this.buttonSimilarTaxis.TabIndex = 9;
            this.buttonSimilarTaxis.Text = "Только локальные состязания";
            this.buttonSimilarTaxis.UseVisualStyleBackColor = true;
            this.buttonSimilarTaxis.Click += new System.EventHandler(this.buttonSimilarTaxis_Click);
            // 
            // buttonDissimilation
            // 
            this.buttonDissimilation.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDissimilation.Location = new System.Drawing.Point(152, 120);
            this.buttonDissimilation.Name = "buttonDissimilation";
            this.buttonDissimilation.Size = new System.Drawing.Size(148, 25);
            this.buttonDissimilation.TabIndex = 8;
            this.buttonDissimilation.Text = "Только диссимиляция";
            this.buttonDissimilation.UseVisualStyleBackColor = true;
            this.buttonDissimilation.Click += new System.EventHandler(this.buttonDissimilation_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(122, 72);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(95, 13);
            this.labelSpeed.TabIndex = 7;
            this.labelSpeed.Text = "Скорость работы";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(90, 40);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(113, 45);
            this.trackBarSpeed.TabIndex = 6;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.Control;
            this.buttonNext.Location = new System.Drawing.Point(70, 91);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(133, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Следующая итерация";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // groupBoxChoice
            // 
            this.groupBoxChoice.Controls.Add(this.radioButtonStep);
            this.groupBoxChoice.Controls.Add(this.radioButtonSpeed);
            this.groupBoxChoice.Controls.Add(this.buttonStart);
            this.groupBoxChoice.Location = new System.Drawing.Point(141, 37);
            this.groupBoxChoice.Name = "groupBoxChoice";
            this.groupBoxChoice.Size = new System.Drawing.Size(181, 112);
            this.groupBoxChoice.TabIndex = 2;
            this.groupBoxChoice.TabStop = false;
            this.groupBoxChoice.Text = "Режим работы алгоритма";
            // 
            // radioButtonStep
            // 
            this.radioButtonStep.AutoSize = true;
            this.radioButtonStep.Location = new System.Drawing.Point(21, 43);
            this.radioButtonStep.Name = "radioButtonStep";
            this.radioButtonStep.Size = new System.Drawing.Size(121, 17);
            this.radioButtonStep.TabIndex = 1;
            this.radioButtonStep.TabStop = true;
            this.radioButtonStep.Text = "Пошаговый режим";
            this.radioButtonStep.UseVisualStyleBackColor = true;
            // 
            // radioButtonSpeed
            // 
            this.radioButtonSpeed.AutoSize = true;
            this.radioButtonSpeed.Location = new System.Drawing.Point(21, 19);
            this.radioButtonSpeed.Name = "radioButtonSpeed";
            this.radioButtonSpeed.Size = new System.Drawing.Size(109, 17);
            this.radioButtonSpeed.TabIndex = 0;
            this.radioButtonSpeed.TabStop = true;
            this.radioButtonSpeed.Text = "Обычный режим";
            this.radioButtonSpeed.UseVisualStyleBackColor = true;
            this.radioButtonSpeed.CheckedChanged += new System.EventHandler(this.radioButtonSpeed_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(45, 66);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(107, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Запуск";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 378);
            this.Controls.Add(this.panelElements);
            this.Controls.Add(this.glControlMEC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DemoForm";
            this.Text = "Визуализация";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DemoForm_FormClosed);
            this.Load += new System.EventHandler(this.DemoForm_Load);
            this.Shown += new System.EventHandler(this.DemoForm_Shown);
            this.panelElements.ResumeLayout(false);
            this.panelElements.PerformLayout();
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBoxChoice.ResumeLayout(false);
            this.groupBoxChoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControlMEC;
        private System.Windows.Forms.Panel panelElements;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.GroupBox groupBoxChoice;
        private System.Windows.Forms.RadioButton radioButtonStep;
        private System.Windows.Forms.RadioButton radioButtonSpeed;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Button buttonToTheEnd;
        private System.Windows.Forms.Button buttonSimilarTaxis;
        private System.Windows.Forms.Button buttonDissimilation;
        private System.Windows.Forms.Label labelResult;
    }
}