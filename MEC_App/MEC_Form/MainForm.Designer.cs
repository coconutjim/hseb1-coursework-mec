namespace MEC_Form
{
    partial class MainForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelPopData = new System.Windows.Forms.Label();
            this.labelSGC = new System.Windows.Forms.Label();
            this.labelTGC = new System.Windows.Forms.Label();
            this.labelIC = new System.Windows.Forms.Label();
            this.textBoxSGC = new System.Windows.Forms.TextBox();
            this.textBoxIC = new System.Windows.Forms.TextBox();
            this.textBoxTGC = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelInfoVis = new System.Windows.Forms.Label();
            this.buttonDemonstration = new System.Windows.Forms.Button();
            this.comboBoxFunc = new System.Windows.Forms.ComboBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonFuncParse = new System.Windows.Forms.Button();
            this.labelFunc = new System.Windows.Forms.Label();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.textBoxMaxX3 = new System.Windows.Forms.TextBox();
            this.textBoxMinX3 = new System.Windows.Forms.TextBox();
            this.textBoxMaxX2 = new System.Windows.Forms.TextBox();
            this.textBoxMinX2 = new System.Windows.Forms.TextBox();
            this.textBoxMaxX1 = new System.Windows.Forms.TextBox();
            this.textBoxMinX1 = new System.Windows.Forms.TextBox();
            this.comboBoxArn = new System.Windows.Forms.ComboBox();
            this.labelArn = new System.Windows.Forms.Label();
            this.labely = new System.Windows.Forms.Label();
            this.tabControlArgs = new System.Windows.Forms.TabControl();
            this.tabPageX1 = new System.Windows.Forms.TabPage();
            this.tabPageX2 = new System.Windows.Forms.TabPage();
            this.tabPageX3 = new System.Windows.Forms.TabPage();
            this.labelArgs = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            this.tabControlArgs.SuspendLayout();
            this.tabPageX1.SuspendLayout();
            this.tabPageX2.SuspendLayout();
            this.tabPageX3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(84, 324);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(99, 28);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Запуск";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelPopData
            // 
            this.labelPopData.AutoSize = true;
            this.labelPopData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPopData.Location = new System.Drawing.Point(58, 182);
            this.labelPopData.Name = "labelPopData";
            this.labelPopData.Size = new System.Drawing.Size(259, 25);
            this.labelPopData.TabIndex = 5;
            this.labelPopData.Text = "Популяционные данные:";
            // 
            // labelSGC
            // 
            this.labelSGC.AutoSize = true;
            this.labelSGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSGC.Location = new System.Drawing.Point(77, 214);
            this.labelSGC.Name = "labelSGC";
            this.labelSGC.Size = new System.Drawing.Size(214, 16);
            this.labelSGC.TabIndex = 6;
            this.labelSGC.Text = "Количество лидирующих групп:";
            // 
            // labelTGC
            // 
            this.labelTGC.AutoSize = true;
            this.labelTGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTGC.Location = new System.Drawing.Point(88, 251);
            this.labelTGC.Name = "labelTGC";
            this.labelTGC.Size = new System.Drawing.Size(203, 16);
            this.labelTGC.TabIndex = 7;
            this.labelTGC.Text = "Количество отстающих групп:";
            // 
            // labelIC
            // 
            this.labelIC.AutoSize = true;
            this.labelIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIC.Location = new System.Drawing.Point(16, 282);
            this.labelIC.Name = "labelIC";
            this.labelIC.Size = new System.Drawing.Size(275, 16);
            this.labelIC.TabIndex = 8;
            this.labelIC.Text = "Количество индивидов в каждой группе:";
            // 
            // textBoxSGC
            // 
            this.textBoxSGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSGC.Location = new System.Drawing.Point(322, 211);
            this.textBoxSGC.Name = "textBoxSGC";
            this.textBoxSGC.Size = new System.Drawing.Size(63, 22);
            this.textBoxSGC.TabIndex = 9;
            // 
            // textBoxIC
            // 
            this.textBoxIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIC.Location = new System.Drawing.Point(322, 282);
            this.textBoxIC.Name = "textBoxIC";
            this.textBoxIC.Size = new System.Drawing.Size(63, 22);
            this.textBoxIC.TabIndex = 11;
            // 
            // textBoxTGC
            // 
            this.textBoxTGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTGC.Location = new System.Drawing.Point(322, 245);
            this.textBoxTGC.Name = "textBoxTGC";
            this.textBoxTGC.Size = new System.Drawing.Size(63, 22);
            this.textBoxTGC.TabIndex = 10;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.Location = new System.Drawing.Point(7, 355);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(216, 25);
            this.labelResult.TabIndex = 12;
            this.labelResult.Text = "Максимум функции:";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(182, 385);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(19, 13);
            this.labelInfo.TabIndex = 18;
            this.labelInfo.Text = "дд";
            // 
            // labelInfoVis
            // 
            this.labelInfoVis.AutoSize = true;
            this.labelInfoVis.Location = new System.Drawing.Point(9, 385);
            this.labelInfoVis.Name = "labelInfoVis";
            this.labelInfoVis.Size = new System.Drawing.Size(166, 13);
            this.labelInfoVis.TabIndex = 19;
            this.labelInfoVis.Text = "Дополнительная информация: ";
            // 
            // buttonDemonstration
            // 
            this.buttonDemonstration.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDemonstration.Location = new System.Drawing.Point(225, 324);
            this.buttonDemonstration.Name = "buttonDemonstration";
            this.buttonDemonstration.Size = new System.Drawing.Size(160, 27);
            this.buttonDemonstration.TabIndex = 23;
            this.buttonDemonstration.Text = "Запуск с визуализацией";
            this.buttonDemonstration.UseVisualStyleBackColor = true;
            this.buttonDemonstration.Click += new System.EventHandler(this.buttonDemonstration_Click);
            // 
            // comboBoxFunc
            // 
            this.comboBoxFunc.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunc.FormattingEnabled = true;
            this.comboBoxFunc.Items.AddRange(new object[] {
            "y = x",
            "y = - 0,1*x^2 + 10"});
            this.comboBoxFunc.Location = new System.Drawing.Point(119, 60);
            this.comboBoxFunc.Name = "comboBoxFunc";
            this.comboBoxFunc.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFunc.TabIndex = 24;
            this.comboBoxFunc.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunc_SelectedIndexChanged);
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemConfig,
            this.toolStripMenuItemAbout});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(447, 24);
            this.menuStripMain.TabIndex = 25;
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(99, 20);
            this.toolStripMenuItemFile.Text = "Запись в файл";
            this.toolStripMenuItemFile.Click += new System.EventHandler(this.toolStripMenuItemFile_Click);
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            this.toolStripMenuItemConfig.Size = new System.Drawing.Size(79, 20);
            this.toolStripMenuItemConfig.Text = "Настройки";
            this.toolStripMenuItemConfig.Click += new System.EventHandler(this.toolStripMenuItemConfig_Click);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemAbout.Text = "О программе";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // buttonFuncParse
            // 
            this.buttonFuncParse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonFuncParse.Location = new System.Drawing.Point(280, 60);
            this.buttonFuncParse.Name = "buttonFuncParse";
            this.buttonFuncParse.Size = new System.Drawing.Size(145, 23);
            this.buttonFuncParse.TabIndex = 26;
            this.buttonFuncParse.Text = "Ввести новую функцию";
            this.buttonFuncParse.UseVisualStyleBackColor = true;
            this.buttonFuncParse.Click += new System.EventHandler(this.buttonFuncParse_Click);
            // 
            // labelFunc
            // 
            this.labelFunc.AutoSize = true;
            this.labelFunc.Location = new System.Drawing.Point(151, 35);
            this.labelFunc.Name = "labelFunc";
            this.labelFunc.Size = new System.Drawing.Size(56, 13);
            this.labelFunc.TabIndex = 27;
            this.labelFunc.Text = "Функция:";
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(281, 32);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(145, 20);
            this.textBoxFunction.TabIndex = 28;
            // 
            // textBoxMaxX3
            // 
            this.textBoxMaxX3.Location = new System.Drawing.Point(90, 14);
            this.textBoxMaxX3.Name = "textBoxMaxX3";
            this.textBoxMaxX3.Size = new System.Drawing.Size(67, 22);
            this.textBoxMaxX3.TabIndex = 13;
            // 
            // textBoxMinX3
            // 
            this.textBoxMinX3.Location = new System.Drawing.Point(10, 14);
            this.textBoxMinX3.Name = "textBoxMinX3";
            this.textBoxMinX3.Size = new System.Drawing.Size(67, 22);
            this.textBoxMinX3.TabIndex = 12;
            // 
            // textBoxMaxX2
            // 
            this.textBoxMaxX2.Location = new System.Drawing.Point(90, 14);
            this.textBoxMaxX2.Name = "textBoxMaxX2";
            this.textBoxMaxX2.Size = new System.Drawing.Size(67, 22);
            this.textBoxMaxX2.TabIndex = 10;
            // 
            // textBoxMinX2
            // 
            this.textBoxMinX2.Location = new System.Drawing.Point(10, 14);
            this.textBoxMinX2.Name = "textBoxMinX2";
            this.textBoxMinX2.Size = new System.Drawing.Size(67, 22);
            this.textBoxMinX2.TabIndex = 9;
            // 
            // textBoxMaxX1
            // 
            this.textBoxMaxX1.Location = new System.Drawing.Point(90, 14);
            this.textBoxMaxX1.Name = "textBoxMaxX1";
            this.textBoxMaxX1.Size = new System.Drawing.Size(67, 22);
            this.textBoxMaxX1.TabIndex = 7;
            // 
            // textBoxMinX1
            // 
            this.textBoxMinX1.Location = new System.Drawing.Point(10, 14);
            this.textBoxMinX1.Name = "textBoxMinX1";
            this.textBoxMinX1.Size = new System.Drawing.Size(67, 22);
            this.textBoxMinX1.TabIndex = 6;
            // 
            // comboBoxArn
            // 
            this.comboBoxArn.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxArn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArn.FormattingEnabled = true;
            this.comboBoxArn.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxArn.Location = new System.Drawing.Point(23, 60);
            this.comboBoxArn.Name = "comboBoxArn";
            this.comboBoxArn.Size = new System.Drawing.Size(38, 21);
            this.comboBoxArn.TabIndex = 30;
            this.comboBoxArn.SelectedIndexChanged += new System.EventHandler(this.comboBoxArn_SelectedIndexChanged);
            // 
            // labelArn
            // 
            this.labelArn.Location = new System.Drawing.Point(9, 28);
            this.labelArn.Name = "labelArn";
            this.labelArn.Size = new System.Drawing.Size(75, 29);
            this.labelArn.TabIndex = 33;
            this.labelArn.Text = "Количество переменных:";
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(254, 32);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(21, 13);
            this.labely.TabIndex = 34;
            this.labely.Text = "y =";
            // 
            // tabControlArgs
            // 
            this.tabControlArgs.Controls.Add(this.tabPageX1);
            this.tabControlArgs.Controls.Add(this.tabPageX2);
            this.tabControlArgs.Controls.Add(this.tabPageX3);
            this.tabControlArgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlArgs.Location = new System.Drawing.Point(131, 106);
            this.tabControlArgs.Name = "tabControlArgs";
            this.tabControlArgs.SelectedIndex = 0;
            this.tabControlArgs.Size = new System.Drawing.Size(175, 73);
            this.tabControlArgs.TabIndex = 35;
            // 
            // tabPageX1
            // 
            this.tabPageX1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageX1.Controls.Add(this.textBoxMinX1);
            this.tabPageX1.Controls.Add(this.textBoxMaxX1);
            this.tabPageX1.Location = new System.Drawing.Point(4, 25);
            this.tabPageX1.Name = "tabPageX1";
            this.tabPageX1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageX1.Size = new System.Drawing.Size(167, 44);
            this.tabPageX1.TabIndex = 0;
            this.tabPageX1.Text = "x1";
            // 
            // tabPageX2
            // 
            this.tabPageX2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageX2.Controls.Add(this.textBoxMaxX2);
            this.tabPageX2.Controls.Add(this.textBoxMinX2);
            this.tabPageX2.Location = new System.Drawing.Point(4, 25);
            this.tabPageX2.Name = "tabPageX2";
            this.tabPageX2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageX2.Size = new System.Drawing.Size(167, 44);
            this.tabPageX2.TabIndex = 1;
            this.tabPageX2.Text = "x2";
            // 
            // tabPageX3
            // 
            this.tabPageX3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageX3.Controls.Add(this.textBoxMaxX3);
            this.tabPageX3.Controls.Add(this.textBoxMinX3);
            this.tabPageX3.Location = new System.Drawing.Point(4, 25);
            this.tabPageX3.Name = "tabPageX3";
            this.tabPageX3.Size = new System.Drawing.Size(167, 44);
            this.tabPageX3.TabIndex = 2;
            this.tabPageX3.Text = "x3";
            // 
            // labelArgs
            // 
            this.labelArgs.AutoSize = true;
            this.labelArgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArgs.Location = new System.Drawing.Point(17, 88);
            this.labelArgs.Name = "labelArgs";
            this.labelArgs.Size = new System.Drawing.Size(64, 16);
            this.labelArgs.TabIndex = 36;
            this.labelArgs.Text = "Введите";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(447, 415);
            this.Controls.Add(this.labelArgs);
            this.Controls.Add(this.tabControlArgs);
            this.Controls.Add(this.labely);
            this.Controls.Add(this.labelArn);
            this.Controls.Add(this.comboBoxArn);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.labelFunc);
            this.Controls.Add(this.buttonFuncParse);
            this.Controls.Add(this.comboBoxFunc);
            this.Controls.Add(this.buttonDemonstration);
            this.Controls.Add(this.labelInfoVis);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.textBoxTGC);
            this.Controls.Add(this.textBoxIC);
            this.Controls.Add(this.textBoxSGC);
            this.Controls.Add(this.labelIC);
            this.Controls.Add(this.labelTGC);
            this.Controls.Add(this.labelSGC);
            this.Controls.Add(this.labelPopData);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mind Evolutionary Computation";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlArgs.ResumeLayout(false);
            this.tabPageX1.ResumeLayout(false);
            this.tabPageX1.PerformLayout();
            this.tabPageX2.ResumeLayout(false);
            this.tabPageX2.PerformLayout();
            this.tabPageX3.ResumeLayout(false);
            this.tabPageX3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelPopData;
        private System.Windows.Forms.Label labelSGC;
        private System.Windows.Forms.Label labelTGC;
        private System.Windows.Forms.Label labelIC;
        private System.Windows.Forms.TextBox textBoxSGC;
        private System.Windows.Forms.TextBox textBoxIC;
        private System.Windows.Forms.TextBox textBoxTGC;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelInfoVis;
        private System.Windows.Forms.Button buttonDemonstration;
        private System.Windows.Forms.ComboBox comboBoxFunc;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConfig;
        private System.Windows.Forms.Button buttonFuncParse;
        private System.Windows.Forms.Label labelFunc;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.ComboBox comboBoxArn;
        private System.Windows.Forms.TextBox textBoxMaxX3;
        private System.Windows.Forms.TextBox textBoxMinX3;
        private System.Windows.Forms.TextBox textBoxMaxX2;
        private System.Windows.Forms.TextBox textBoxMinX2;
        private System.Windows.Forms.TextBox textBoxMaxX1;
        private System.Windows.Forms.TextBox textBoxMinX1;
        private System.Windows.Forms.Label labelArn;
        private System.Windows.Forms.Label labely;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.TabControl tabControlArgs;
        private System.Windows.Forms.TabPage tabPageX1;
        private System.Windows.Forms.TabPage tabPageX2;
        private System.Windows.Forms.TabPage tabPageX3;
        private System.Windows.Forms.Label labelArgs;
    }
}

