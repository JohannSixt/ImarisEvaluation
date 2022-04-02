using System.Collections.Generic;

namespace Analyser
{
    public static class Files
    {
        public static List<string> FileList
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
    }
}
