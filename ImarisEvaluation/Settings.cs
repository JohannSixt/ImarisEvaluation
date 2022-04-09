using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace ImarisAddIn.Analyser
{
    [Serializable]
    public class Settings
    {
        private const string SettingsFile = @"\ImarisAddIn.settings.xml";
        private static Settings mSettings;

        public string ExperimentsFolderPrefix;
        public string MigrationStatisticsFolderSpec;
        public string IDColumn;
        public string ComponentNameColumn;

        private Settings()
        {
            ExperimentsFolderPrefix = "V";
            MigrationStatisticsFolderSpec = "Migration_Statistics";
            IDColumn = "ID";
            ComponentNameColumn = "Original Component Name";
        }

        public static Settings Instance
        {
            get
            {
                if (mSettings == null)
                    mSettings = new Settings();

                return mSettings;
            }
        }

        public List<string> FileList
        {
            get
            {
                return new List<string>()
                {
                   "Track_Displacement",
                   "Track_Displacement_Length",
                   "Track_Duration",
                   "Track_Length",
                   "Track_Speed_Max",
                   "Track_Speed_Mean",
                   "Track_Speed_Min",
                   "Track_Speed_StdDev",
                   "Track_Speed_Variation",
                   "Track_Straightness"
                };
            }
        }

        public void Save()
        {
            try
            {
                Stream Writer = File.Create((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName + SettingsFile);
                XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
                Serializer.Serialize(Writer, this);
                Writer.Close();
            }
            catch { }
        }
    }
}
