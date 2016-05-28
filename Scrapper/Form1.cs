using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Scrapper
{

    public partial class Form1 : Form
    {
        public string SourceCode = null;
        public string URLFormat = "http://www.chemicalelements.com/elements/{0}.html";
        public string elementString = "h";
        public bool SearchByName = true;
        private Elemento returnElement = null;
        private string IsotopesString;

        public Form1()
        {
            if(!AgilityParser.CheckInternetConnection())
            {
                if(MessageBox.Show("Could not detect any internet connection, you will not be able to use the program without Internet Connection, retry?", "No Connection", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Retry)
                {
                    if(!AgilityParser.CheckInternetConnection())
                    {
                        this.Close();
                        Application.Exit();
                    }
                }
                else
                {
                    this.Close();
                    Application.Exit();
                }
            }
            InitializeComponent();
        }

        private void InitializeSettings()
        {
            if (Scrapper.Properties.Settings.Default.color_custom != Scrapper.Properties.Settings.Default.color_default && Scrapper.Properties.Settings.Default.font_custom != Scrapper.Properties.Settings.Default.font_default_normal)
            {
                foreach(Control c in this.Controls)
                {
                    if(!c.Name.Contains("Label"))
                    {
                        c.Font = Scrapper.Properties.Settings.Default.font_custom;
                        c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                    }
                    else
                    {
                        c.Font = new Font(Scrapper.Properties.Settings.Default.font_custom, FontStyle.Bold);
                        c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                    }
                }

                foreach (Control c in this.groupBox1.Controls)
                {
                    if (!c.Name.Contains("Label"))
                    {
                        c.Font = Scrapper.Properties.Settings.Default.font_custom;
                        c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                    }
                    else
                    {
                        c.Font = new Font(Scrapper.Properties.Settings.Default.font_custom, FontStyle.Bold);
                        c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                    }
                }

                foreach (Control c in this.groupBox2.Controls)
                {
                    if (!c.Name.Contains("Label"))
                    {
                        c.Font = Scrapper.Properties.Settings.Default.font_custom;
                        c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                    }
                    else
                    {
                        c.Font = new Font(Scrapper.Properties.Settings.Default.font_custom, FontStyle.Bold);
                        c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                    }
                }
            }

            if(Scrapper.Properties.Settings.Default.server_custom != Scrapper.Properties.Settings.Default.server_default)
            {
                this.URLFormat = Scrapper.Properties.Settings.Default.server_custom;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeSettings();

            ToolTip.SetToolTip(this.RSearch, "Search for a random element.");
            ToolTip.SetToolTip(this.SearchButton, "Search for a element.");
            ToolTip.SetToolTip(this.pBox, "Image for element " + elementString.ToUpper() + ".");
            ToolTip.SetToolTip(this.AtomicTreeView, "Atomic tree-view.");

            this.FormClosing += delegate
            {
                try
                {
                    if (!File.Exists("log.element"))
                        File.Create("log.element");

                    if (Logger.GetLogData() != null)
                    {
                        using (StreamWriter sr = new StreamWriter("log.element"))
                        {
                            sr.WriteLine(("=============== " + DateTime.Now + " ===============").PadRight(20));
                            foreach (string l in Logger.GetLogData().Split(new char[] { '\n' }))
                                sr.WriteLine(l);

                            sr.Close();
                        }
                    }
                }
                catch
                {
                    return;
                }
                
            };

            foreach (Control c in this.groupBox2.Controls.OfType<Label>())
            {
                if(c.Name.Contains("Label"))
                {
                    c.Visible = false;
                }
            }

            foreach(Control c in this.groupBox1.Controls.OfType<RadioButton>())
            {
                RadioButton cb = c as RadioButton;
                cb.CheckedChanged += (object s, EventArgs args) =>
                {
                    if (this.numberCB.Checked)
                        SearchByName = false;
                    else
                        SearchByName = true;
                };
            }

            this.IsotopesButton.Enabled = false;

            this.BGWorker.ProgressChanged += (object sndr, ProgressChangedEventArgs args) =>
            {
                this.pBar.Value = args.ProgressPercentage;
                this.StatusLabel.Text = (string)args.UserState;
            };

            // TOOLSTRIP MENU ITEMS

            this.aboutGuilhermeAlmeidaToolStripMenuItem.Click += delegate
            {
                // abriria um site se eu tivesse um, haha... triste vida
                MessageBox.Show("Hi, I'm Guilherme, most people just go by 'Gui' so... go the way you wish.\nI am the guy who spent 2 days developing this program using C# and a Web Scraper.", "Hello, Olá", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            };

            this.fontToolStripMenuItem.Click += delegate
            {
                FontDialog f = new FontDialog();
                if (f.ShowDialog() != DialogResult.Cancel && f.Font.Size < 15)
                {
                    foreach (Control ctrl in this.Controls)
                        ctrl.Font = f.Font;

                    foreach (Control ctrl in this.groupBox1.Controls)
                        ctrl.Font = f.Font;

                    foreach (Control ctrl in this.groupBox2.Controls)
                        ctrl.Font = f.Font;
                }

                Logger.LogData("Changed current font to " + Font.Name);
                Scrapper.Properties.Settings.Default.font_custom = f.Font;
            };

            this.colorToolStripMenuItem.Click += delegate
            {
                ColorDialog c = new ColorDialog();
                if (c.ShowDialog() != DialogResult.Cancel)
                {
                    foreach (Control ctrl in this.Controls)
                        ctrl.ForeColor = c.Color;

                    foreach (Control ctrl in this.groupBox1.Controls)
                        ctrl.ForeColor = c.Color;

                    foreach (Control ctrl in this.groupBox2.Controls)
                        ctrl.ForeColor = c.Color;
                }

                Logger.LogData("Changed current color to to " + c.Color.ToArgb().ToString());
                Scrapper.Properties.Settings.Default.color_custom = c.Color;
            };

            this.saveToolStripMenuItem.Click += delegate
            {
                Scrapper.Properties.Settings.Default.Save();
                this.StatusLabel.Text = "Settings Saved";
                Logger.LogData("Settings Saved.");
            };

            this.resetToolStripMenuItem.Click += delegate
            {
                Scrapper.Properties.Settings.Default.color_custom = Scrapper.Properties.Settings.Default.color_default;
                Scrapper.Properties.Settings.Default.font_custom = Scrapper.Properties.Settings.Default.font_default_normal;
                Scrapper.Properties.Settings.Default.server_custom = Scrapper.Properties.Settings.Default.server_default;

                Scrapper.Properties.Settings.Default.Save();
                ResetUI();

                Logger.LogData("Setting Reset");
                this.StatusLabel.Text = "Settings Reset";
            };

            TBSearch.KeyDown += (object a, KeyEventArgs b) =>
            {
                if (b.KeyCode == Keys.Enter)
                    SearchButton.PerformClick();
            };

            TBSearch.LostFocus += (object a, EventArgs b) =>
            {
                TBSearch.Focus();
            };

            this.logToolStripMenuItem.Click += delegate
            {
                MessageBox.Show(Logger.GetLogData());
            };

            this.serverToolStripMenuItem.Click += delegate
            {
                ChangeServerForm svr = new ChangeServerForm();
                svr.ShowDialog();

                if (svr.serverResultString == "Invalid Server")
                    return;
            };

            this.getVariablesToolStripMenuItem.Click += delegate
            {
                string vars = "";

                foreach(System.Configuration.SettingsProperty p in Scrapper.Properties.Settings.Default.Properties)
                {
                    vars += string.Format("{0} = {1}**", p.Name, p.DefaultValue);
                }

                MessageBox.Show(vars.Replace("**", "\n"));
            };

            this.getVariablesToolStripMenuItem.Click += (object a, EventArgs b) =>
            {
                
            };
        }

        private void ResetUI()
        {
            foreach (Control c in this.Controls)
            {
                if (!c.Name.Contains("Label"))
                {
                    c.Font = Scrapper.Properties.Settings.Default.font_custom;
                    c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                }
                else
                {
                    c.Font = new Font(Scrapper.Properties.Settings.Default.font_custom, FontStyle.Bold);
                    c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                }
            }

            foreach (Control c in this.groupBox1.Controls)
            {
                if (!c.Name.Contains("Label"))
                {
                    c.Font = Scrapper.Properties.Settings.Default.font_custom;
                    c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                }
                else
                {
                    c.Font = new Font(Scrapper.Properties.Settings.Default.font_custom, FontStyle.Bold);
                    c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                }
            }

            foreach (Control c in this.groupBox2.Controls)
            {
                if (!c.Name.Contains("Label"))
                {
                    c.Font = Scrapper.Properties.Settings.Default.font_custom;
                    c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                }
                else
                {
                    c.Font = new Font(Scrapper.Properties.Settings.Default.font_custom, FontStyle.Bold);
                    c.ForeColor = Scrapper.Properties.Settings.Default.color_custom;
                }
            }

            Logger.LogData("UI Reset to Default");
    }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Logger.LogData("PROCESSING STARTED", true);

            //BGWorker.ReportProgress(20, "Downloading info...");
            WebClient w = new WebClient();

            Logger.LogData("Downloading HTML from " + string.Format(URLFormat, elementString));

            try
            {


                 SourceCode = w.DownloadString(string.Format(URLFormat, elementString));
                 BGWorker.ReportProgress(100, "Ready");

                 Logger.LogData("Download Succeded");

                //SourceCode = File.ReadAllText(@"C:\Users\Antônio\documents\visual studio 2015\Projects\Scrapper\Scrapper\Resources\bi.html");
                
            }
            catch(Exception x)
            {
                MessageBox.Show("An Error Ocurred :[\n\n\n\nDetails: " + x.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                BGWorker.ReportProgress(0, "Error: " + x.Message.Substring(0, x.Message.Length / 2) + "...");

                Logger.LogData("Download falied, error: " + x.Message);
            }
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            this.returnElement = AgilityParser.Parse(SourceCode);

            foreach (Label lbl in this.groupBox2.Controls.OfType<Label>())
                lbl.Visible = true;

            nameLabel.Text = returnElement.Name;
            symbolLabel.Text = returnElement.Symbol;
            ANumberLabel.Text = returnElement.ANumber;
            AMassLabel.Text = returnElement.AMass;
            MPLabel.Text = returnElement.MP;
            BPLabel.Text = returnElement.BP;
            NoPELabel.Text = returnElement.NoPE;
            DensityLabel.Text = returnElement.Density + "³";
            ColorLabel.Text = returnElement.Color;
            CSLabel.Text = returnElement.CrystalGeo;
            ClassificationLabel.Text = returnElement.Classification;
            groupBox2.Text = AOS.Text = string.Format("{0} ({1})", returnElement.Name, returnElement.Symbol.Replace(" ", ""));

            this.IsotopesString = returnElement.GetIsotopes();
            this.IsotopesButton.Enabled = true;

            
            
            
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.Load(returnElement.AtomicStructureImage);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string[] Elements = "h,he,li,be,b,c,n,o,f,ne,na,mg,al,si,p,s,cl,ar,k,ca,sc,ti,v,cr,mn,fe,co,ni,cu,zn,ga,ge,as,se,br,kr,rb,sr,y,zr,nb,mo,tc,ru,rh,pd,ag,cd,in,sn,sb,te,i,xe,cs,ba,la,ce,pr,nd,pm,sm,eu,gd,tb,dy,ho,er,tm,yb,lu,hf,ta,w,re,os,ir,pt,au,hg,ti,pb,bi,po,at,rn,fr,ra,ac,th,pa,u,np,pu,am,cm,bk,cf,es,fm,md,no,lr,rf,db,sg,bh,mt,ds,rg,uub,uut,uuq,uup,uuh,uus,uuo".Split(new char[] { ',' });
            List<string> el = Elements.ToList<string>();

            if (!SearchByName)
            {
                int n;
                if (Int32.TryParse(this.TBSearch.Text, out n))
                    if (n <= 0 || n > 118)
                        MessageBox.Show("The element number must be a number between 1 and 118.", "Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
                    else
                        this.elementString = AgilityParser.GetElement(n - 1);                  
            }
            else
            {
                if(elementString.Length > 3)
                    MessageBox.Show("The element symbol must be 3 digits long by maximum.", "Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
                else if(!el.Contains(this.TBSearch.Text.ToLower()))
                    MessageBox.Show("Unknown element.", "Unknown Element;", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
                else
                    this.elementString = this.TBSearch.Text.ToLower();
            }

            if (!BGWorker.IsBusy)
                BGWorker.RunWorkerAsync();
        }

        private void IsotopesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.IsotopesString, "Isotopes found: " + (IsotopesString.Split(new char[] { '\n' }).Length - 1).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void RSearch_Click(object sender, EventArgs e)
        {
            this.elementString = AgilityParser.GetElement(new Random().Next(1, 118));
            this.TBSearch.Text = elementString.Replace(elementString[0].ToString(), elementString[0].ToString().ToUpper());

            this.NameCB.Checked = true;
            this.numberCB.Checked = false;

            if(!BGWorker.IsBusy)
                BGWorker.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PeriodicTableForm().ShowDialog();
        }
    }

    public static class AgilityParser
    {
        public static Elemento Parse(string HTML)
        {
            string[] HTMLArray = HTML.Split(new char[] { '\n' });
            Elemento elemento = new Elemento();

            Logger.LogData("HTML Scrapping Started");

            foreach (string line in HTMLArray)
            {
                if (line.Contains("Name:"))
                {
                    elemento.Name = ReplaceAll(line);
                }

                if (line.Contains("Symbol:"))
                {
                    elemento.Symbol = ReplaceAll(line);
                }

                if (line.Contains("Atomic Number:"))
                {
                    elemento.ANumber = ReplaceAll(line);
                }

                if (line.Contains("Atomic Mass:"))
                {
                    elemento.AMass = ReplaceAll(line);
                }

                if (line.Contains("Melting Point:"))
                {
                    elemento.MP = ReplaceAll(line).Replace("deg;", "º");
                }

                if (line.Contains("Boiling Point:"))
                {
                    elemento.BP = ReplaceAll(line).Replace("deg;", "º");
                }

                if (line.Contains("Number of Protons/Electrons:"))
                {
                    elemento.NoPE = ReplaceAll(line);
                }

                if (line.Contains("Number of Neutrons:"))
                {
                    elemento.NoN = ReplaceAll(line);
                }

                if (line.Contains("Crystal Structure:"))
                {
                    elemento.CrystalGeo = ReplaceAll(line);
                }

                if (line.Contains("Density @"))
                {
                    elemento.Density = ReplaceAll(line);
                }

                if (line.Contains("Color:"))
                {
                    elemento.Color = ReplaceAll(line);
                }

                if (line.Contains("Classification:"))
                {
                    if (line.Contains("Non-metal"))
                    {
                        elemento.Classification = "Non-Metal";
                    }
                    else
                    {
                        elemento.Classification = "Metal";
                    }
                }

                if (line.Contains("Number of Energy Levels:"))
                {
                    Int32.TryParse(line.Replace("<br><strong>Number of Energy Levels:</strong> ", ""), out elemento.EnergyLVLNumber);
                    //MessageBox.Show(elemento.EnergyLVLNumber.ToString());
                }

                try
                {
                    if (line.Contains("First Energy Level:"))
                    {
                        elemento.EnergyLevels[0] = line.Replace("<br><strong>First Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Second Energy Level:"))
                    {
                        elemento.EnergyLevels[1] = line.Replace("<br><strong>Second Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Third Energy Level:"))
                    {
                        elemento.EnergyLevels[2] = line.Replace("<br><strong>Third Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Fourth Energy Level:"))
                    {
                        elemento.EnergyLevels[3] = line.Replace("<br><strong>Fourth Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Fifth Energy Level:"))
                    {
                        elemento.EnergyLevels[4] = line.Replace("<br><strong>Fifth Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Sixth Energy Level:"))
                    {
                        elemento.EnergyLevels[5] = line.Replace("<br><strong>Sixth Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Seventh Energy Level:"))
                    {
                        elemento.EnergyLevels[6] = line.Replace("<br><strong>Seventh Energy Level:</strong> ", "");
                    }
                }
                catch (Exception x)
                {
                    Logger.LogData("Trivial ERROR: " + x.Message);
                    //MessageBox.Show("An Error Ocurred :[\n\n\n\nDetails: " + x.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            // ler html
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(HTML);

            List<string> tempList = new List<string>();

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//font"))
            {
                if (node.InnerText != "Isotope" && node.InnerText != "Half Life" && node.InnerText.Length < 15)
                {
                    tempList.Add(node.InnerText);
                }
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//img"))
            {
                if (node.GetAttributeValue("ALT", "error").Contains("[Bohr Model of"))
                {
                    elemento.AtomicStructureImage = "http://www.chemicalelements.com/" + node.GetAttributeValue("SRC", "error").Replace("..", "");
                }
            }

            for (int i = 0; i < tempList.Count / 2; ++i)
            {
                if (i % 2 == 0)
                {
                    elemento.Isotopes[tempList[i]] = tempList[i + 1];
                }
                else
                {
                    elemento.Isotopes[tempList[i + 1]] = tempList[i];
                }
            }

            // MessageBox.Show(elemento.GetBasicElemString());
            // MessageBox.Show(elemento.GetIsotopes());


            Logger.LogData(elemento.GetBasicElemString());
            Logger.LogData("END OF PROCESSING", true);

            return elemento;
        }

        private static string ReplaceAll(string str)
        {
            return str.Replace("<br><strong>Name:</strong>", "").Replace("<br><strong>Symbol:</strong>", "").Replace("<br><strong>Atomic Number:</strong>", "").
                Replace("<br><strong>Atomic Mass:</strong>", "").Replace("<br><strong>Melting Point:</strong>", "").Replace("<br><strong>Boiling Point:</strong>", "").
                Replace("<br><strong>Number of Protons/Electrons:</strong>", "").Replace("<br><strong>Number of Neutrons:</strong>", "").Replace("<br><strong>Crystal Structure:</strong>", "").
                Replace("<br><strong>Density @ 293 K:</strong>", "").Replace("<sup>3</sup>", "").Replace("<br><strong>Color:</strong>", "");
        }

        public static string GetElement(object arg)
        {
            string[] Elements = "h,he,li,be,b,c,n,o,f,ne,na,mg,al,si,p,s,cl,ar,k,ca,sc,ti,v,cr,mn,fe,co,ni,cu,zn,ga,ge,as,se,br,kr,rb,sr,y,zr,nb,mo,tc,ru,rh,pd,ag,cd,in,sn,sb,te,i,xe,cs,ba,la,ce,pr,nd,pm,sm,eu,gd,tb,dy,ho,er,tm,yb,lu,hf,ta,w,re,os,ir,pt,au,hg,ti,pb,bi,po,at,rn,fr,ra,ac,th,pa,u,np,pu,am,cm,bk,cf,es,fm,md,no,lr,rf,db,sg,bh,mt,ds,rg".Split(new char[] { ',' });
            try
            {
                if (arg is string)
                {
                    string elemName = (string)arg;
                    return elemName[0].ToString();
                }
                else
                {
                    return Elements[(int)arg];
                }
            }
            catch
            {
                return "h";
            }
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (WebClient w = new WebClient())
                {
                    using (var stream = w.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

        }
    }

    public class Elemento
    {
        // basico
        public string Name, Symbol, ANumber, AMass, MP, BP, NoPE, NoN, Classification, Density, Color, CrystalGeo;

        // avancado
        public Dictionary<string, string> Isotopes = new Dictionary<string, string>();
        public string AtomicStructureImage;

        public int EnergyLVLNumber;
        public string[] EnergyLevels = new string[6];
        

        public string GetBasicElemString()
        {
            return string.Format("Name: {0}\nSymbol: {1}\nAtomic Number: {2}\nAtomic Mass: {3}\nMelting Point: {4}\nBoiling Point: {5}\nNoPE: {6}\nNoN: {7}\nClassification: {8}\nDensity: {9}\nColor: {10}\nCrystal S.: {11}", new object[] { Name, Symbol, ANumber, AMass, MP, BP, NoPE, NoN, Classification, Density, Color, CrystalGeo });
        }

        public string GetIsotopes()
        {
            string text = "";

            foreach(KeyValuePair<string, string> pair in this.Isotopes)
            {
                text += string.Format("{0} : {1}\n", pair.Key, pair.Value);
            }

            return text;
        }
    }

    public static class Logger
    {
        private static string logString = null;

        public static string GetLogData()
        {
            return logString;
        }

        public static void LogData(string log, bool separator = false)
        {
            if (string.IsNullOrEmpty(logString))
                logString = "";

            if (!separator)
                logString += log + "\n";
            else
                logString += ("####### " + log + " #######" + "\n").PadRight(20);
        }

        public static void ClearLog()
        {
            logString = null;
        }
    }
}
