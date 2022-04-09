using ExcelAddIn1;
using ImarisAddIn;

namespace ImarisAddIn
{
    partial class Ribbon2 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon2()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon2));
            this.tabImaris = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnMergeFiles = this.Factory.CreateRibbonButton();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.tabImaris.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tabImaris
            // 
            this.tabImaris.Groups.Add(this.group1);
            this.tabImaris.Label = "Imaris Test";
            this.tabImaris.Name = "tabImaris";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnMergeFiles);
            this.group1.Items.Add(this.btnSettings);
            this.group1.Name = "group1";
            // 
            // btnMergeFiles
            // 
            this.btnMergeFiles.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMergeFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnMergeFiles.Image")));
            this.btnMergeFiles.Label = "Merge Files";
            this.btnMergeFiles.Name = "btnMergeFiles";
            this.btnMergeFiles.ShowImage = true;
            this.btnMergeFiles.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMergeFiles_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSettings.Enabled = false;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Label = "Settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShowImage = true;
            this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettings_Click);
            // 
            // Ribbon2
            // 
            this.Name = "Ribbon2";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabImaris);
            this.tabImaris.ResumeLayout(false);
            this.tabImaris.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabImaris;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMergeFiles;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon2 Ribbon2
        {
            get { return this.GetRibbon<Ribbon2>(); }
        }
    }
}
