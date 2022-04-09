using System;

namespace ImarisAddIn.Analyser
{
    public class TrackS
    {
        public string DisplacementX;
        public string DisplacementY;
        public string DisplacementLength;
        public string Duration;
        public string Length;
        public string SpeedMax;
        public string SpeedMean;
        public string SpeedMin;
        public string SpeedStdDev;
        public string SpeedVariation;
        public string Straighness;
        public string Index;

        public string ProjNumber;
        public string Date;
        public string Channel;
        public string StartImage;
        public string Lockstoff;
        public string Gelafundinkonzentration;
        public string Verduennung;
        public string StartOrt;
        public string Serum;
        public string Versuchsnummer;
        public string LA;
        public string LAKonz;
        public string Verwendbar;

        public TrackS(string index)
        {
            Index = index;
        }
    }
}
