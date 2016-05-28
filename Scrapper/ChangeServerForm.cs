using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrapper
{
    public partial class ChangeServerForm : Form
    {
        public string serverResultString
        {
            get
            {
                return serverstr;
            }
        }

        private string serverstr = "Invalid Server";

        public ChangeServerForm()
        {
            InitializeComponent();
        }

        private void ChangeServerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("WARNING: Do not click 'Yes' if you do not know what you are doing, continue?", "Server Change", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Close();
                return;
            }

            if (textBox1.Text.Length == 0)
            {
                MessageBox.
                    Show("Empty Server String", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                return;
            }

            this.serverstr = textBox1.Text;
            this.Close();

            Logger.LogData("Server changed to " + textBox1.Text);           
        }
    }
}
