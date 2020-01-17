using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MEC_CL;

namespace MEC_Form
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            if (FunctionsAndMath.OmegaChanged)
                textBoxOmega.Text = FunctionsAndMath.NewOmega.ToString();
            else
                buttonDefault.Enabled = false;
            textBoxOmega.Focus();
            comboBoxDefinition.SelectedIndex = Definition;
        }
        public static int Definition { get; set; }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                FunctionsAndMath.NewOmega = double.Parse(textBoxOmega.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение параметра!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBoxOmega.Text = "";
            FunctionsAndMath.OmegaChanged = true;
            buttonDefault.Enabled = true;
            buttonAccept.Enabled = false;
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            textBoxOmega.Text = "";
            FunctionsAndMath.OmegaChanged = false;
            buttonDefault.Enabled = false;
        }

        private void comboBoxDefinition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Definition = comboBoxDefinition.SelectedIndex;
        }

        private void textBoxOmega_TextChanged(object sender, EventArgs e)
        {
            buttonAccept.Enabled = true;
        }
    }
}
