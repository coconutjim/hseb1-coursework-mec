namespace MEC_Form
{
    partial class FileForm
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
            this.checkBoxResult = new System.Windows.Forms.CheckBox();
            this.checkBoxIter = new System.Windows.Forms.CheckBox();
            this.checkBoxTime = new System.Windows.Forms.CheckBox();
            this.progressBarWriting = new System.Windows.Forms.ProgressBar();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonDo = new System.Windows.Forms.Button();
            this.checkBoxIfAMM = new System.Windows.Forms.CheckBox();
            this.checkBoxAMMOnly = new System.Windows.Forms.CheckBox();
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.labelNumb = new System.Windows.Forms.Label();
            this.labelAMM = new System.Windows.Forms.Label();
            this.labelParams = new System.Windows.Forms.Label();
            this.labelSession = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxResult
            // 
            this.checkBoxResult.AutoSize = true;
            this.checkBoxResult.Location = new System.Drawing.Point(39, 105);
            this.checkBoxResult.Name = "checkBoxResult";
            this.checkBoxResult.Size = new System.Drawing.Size(78, 17);
            this.checkBoxResult.TabIndex = 0;
            this.checkBoxResult.Text = "Результат";
            this.checkBoxResult.UseVisualStyleBackColor = true;
            // 
            // checkBoxIter
            // 
            this.checkBoxIter.AutoSize = true;
            this.checkBoxIter.Location = new System.Drawing.Point(39, 128);
            this.checkBoxIter.Name = "checkBoxIter";
            this.checkBoxIter.Size = new System.Drawing.Size(135, 17);
            this.checkBoxIter.TabIndex = 1;
            this.checkBoxIter.Text = "Количество итераций";
            this.checkBoxIter.UseVisualStyleBackColor = true;
            // 
            // checkBoxTime
            // 
            this.checkBoxTime.AutoSize = true;
            this.checkBoxTime.Location = new System.Drawing.Point(39, 151);
            this.checkBoxTime.Name = "checkBoxTime";
            this.checkBoxTime.Size = new System.Drawing.Size(126, 17);
            this.checkBoxTime.TabIndex = 2;
            this.checkBoxTime.Text = "Затраченное время";
            this.checkBoxTime.UseVisualStyleBackColor = true;
            // 
            // progressBarWriting
            // 
            this.progressBarWriting.Location = new System.Drawing.Point(14, 287);
            this.progressBarWriting.Name = "progressBarWriting";
            this.progressBarWriting.Size = new System.Drawing.Size(354, 23);
            this.progressBarWriting.TabIndex = 5;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(27, 32);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(131, 20);
            this.textBoxCount.TabIndex = 7;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(24, 16);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(134, 13);
            this.labelCount.TabIndex = 8;
            this.labelCount.Text = "Количество выполнений:";
            // 
            // buttonDo
            // 
            this.buttonDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDo.Location = new System.Drawing.Point(125, 253);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(128, 29);
            this.buttonDo.TabIndex = 10;
            this.buttonDo.Text = "Начать запись";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
            // 
            // checkBoxIfAMM
            // 
            this.checkBoxIfAMM.AutoSize = true;
            this.checkBoxIfAMM.Location = new System.Drawing.Point(12, 205);
            this.checkBoxIfAMM.Name = "checkBoxIfAMM";
            this.checkBoxIfAMM.Size = new System.Drawing.Size(354, 17);
            this.checkBoxIfAMM.TabIndex = 12;
            this.checkBoxIfAMM.Text = "Высчитать среднее и крайние значения каждого из параметров";
            this.checkBoxIfAMM.UseVisualStyleBackColor = true;
            this.checkBoxIfAMM.CheckedChanged += new System.EventHandler(this.checkBoxIfAMM_CheckedChanged);
            // 
            // checkBoxAMMOnly
            // 
            this.checkBoxAMMOnly.AutoSize = true;
            this.checkBoxAMMOnly.Location = new System.Drawing.Point(12, 228);
            this.checkBoxAMMOnly.Name = "checkBoxAMMOnly";
            this.checkBoxAMMOnly.Size = new System.Drawing.Size(213, 17);
            this.checkBoxAMMOnly.TabIndex = 13;
            this.checkBoxAMMOnly.Text = "Записать только итоговые значения";
            this.checkBoxAMMOnly.UseVisualStyleBackColor = true;
            this.checkBoxAMMOnly.CheckedChanged += new System.EventHandler(this.checkBoxAMMOnly_CheckedChanged);
            // 
            // comboBoxNumber
            // 
            this.comboBoxNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumber.FormattingEnabled = true;
            this.comboBoxNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboBoxNumber.Location = new System.Drawing.Point(230, 32);
            this.comboBoxNumber.Name = "comboBoxNumber";
            this.comboBoxNumber.Size = new System.Drawing.Size(46, 21);
            this.comboBoxNumber.TabIndex = 14;
            // 
            // labelNumb
            // 
            this.labelNumb.AutoSize = true;
            this.labelNumb.Location = new System.Drawing.Point(177, 16);
            this.labelNumb.Name = "labelNumb";
            this.labelNumb.Size = new System.Drawing.Size(160, 13);
            this.labelNumb.TabIndex = 15;
            this.labelNumb.Text = "Кол-во знаков после запятой:";
            // 
            // labelAMM
            // 
            this.labelAMM.AutoSize = true;
            this.labelAMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAMM.Location = new System.Drawing.Point(11, 184);
            this.labelAMM.Name = "labelAMM";
            this.labelAMM.Size = new System.Drawing.Size(159, 16);
            this.labelAMM.TabIndex = 16;
            this.labelAMM.Text = "Итоговые значения:";
            // 
            // labelParams
            // 
            this.labelParams.AutoSize = true;
            this.labelParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParams.Location = new System.Drawing.Point(36, 78);
            this.labelParams.Name = "labelParams";
            this.labelParams.Size = new System.Drawing.Size(183, 16);
            this.labelParams.TabIndex = 17;
            this.labelParams.Text = "Параметры для записи:";
            // 
            // labelSession
            // 
            this.labelSession.AutoSize = true;
            this.labelSession.Location = new System.Drawing.Point(17, 315);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(36, 13);
            this.labelSession.TabIndex = 18;
            this.labelSession.Text = "labelS";
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 346);
            this.Controls.Add(this.labelSession);
            this.Controls.Add(this.labelParams);
            this.Controls.Add(this.labelAMM);
            this.Controls.Add(this.labelNumb);
            this.Controls.Add(this.comboBoxNumber);
            this.Controls.Add(this.checkBoxAMMOnly);
            this.Controls.Add(this.checkBoxIfAMM);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.progressBarWriting);
            this.Controls.Add(this.checkBoxTime);
            this.Controls.Add(this.checkBoxIter);
            this.Controls.Add(this.checkBoxResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запись в файл";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxResult;
        private System.Windows.Forms.CheckBox checkBoxIter;
        private System.Windows.Forms.CheckBox checkBoxTime;
        private System.Windows.Forms.ProgressBar progressBarWriting;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.CheckBox checkBoxIfAMM;
        private System.Windows.Forms.CheckBox checkBoxAMMOnly;
        private System.Windows.Forms.ComboBox comboBoxNumber;
        private System.Windows.Forms.Label labelNumb;
        private System.Windows.Forms.Label labelAMM;
        private System.Windows.Forms.Label labelParams;
        private System.Windows.Forms.Label labelSession;
    }
}