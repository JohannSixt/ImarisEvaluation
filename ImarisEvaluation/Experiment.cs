using ImarisAddIn.Analyser;
using System;
using System.Collections.Generic;

namespace ImarisAddIn.Analyser
{
    public class ExperimentS
    {
        public Dictionary<string, TrackS> TrackList;
        public string Tag;

        public ExperimentS(string tag)
        {
            Tag = tag;
            TrackList = new Dictionary<string, TrackS>();
        }

        public TrackS GetTrack(string Index)
        {
            if (!TrackList.ContainsKey(Index))
                TrackList.Add(Index, new TrackS(Index));

            return TrackList[Index];
        }
    }

}
