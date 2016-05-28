using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrapper.Math
{
    

    public partial class AddVarsForm : Form
    {
        public ResultVar rslt = null;

        public AddVarsForm()
        {
            InitializeComponent();
        }

        private void AtualizarDict()
        {
            foreach(TextBox c in groupBox1.Controls.OfType<TextBox>())
            {
                if(Convert.ToInt32(c.Name[c.Name.Length - 1]) % 2 == 0)
                {
                    MessageBox.Show(c.Name[c.Name.Length - 1].ToString());
                    //MessageBox.Show(groupBox1.Controls["textBox" + (Convert.ToInt32(c.Name[c.Name.Length - 1]) -1).ToString()].Name);
                    //MessageBox.Show(c2.Text);
                }
            }
        }

        private void AddVarsForm_Load(object sender, EventArgs e)
        {
            
        }

    

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double value;
            if(Double.TryParse(textBox1.Text, out value))
            {
                rslt = new ResultVar(textBox2.Text, value);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid value for variable " + textBox2.Text);
                this.Close();
            }
            
        }
    }

    public class ResultVar
    {
        public string Name
        {
            get; private set;
        }

        public double Value
        {
            get; private set;
        }

        public ResultVar(string n, double v)
        {
            Name = n;
            Value = v;
        }
    }
}
