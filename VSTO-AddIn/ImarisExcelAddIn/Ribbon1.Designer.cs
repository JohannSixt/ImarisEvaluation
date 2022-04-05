
namespace ExcelAddIn1
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">"true", wenn verwaltete Ressourcen gelöscht werden sollen, andernfalls "false".</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.tabImaris = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnMergeFiles = this.Factory.CreateRibbonButton();
            this.btnEditStraightness = this.Factory.CreateRibbonButton();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.tabImaris.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tabImaris
            // 
            this.tabImaris.Groups.Add(this.group1);
            this.tabImaris.Label = "Imaris-Test";
            this.tabImaris.Name = "tabImaris";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnMergeFiles);
            this.group1.Items.Add(this.btnEditStraightness);
            this.group1.Items.Add(this.btnSettings);
            this.group1.Label = "VS-AddIn";
            this.group1.Name = "group1";
            // 
            // btnMergeFiles
            // 
            this.btnMergeFiles.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMergeFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnMergeFiles.Image")));
            this.btnMergeFiles.Label = "Merge Files";
            this.btnMergeFiles.Name = "btnMergeFiles";
            this.btnMergeFiles.ShowImage = true;
            this.btnMergeFiles.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnEditStraightness
            // 
            this.btnEditStraightness.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnEditStraightness.Image = ((System.Drawing.Image)(resources.GetObject("btnEditStraightness.Image")));
            this.btnEditStraightness.Label = "Edit Straighness";
            this.btnEditStraightness.Name = "btnEditStraightness";
            this.btnEditStraightness.ShowImage = true;
            // 
            // btnSettings
            // 
            this.btnSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Label = "Settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShowImage = true;
            this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfiguration_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabImaris);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tabImaris.ResumeLayout(false);
            this.tabImaris.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabImaris;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMergeFiles;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditStraightness;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
