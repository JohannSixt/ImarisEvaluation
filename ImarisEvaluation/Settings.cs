using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace ImarisAddIn.Analyser
{
    [Serializable]
    public class DataFileSpec
    {
        public string FileSpec { get; set; }
        public List<string> Data { get; set; }
    }

    [Serializable]
    public class Settings
    {
        private const string SettingsFile = @"\ImarisAddIn.settings.xml";
        private static Settings mSettings;

        public string ExperimentsFolderPrefix;
        public string MigrationStatisticsFolderSpec;
        public string IDColumn;
        public string ComponentNameColumn;
        public List<DataFileSpec> DataFileSpecs;

        private Settings()
        {
            DefaultSettings();
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
        
        private void DefaultSettings()
        {
            ExperimentsFolderPrefix = "V";
            MigrationStatisticsFolderSpec = "Migration_Statistics";
            IDColumn = "ID";
            ComponentNameColumn = "Original Component Name";

            DataFileSpecs = new List<DataFileSpec>()
                {
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Displacement", 
                        Data = new List<string>{"Track Displacement X", "Track Displacement Y"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Displacement_Length", 
                        Data = new List<string>{"Track Displacement Length"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Duration", 
                        Data = new List<string>{"Track Duration"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Length", 
                        Data = new List<string>{"Track Length"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Speed_Max", 
                        Data = new List<string>{"Track Speed Max"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Speed_Mean", 
                        Data = new List<string>{"Track Speed Mean"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Speed_Min", 
                        Data = new List<string>{"Track Speed Min"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Speed_StdDev", 
                        Data = new List<string>{"Track Speed StdDev"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Speed_Variation", 
                        Data = new List<string>{"Track Speed Variation"}
                    },
                    new DataFileSpec
                    { 
                        FileSpec = "Track_Straightness", 
                        Data = new List<string>{"Track Straightness"}
                    },
                };
        }

        //public List<string> FileList
        //{
        //    get
        //    {
        //        return new List<string>()
        //        {
        //           "Track_Displacement",
        //           "Track_Displacement_Length",
        //           "Track_Duration",
        //           "Track_Length",
        //           "Track_Speed_Max",
        //           "Track_Speed_Mean",
        //           "Track_Speed_Min",
        //           "Track_Speed_StdDev",
        //           "Track_Speed_Variation",
        //           "Track_Straightness"
        //        };
        //    }
        //}

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
