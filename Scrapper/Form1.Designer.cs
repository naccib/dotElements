namespace Scrapper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numberCB = new System.Windows.Forms.RadioButton();
            this.NameCB = new System.Windows.Forms.RadioButton();
            this.SearchButton = new System.Windows.Forms.Button();
            this.TBSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IsotopesButton = new System.Windows.Forms.Button();
            this.CSLabel = new System.Windows.Forms.Label();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.DensityLabel = new System.Windows.Forms.Label();
            this.ClassificationLabel = new System.Windows.Forms.Label();
            this.NoPELabel = new System.Windows.Forms.Label();
            this.BPLabel = new System.Windows.Forms.Label();
            this.MPLabel = new System.Windows.Forms.Label();
            this.AMassLabel = new System.Windows.Forms.Label();
            this.ANumberLabel = new System.Windows.Forms.Label();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AOS = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AtomicTreeView = new System.Windows.Forms.TreeView();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.aboutGuilhermeAlmeidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getVariablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.AOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerReportsProgress = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numberCB);
            this.groupBox1.Controls.Add(this.NameCB);
            this.groupBox1.Controls.Add(this.SearchButton);
            this.groupBox1.Controls.Add(this.TBSearch);
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // RSearch
            // 
            this.RSearch.Image = global::Scrapper.Properties.Resources.random;
            this.RSearch.Location = new System.Drawing.Point(3, 20);
            this.RSearch.Name = "RSearch";
            this.RSearch.Size = new System.Drawing.Size(117, 76);
            this.RSearch.TabIndex = 4;
            this.RSearch.UseVisualStyleBackColor = true;
            this.RSearch.Click += new System.EventHandler(this.RSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search by";
            // 
            // numberCB
            // 
            this.numberCB.AutoSize = true;
            this.numberCB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberCB.Location = new System.Drawing.Point(543, 63);
            this.numberCB.Name = "numberCB";
            this.numberCB.Size = new System.Drawing.Size(94, 27);
            this.numberCB.TabIndex = 2;
            this.numberCB.Text = "Number";
            this.numberCB.UseVisualStyleBackColor = true;
            // 
            // NameCB
            // 
            this.NameCB.AutoSize = true;
            this.NameCB.Checked = true;
            this.NameCB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameCB.Location = new System.Drawing.Point(450, 63);
            this.NameCB.Name = "NameCB";
            this.NameCB.Size = new System.Drawing.Size(87, 27);
            this.NameCB.TabIndex = 1;
            this.NameCB.TabStop = true;
            this.NameCB.Text = "Symbol";
            this.NameCB.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Scrapper.Properties.Resources.search_glass_1;
            this.SearchButton.Location = new System.Drawing.Point(948, 20);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(117, 76);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TBSearch
            // 
            this.TBSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBSearch.Location = new System.Drawing.Point(124, 21);
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(820, 30);
            this.TBSearch.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IsotopesButton);
            this.groupBox2.Controls.Add(this.CSLabel);
            this.groupBox2.Controls.Add(this.ColorLabel);
            this.groupBox2.Controls.Add(this.DensityLabel);
            this.groupBox2.Controls.Add(this.ClassificationLabel);
            this.groupBox2.Controls.Add(this.NoPELabel);
            this.groupBox2.Controls.Add(this.BPLabel);
            this.groupBox2.Controls.Add(this.MPLabel);
            this.groupBox2.Controls.Add(this.AMassLabel);
            this.groupBox2.Controls.Add(this.ANumberLabel);
            this.groupBox2.Controls.Add(this.symbolLabel);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.nameLabel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox2.Location = new System.Drawing.Point(15, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 414);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select a Element!";
            // 
            // IsotopesButton
            // 
            this.IsotopesButton.Image = global::Scrapper.Properties.Resources.flask_two;
            this.IsotopesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IsotopesButton.Location = new System.Drawing.Point(6, 366);
            this.IsotopesButton.Name = "IsotopesButton";
            this.IsotopesButton.Size = new System.Drawing.Size(145, 40);
            this.IsotopesButton.TabIndex = 27;
            this.IsotopesButton.Text = "  Isotopes";
            this.IsotopesButton.UseVisualStyleBackColor = true;
            this.IsotopesButton.Click += new System.EventHandler(this.IsotopesButton_Click);
            // 
            // CSLabel
            // 
            this.CSLabel.AutoSize = true;
            this.CSLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSLabel.Location = new System.Drawing.Point(217, 340);
            this.CSLabel.Name = "CSLabel";
            this.CSLabel.Size = new System.Drawing.Size(60, 23);
            this.CSLabel.TabIndex = 26;
            this.CSLabel.Text = "Name:";
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLabel.Location = new System.Drawing.Point(217, 309);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(60, 23);
            this.ColorLabel.TabIndex = 25;
            this.ColorLabel.Text = "Name:";
            // 
            // DensityLabel
            // 
            this.DensityLabel.AutoSize = true;
            this.DensityLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DensityLabel.Location = new System.Drawing.Point(217, 278);
            this.DensityLabel.Name = "DensityLabel";
            this.DensityLabel.Size = new System.Drawing.Size(60, 23);
            this.DensityLabel.TabIndex = 24;
            this.DensityLabel.Text = "Name:";
            // 
            // ClassificationLabel
            // 
            this.ClassificationLabel.AutoSize = true;
            this.ClassificationLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassificationLabel.Location = new System.Drawing.Point(222, 247);
            this.ClassificationLabel.Name = "ClassificationLabel";
            this.ClassificationLabel.Size = new System.Drawing.Size(60, 23);
            this.ClassificationLabel.TabIndex = 23;
            this.ClassificationLabel.Text = "Name:";
            // 
            // NoPELabel
            // 
            this.NoPELabel.AutoSize = true;
            this.NoPELabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoPELabel.Location = new System.Drawing.Point(217, 216);
            this.NoPELabel.Name = "NoPELabel";
            this.NoPELabel.Size = new System.Drawing.Size(60, 23);
            this.NoPELabel.TabIndex = 22;
            this.NoPELabel.Text = "Name:";
            // 
            // BPLabel
            // 
            this.BPLabel.AutoSize = true;
            this.BPLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPLabel.Location = new System.Drawing.Point(217, 185);
            this.BPLabel.Name = "BPLabel";
            this.BPLabel.Size = new System.Drawing.Size(60, 23);
            this.BPLabel.TabIndex = 21;
            this.BPLabel.Text = "Name:";
            // 
            // MPLabel
            // 
            this.MPLabel.AutoSize = true;
            this.MPLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MPLabel.Location = new System.Drawing.Point(217, 154);
            this.MPLabel.Name = "MPLabel";
            this.MPLabel.Size = new System.Drawing.Size(60, 23);
            this.MPLabel.TabIndex = 20;
            this.MPLabel.Text = "Name:";
            // 
            // AMassLabel
            // 
            this.AMassLabel.AutoSize = true;
            this.AMassLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AMassLabel.Location = new System.Drawing.Point(217, 123);
            this.AMassLabel.Name = "AMassLabel";
            this.AMassLabel.Size = new System.Drawing.Size(60, 23);
            this.AMassLabel.TabIndex = 19;
            this.AMassLabel.Text = "Name:";
            // 
            // ANumberLabel
            // 
            this.ANumberLabel.AutoSize = true;
            this.ANumberLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANumberLabel.Location = new System.Drawing.Point(217, 92);
            this.ANumberLabel.Name = "ANumberLabel";
            this.ANumberLabel.Size = new System.Drawing.Size(60, 23);
            this.ANumberLabel.TabIndex = 18;
            this.ANumberLabel.Text = "Name:";
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbolLabel.Location = new System.Drawing.Point(217, 61);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(60, 23);
            this.symbolLabel.TabIndex = 17;
            this.symbolLabel.Text = "Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 340);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 23);
            this.label13.TabIndex = 16;
            this.label13.Text = "Crystal Structure:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 23);
            this.label11.TabIndex = 14;
            this.label11.Text = "Color:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(217, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(60, 23);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 23);
            this.label10.TabIndex = 12;
            this.label10.Text = "Density:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 23);
            this.label9.TabIndex = 11;
            this.label9.Text = "Classification:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Prontons and Eletrons:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Boiling Point:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Melting Point:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Atomic Mass:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Atomic Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Symbol:";
            // 
            // AOS
            // 
            this.AOS.Controls.Add(this.button1);
            this.AOS.Controls.Add(this.AtomicTreeView);
            this.AOS.Controls.Add(this.pBox);
            this.AOS.ForeColor = System.Drawing.Color.Crimson;
            this.AOS.Location = new System.Drawing.Point(527, 121);
            this.AOS.Name = "AOS";
            this.AOS.Size = new System.Drawing.Size(561, 414);
            this.AOS.TabIndex = 6;
            this.AOS.TabStop = false;
            this.AOS.Text = "Select a Element!";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Scrapper.Properties.Resources.tableMedium;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(20, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 122);
            this.button1.TabIndex = 2;
            this.button1.Text = "                              Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AtomicTreeView
            // 
            this.AtomicTreeView.Location = new System.Drawing.Point(311, 30);
            this.AtomicTreeView.Name = "AtomicTreeView";
            this.AtomicTreeView.Size = new System.Drawing.Size(229, 376);
            this.AtomicTreeView.TabIndex = 1;
            // 
            // pBox
            // 
            this.pBox.InitialImage = global::Scrapper.Properties.Resources.icon1;
            this.pBox.Location = new System.Drawing.Point(20, 30);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(264, 248);
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.pBar,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.StatusBar.Location = new System.Drawing.Point(0, 541);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1097, 26);
            this.StatusBar.TabIndex = 7;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(50, 21);
            this.StatusLabel.Text = "Ready";
            // 
            // pBar
            // 
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(100, 20);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutGuilhermeAlmeidaToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::Scrapper.Properties.Resources.about_all;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // aboutGuilhermeAlmeidaToolStripMenuItem
            // 
            this.aboutGuilhermeAlmeidaToolStripMenuItem.Image = global::Scrapper.Properties.Resources.aboutme;
            this.aboutGuilhermeAlmeidaToolStripMenuItem.Name = "aboutGuilhermeAlmeidaToolStripMenuItem";
            this.aboutGuilhermeAlmeidaToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.aboutGuilhermeAlmeidaToolStripMenuItem.Text = "About Guilherme Almeida";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.advancedToolStripMenuItem1});
            this.toolStripSplitButton2.Image = global::Scrapper.Properties.Resources.settings;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.customizeToolStripMenuItem.Image = global::Scrapper.Properties.Resources.customize;
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.customizeToolStripMenuItem.Text = "Customize...";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Image = global::Scrapper.Properties.Resources.FontCustomize;
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Image = global::Scrapper.Properties.Resources.color_customize;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Scrapper.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Image = global::Scrapper.Properties.Resources.reset;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // advancedToolStripMenuItem1
            // 
            this.advancedToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.getVariablesToolStripMenuItem});
            this.advancedToolStripMenuItem1.Image = global::Scrapper.Properties.Resources.advanced;
            this.advancedToolStripMenuItem1.Name = "advancedToolStripMenuItem1";
            this.advancedToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.advancedToolStripMenuItem1.Text = "Advanced";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Image = global::Scrapper.Properties.Resources.devLog;
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Image = global::Scrapper.Properties.Resources.server;
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // getVariablesToolStripMenuItem
            // 
            this.getVariablesToolStripMenuItem.Image = global::Scrapper.Properties.Resources.variables;
            this.getVariablesToolStripMenuItem.Name = "getVariablesToolStripMenuItem";
            this.getVariablesToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.getVariablesToolStripMenuItem.Text = "Get Variables";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 567);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.AOS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".element";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.AOS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox TBSearch;
        private System.Windows.Forms.RadioButton numberCB;
        private System.Windows.Forms.RadioButton NameCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ANumberLabel;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MPLabel;
        private System.Windows.Forms.Label AMassLabel;
        private System.Windows.Forms.Label NoPELabel;
        private System.Windows.Forms.Label BPLabel;
        private System.Windows.Forms.Label ClassificationLabel;
        private System.Windows.Forms.Label DensityLabel;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label CSLabel;
        private System.Windows.Forms.Button IsotopesButton;
        private System.Windows.Forms.GroupBox AOS;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.TreeView AtomicTreeView;
        private System.Windows.Forms.Button RSearch;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar pBar;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem aboutGuilhermeAlmeidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getVariablesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

