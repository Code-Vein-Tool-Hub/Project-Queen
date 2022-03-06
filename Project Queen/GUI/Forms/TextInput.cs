using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Queen.GUI.Forms
{
    public partial class TextInput : Form
    {
        public string ReturnText;
        public TextInput()
        {
            InitializeComponent();
        }
        public TextInput(string prompt)
        {
            InitializeComponent();
            TB_NotifcationText.Text = prompt;
        }

        private void ReturnOK()
        {
            if (TB_InputText.Text.Length == 0 || TB_InputText.Text == string.Empty || TB_InputText.Text == null)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }

            ReturnText = TB_InputText.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ReturnCancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnOK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnCancel();
        }

        private void TextInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ReturnOK();
            else if (e.KeyCode == Keys.Escape)
                ReturnCancel();
        }
    }
}
