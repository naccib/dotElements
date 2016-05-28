using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrapper
{
    public partial class ElementShowForm : Form
    {
        public string SourceCode = null;
        public string URLFormat = "http://www.chemicalelements.com/elements/{0}.html";
        public string elementString = "h";
        private Elemento returnElement = null;

        public ElementShowForm(string elemString)
        {
            this.elementString = elemString;
            InitializeComponent();
        }

        private void ElementShowForm_Load(object sender, EventArgs e)
        {
            BGWorker.RunWorkerAsync();
        }

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripStatusLabel1.Text = (string)e.UserState;
            this.toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Logger.LogData("PROCESSING STARTED", true);

            BGWorker.ReportProgress(20, "Downloading info...");
            WebClient w = new WebClient();

            Logger.LogData("Downloading HTML from " + string.Format(URLFormat, elementString));

            try
            {
                SourceCode = w.DownloadString(string.Format(URLFormat, elementString));
                BGWorker.ReportProgress(100, "Ready");

                Logger.LogData("Download Succeded");
            }
            catch (Exception x)
            {
                MessageBox.Show("An Error Ocurred :[\n\n\n\nDetails: " + x.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                BGWorker.ReportProgress(0, "Error: " + x.Message.Substring(0, x.Message.Length / 2) + "...");

                Logger.LogData("Download falied, error: " + x.Message);
            }
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.returnElement = AgilityParser.Parse(SourceCode);
            this.toolStripProgressBar1.Value = 100;
            this.toolStripStatusLabel1.Text = "Ready";

            foreach (Label lbl in this.groupBox2.Controls.OfType<Label>())
                lbl.Visible = true;

            nameLabel.Text = this.Text = returnElement.Name;
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
            groupBox2.Text = string.Format("{0} ({1})", returnElement.Name, returnElement.Symbol.Replace(" ", ""));
        }
    }
}
