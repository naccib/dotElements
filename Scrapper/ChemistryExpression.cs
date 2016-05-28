using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Scrapper
{
    public partial class ChemistryExpression : Form
    {
        private string ExpressaoNormalizada = "";
       

        public ChemistryExpression()
        {
            InitializeComponent();
            button1.Click += delegate
            {
                MessageBox.Show(ExpressaoNormalizada);

                SerializableStringDictionary d = new SerializableStringDictionary();

            };


        }

        private void ExpressionTB_TextChanged(object sender, EventArgs e) // ¹ ² ³
        {
            if (ExpressionTB.Text.Length > 0)
            {
                string UltimoDigito = ExpressionTB.Text[ExpressionTB.Text.Length - 1].ToString();
                int n;

                if (Int32.TryParse(UltimoDigito, out n)) // é numero
                {
                    if (ExpressionTB.Text.Length != 1)
                    {
                        if (UltimoDigito == "1")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₁";
                        }
                        else if (UltimoDigito == "2")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₂";
                        }
                        else if (UltimoDigito == "3")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₃";
                        }
                        else if (UltimoDigito == "4")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₄";
                        }
                        else if (UltimoDigito == "5")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₅";
                        }
                        else if (UltimoDigito == "6")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₆";
                        }
                        else if (UltimoDigito == "7")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₇";
                        }
                        else if (UltimoDigito == "8")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₈";
                        }
                        else if (UltimoDigito == "9")
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                            ExpressionTB.Text += "₉";
                        }
                        else//
                        {
                            ExpressionTB.Text = ExpressionTB.Text.Remove(ExpressionTB.Text.Length - 1);
                        }
                    }

                }
                else // digito normal
                {

                }
            }
        }
    }

    public class SerializableStringDictionary : StringDictionary, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read() &&
                !(reader.NodeType == XmlNodeType.EndElement && reader.LocalName == this.GetType().Name))
            {
                var name = reader["Name"];
                if (name == null)
                    throw new FormatException();

                var value = reader["Value"];
                this[name] = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var key in Keys)
            {
                writer.WriteStartElement("Pair");
                writer.WriteAttributeString("Name", (string)key);
                writer.WriteAttributeString("Value", this[(string)key]);
                writer.WriteEndElement();
            }
        }
    }
}
