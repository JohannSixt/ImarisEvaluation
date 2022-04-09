using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using ImarisAddIn.Analyser;
using ExcelAddIn1;

namespace ImarisAddIn
{
    public partial class Ribbon2
    {
        private readonly string ResultCSV = "Result.csv";

        private void btnMergeFiles_Click(object sender, RibbonControlEventArgs e)
        {
            Workbook ActiveWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;

            if (ActiveWorkbook == null || ActiveWorkbook.Path.Equals(string.Empty))
            {
                MessageBox.Show("Excel woorkbook has to saved first. Please save it in your test data folder.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Globals.ThisAddIn.Application.StatusBar = "processing folder " + ActiveWorkbook.Path + " ...";

            string WorkbookName = ActiveWorkbook.FullName;
            string WorkbookPath = ActiveWorkbook.Path;

            DataAnalyser.AnalyseData(WorkbookPath);

            Globals.ThisAddIn.Application.ActiveWorkbook.Close();

            if (File.Exists(WorkbookName))
                File.Delete(WorkbookName);

            Globals.ThisAddIn.Application.Workbooks.Open(WorkbookPath + @"\" + ResultCSV);

            Globals.ThisAddIn.Application.ActiveWindow.SplitRow = 1;
            Globals.ThisAddIn.Application.ActiveWindow.FreezePanes = true;
            Globals.ThisAddIn.Application.ActiveSheet.Rows[1].AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
            Globals.ThisAddIn.Application.ActiveWorkbook.SaveAs(WorkbookName, XlFileFormat.xlOpenXMLWorkbook);

            Globals.ThisAddIn.Application.StatusBar = "";
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            DlgSettings Settings = new DlgSettings();
            Settings.ShowDialog();
        }
    }
}
