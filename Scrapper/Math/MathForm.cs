using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Scrapper.Math
{
    public partial class MathForm : Form
    {
        private const int MAX_DEC_PLACES = 3;
        TransparentLabel valueL;
        TransparentLabel BGL;

        public MathForm()
        {
            InitializeComponent();
        }

        private void MathForm_Load(object sender, EventArgs e)
        {
            //ChemistryExpressionParser p = new ChemistryExpressionParser();
            //p.MolarMass("");

            addToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "+";
            };

            subtractToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "-";
            };

            multiplyToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "*";
            };

            divideToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "/";
            };

            powerToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "^";
            };

            logToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "10log(";
            };

            addToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "ln(";
            };

            squareRootToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "sqrt(";
            };

            sinToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "sin(";
            };

            cosToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "cos(";
            };

            tanToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "tan(";
            };

            aTanToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "atan(";
            };

            aCosToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "acos(";
            };

            aSinToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "asin(";
            };

            remainderToolStripMenuItem.Click += delegate
            {
                textBox1.Text += "%";
            };

            valueL = new TransparentLabel()
            {
                Text = "Hello.",
                Location = ValueLabel.Location,
                Size = ValueLabel.Size,
                Font = ValueLabel.Font,
                ForeColor = Color.FromArgb(196, 64 ,64)
                         
            };

            BGL = new TransparentLabel()
            {
                Text = "Hello.",
                Location = label1.Location,
                Size = label1.Size,
                Font = label1.Font,
                ForeColor = Color.FromArgb(159, 39, 39)
            };

            Controls.Add(valueL);
            Controls.Remove(ValueLabel);

            Controls.Add(BGL);
            Controls.Remove(label1);

            valueL.BringToFront();
            BGL.SendToBack();
















            try
            {
                foreach (string str in Scrapper.Properties.Settings.Default.VariablesColl)
                    varsList.Items.Add(str);
            }
            catch
            {

            }
        }  

        private void AddVarsBT_Click(object sender, EventArgs e)
        {
            AddVarsForm f = new AddVarsForm();
            f.ShowDialog();

            if(f.rslt != null)
            {
                varsList.Items.Add(string.Format("{0} = {1}", f.rslt.Name, f.rslt.Value));
                AtualizarProp();
            }
        }

        private void varsList_DoubleClick(object sender, EventArgs e)
        {
            string item = (string)varsList.SelectedItem;

            if (MessageBox.Show("Do you wish to delete this variable?", "Delete Variable", MessageBoxButtons.YesNo) == DialogResult.Yes)
                varsList.Items.RemoveAt(varsList.SelectedIndex);

            AtualizarProp();
        }

        private void AtualizarProp()
        {
            System.Collections.Specialized.StringCollection str = new System.Collections.Specialized.StringCollection();

            foreach(var item in varsList.Items)
            {
                str.Add((string)item);
            }

            Scrapper.Properties.Settings.Default.VariablesColl = str;
            Scrapper.Properties.Settings.Default.Save();
        }

        

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                ChangeText(System.Math.Round(MathExpressionParser.Parse(textBox1.Text, varsList), MAX_DEC_PLACES, MidpointRounding.ToEven).ToString());
            }
            catch { }
        }

        private void CleanVarsBT_Click(object sender, EventArgs e)
        {
            varsList.Items.Clear();
            AtualizarProp();
        }

        private void ChangeText(string txt)
        {
            BGL.Text = txt;
            valueL.Text = txt;
        }
    }

    public class TransparentLabel : Control
    {
        /// <summary>
        /// Creates a new <see cref="TransparentLabel"/> instance.
        /// </summary>
        public TransparentLabel()
        {
            TabStop = false;
        }

        /// <summary>
        /// Gets the creation parameters.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// Paints the control.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawText();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F)
            {
                DrawText();
            }
        }

        private void DrawText()
        {
            using (Graphics graphics = CreateGraphics())
            using (SolidBrush brush = new SolidBrush(ForeColor))
            {
                SizeF size = graphics.MeasureString(Text, Font);

                // first figure out the top
                float top = 0;
                switch (textAlign)
                {
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                        top = (Height - size.Height) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        top = Height - size.Height;
                        break;
                }

                float left = -1;
                switch (textAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:
                        if (RightToLeft == RightToLeft.Yes)
                            left = Width - size.Width;
                        else
                            left = -1;
                        break;
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                        left = (Width - size.Width) / 2;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                        if (RightToLeft == RightToLeft.Yes)
                            left = -1;
                        else
                            left = Width - size.Width;
                        break;
                }
                graphics.DrawString(Text, Font, brush, left, top);
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <returns>
        /// The text associated with this control.
        /// </returns>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                RecreateHandle();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// One of the <see cref="T:System.Windows.Forms.RightToLeft"/> values. The default is <see cref="F:System.Windows.Forms.RightToLeft.Inherit"/>.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
        /// The assigned value is not one of the <see cref="T:System.Windows.Forms.RightToLeft"/> values.
        /// </exception>
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                RecreateHandle();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.
        /// </returns>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                RecreateHandle();
            }
        }

        private ContentAlignment textAlign = ContentAlignment.TopLeft;
        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        public ContentAlignment TextAlign
        {
            get { return textAlign; }
            set
            {
                textAlign = value;
                RecreateHandle();
            }
        }
    }
}
