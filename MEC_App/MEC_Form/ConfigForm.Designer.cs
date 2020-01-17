namespace MEC_Form
{
    partial class ConfigForm
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.textBoxOmega = new System.Windows.Forms.TextBox();
            this.labelOmega = new System.Windows.Forms.Label();
            this.labelGraphOpt = new System.Windows.Forms.Label();
            this.comboBoxDefinition = new System.Windows.Forms.ComboBox();
            this.labelDef = new System.Windows.Forms.Label();
            this.labelAlg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(185, 27);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(115, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Применить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(185, 56);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(115, 23);
            this.buttonDefault.TabIndex = 1;
            this.buttonDefault.Text = "По умолчанию";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // textBoxOmega
            // 
            this.textBoxOmega.Location = new System.Drawing.Point(61, 44);
            this.textBoxOmega.Name = "textBoxOmega";
            this.textBoxOmega.Size = new System.Drawing.Size(100, 20);
            this.textBoxOmega.TabIndex = 2;
            this.textBoxOmega.TextChanged += new System.EventHandler(this.textBoxOmega_TextChanged);
            // 
            // labelOmega
            // 
            this.labelOmega.AutoSize = true;
            this.labelOmega.Location = new System.Drawing.Point(12, 47);
            this.labelOmega.Name = "labelOmega";
            this.labelOmega.Size = new System.Drawing.Size(43, 13);
            this.labelOmega.TabIndex = 3;
            this.labelOmega.Text = "Омега:";
            // 
            // labelGraphOpt
            // 
            this.labelGraphOpt.AutoSize = true;
            this.labelGraphOpt.Location = new System.Drawing.Point(76, 94);
            this.labelGraphOpt.Name = "labelGraphOpt";
            this.labelGraphOpt.Size = new System.Drawing.Size(164, 13);
            this.labelGraphOpt.TabIndex = 4;
            this.labelGraphOpt.Text = "Графические характеристики: ";
            // 
            // comboBoxDefinition
            // 
            this.comboBoxDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDefinition.FormattingEnabled = true;
            this.comboBoxDefinition.Items.AddRange(new object[] {
            "800 x 600",
            "1024 x 768",
            "1280 x 600",
            "1280 x 720",
            "1360 x 768"});
            this.comboBoxDefinition.Location = new System.Drawing.Point(135, 123);
            this.comboBoxDefinition.Name = "comboBoxDefinition";
            this.comboBoxDefinition.Size = new System.Drawing.Size(89, 21);
            this.comboBoxDefinition.TabIndex = 5;
            this.comboBoxDefinition.SelectedIndexChanged += new System.EventHandler(this.comboBoxDefinition_SelectedIndexChanged);
            // 
            // labelDef
            // 
            this.labelDef.AutoSize = true;
            this.labelDef.Location = new System.Drawing.Point(43, 126);
            this.labelDef.Name = "labelDef";
            this.labelDef.Size = new System.Drawing.Size(73, 13);
            this.labelDef.TabIndex = 6;
            this.labelDef.Text = "Разрешение:";
            // 
            // labelAlg
            // 
            this.labelAlg.AutoSize = true;
            this.labelAlg.Location = new System.Drawing.Point(121, 7);
            this.labelAlg.Name = "labelAlg";
            this.labelAlg.Size = new System.Drawing.Size(73, 13);
            this.labelAlg.TabIndex = 7;
            this.labelAlg.Text = "К алгоритму:";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 191);
            this.Controls.Add(this.labelAlg);
            this.Controls.Add(this.labelDef);
            this.Controls.Add(this.comboBoxDefinition);
            this.Controls.Add(this.labelGraphOpt);
            this.Controls.Add(this.labelOmega);
            this.Controls.Add(this.textBoxOmega);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.buttonAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.TextBox textBoxOmega;
        private System.Windows.Forms.Label labelOmega;
        private System.Windows.Forms.Label labelGraphOpt;
        private System.Windows.Forms.ComboBox comboBoxDefinition;
        private System.Windows.Forms.Label labelDef;
        private System.Windows.Forms.Label labelAlg;
    }
}