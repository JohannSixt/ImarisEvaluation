using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ImarisAddIn.Analyser
{
    public static class DataAnalyser
    {
        public static event EventHandler<string> Print;
        public static event EventHandler<string> PrintLine;

        public static void AnalyseData(string BaseFolder)
        {
            Dictionary<string, ExperimentS> Experiments = new Dictionary<string, ExperimentS>();
            DirectoryInfo[] Directories = (new DirectoryInfo(BaseFolder)).GetDirectories(Settings.Instance.ExperimentsFolderPrefix + "*");

            foreach (DirectoryInfo Directory in Directories)
            {
                ExperimentS Experiment = new ExperimentS(Directory.Name);
                Experiments.Add(Directory.Name, Experiment);

                foreach (DataFileSpec DataFileSpec in Settings.Instance.DataFileSpecs)
                {
                    if (Directory.GetDirectories("*" + Settings.Instance.MigrationStatisticsFolderSpec + "*").Count() > 0)
                    {
                        FileInfo[] StatisticFiles = Directory.GetDirectories("*" + Settings.Instance.MigrationStatisticsFolderSpec + "*")[0].GetFiles("*" + DataFileSpec.FileSpec + ".*");

                        if (StatisticFiles.Length > 0)
                        {
                            StreamReader Reader = new StreamReader(StatisticFiles[0].Open(FileMode.Open, FileAccess.Read));

                            OnPrint("reading " + StatisticFiles[0].FullName + " ... ");
                            bool HeaderFound = false;

                            int IDIndex = -1;
                            int IDComponentName = -1;

                            while (!Reader.EndOfStream)
                            {
                                string Line = Reader.ReadLine();

                                string ConcPattern = @"(.*)(cain\s*\d*,)(.*)";

                                if (Regex.IsMatch(Line, ConcPattern))
                                    Line = Regex.Matches(Line, ConcPattern)[0].Groups[1].Value + Regex.Matches(Line, ConcPattern)[0].Groups[2].Value.Replace(',', '.') + Regex.Matches(Line, ConcPattern)[0].Groups[3].Value;

                                List<string> Data = new List<string>(Line.Split(new char[] { ',' }));

                                if (Data.Count > 1 && !HeaderFound)
                                {
                                    HeaderFound = true;
                                    IDIndex = Data.IndexOf(Data.Where(x => x.Equals(Settings.Instance.IDColumn, StringComparison.InvariantCultureIgnoreCase)).First());
                                    IDComponentName = Data.IndexOf(Data.Where(x => x.Equals(Settings.Instance.ComponentNameColumn, StringComparison.InvariantCultureIgnoreCase)).First());
                                }
                                else if (HeaderFound)
                                {
                                    string Index = string.Empty;

                                    Index = Data[IDIndex];

                                    if (DataFileSpec.FileSpec.Equals("Track_Displacement"))
                                    {
                                        Experiment.GetTrack(Index).DisplacementX = Data[0];
                                        Experiment.GetTrack(Index).DisplacementY = Data[1];

                                        string[] ComponentData = Data[IDComponentName].Split(new char[] { ' ' });

                                        if (ComponentData.Length >= 1) Experiment.GetTrack(Index).ProjNumber = ComponentData[0];
                                        if (ComponentData.Length >= 2) Experiment.GetTrack(Index).Date = ComponentData[1];
                                        if (ComponentData.Length >= 3) Experiment.GetTrack(Index).Channel = ComponentData[2];
                                        if (ComponentData.Length >= 4) Experiment.GetTrack(Index).StartImage = ComponentData[3];
                                        if (ComponentData.Length >= 5) Experiment.GetTrack(Index).Lockstoff = ComponentData[4];
                                        if (ComponentData.Length >= 6) Experiment.GetTrack(Index).Gelafundinkonzentration = ComponentData[5];
                                        if (ComponentData.Length >= 7) Experiment.GetTrack(Index).Verduennung = ComponentData[6];
                                        if (ComponentData.Length >= 8) Experiment.GetTrack(Index).StartOrt = ComponentData[7];
                                        if (ComponentData.Length >= 9) Experiment.GetTrack(Index).Serum = ComponentData[8];
                                        if (ComponentData.Length >= 10) Experiment.GetTrack(Index).Versuchsnummer = ComponentData[9];
                                        if (ComponentData.Length >= 10) Experiment.GetTrack(Index).LA = ComponentData[10];
                                        if (ComponentData.Length >= 12) Experiment.GetTrack(Index).LAKonz = ComponentData[11];
                                        if (ComponentData.Length >= 13) Experiment.GetTrack(Index).Verwendbar = ComponentData[12];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Displacement_Length"))
                                    {
                                        Experiment.GetTrack(Index).DisplacementLength = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Duration"))
                                    {
                                        Experiment.GetTrack(Index).Duration = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Length"))
                                    {
                                        Experiment.GetTrack(Index).Length = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Speed_Max"))
                                    {
                                        Experiment.GetTrack(Index).SpeedMax = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Speed_Mean"))
                                    {
                                        Experiment.GetTrack(Index).SpeedMean = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Speed_Min"))
                                    {
                                        Experiment.GetTrack(Index).SpeedMin = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Speed_StdDev"))
                                    {
                                        Experiment.GetTrack(Index).SpeedStdDev = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Speed_Variation"))
                                    {
                                        Experiment.GetTrack(Index).SpeedVariation = Data[0];
                                    }

                                    else if (DataFileSpec.FileSpec.Equals("Track_Straightness"))
                                    {
                                        Experiment.GetTrack(Index).Straighness = Data[0];
                                    }
                                }
                            }

                            Reader.Close();
                            OnPrintLine("done");
                        }
                    }
                }
            }

            OnPrint("writing Result.csv ... ");

            if (!BaseFolder.EndsWith(@"\"))
                BaseFolder += @"\";

            string OutputFile = BaseFolder + "Result.csv";

            if (File.Exists(OutputFile))
            {
                File.Copy(OutputFile, OutputFile + ".save." + DateTime.Now.ToString("yyyyMMddHHmmss"));
                File.Delete(OutputFile);
            }

            StreamWriter Writer = new StreamWriter(BaseFolder + "Result.csv", false);

            string CSVPattern = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25}";

            Writer.WriteLine(string.Format(CSVPattern,
                "Track Displacement X", "Track Displacement Y", "Track Displacement Length", "Track Duration",
                "Track Length", "Track Speed Max", "Track Speed Mean", "Track Speed Min",
                "Track Speed StdDev", "Track Speed Variation", "Track Straightness", "ID", "Data Folder",
                "Projnummer", "Datum", "Kanal", "Startbild", "Lockstoff", "Gelafundinkonzentration", "Verduennung",
                "Startort der nG", "Serum", "Versuchsnummer", "LA", "LA Konz. [mmol/L]", "verwendbar"
                ));

            foreach (ExperimentS Experiment in Experiments.Values)
            {
                foreach (TrackS Track in Experiment.TrackList.Values)
                {
                    Writer.WriteLine(string.Format(CSVPattern, Track.DisplacementX, Track.DisplacementY, Track.DisplacementLength, Track.Duration,
                       Track.Length, Track.SpeedMax, Track.SpeedMean, Track.SpeedMin,
                       Track.SpeedStdDev, Track.SpeedVariation, Track.Straighness, Track.Index, Experiment.Tag,
                       Track.ProjNumber, Track.Date, Track.Channel, Track.StartImage, Track.Lockstoff, Track.Gelafundinkonzentration, Track.Verduennung,
                       Track.StartOrt, Track.Serum, Track.Versuchsnummer, Track.LA, Track.LAKonz, Track.Verwendbar));
                }
            }

            Writer.Close();
            OnPrintLine("done");

            Settings.Instance.Save();

#if DEBUG
            Console.WriteLine("press any key ...");
            Console.ReadKey();
#endif
        }

        static void OnPrint(string Data)
        {
            if (Print != null)
                Print(null, Data);
        }

        static void OnPrintLine(string Data)
        {
            if (PrintLine != null)
                PrintLine(null, Data);
        }

    }
}
