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
    public partial class MessageBoxEx : Form
    {
        public MessageBoxEx()
        {
            InitializeComponent();
        }
        public MessageBoxEx(string Message)
        {
            InitializeComponent();
            textBox1.Text = Message;
        }
        public MessageBoxEx(string Message, string Prompt)
        {
            InitializeComponent();
            textBox1.Text = Message;
            this.Text = Prompt;
        }

        private void ReturnOK()
        {
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
