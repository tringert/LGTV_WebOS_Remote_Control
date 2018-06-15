using System;
using System.Collections.Generic;

namespace LgTvController
{
    internal class ProgramList
    {
        internal List<ProgramListItem> programList = new List<ProgramListItem>();

        public void Load(ProgramListItem pl)
        {
            pl.Percent = CalculateTimePercentage(pl);
            pl.StartTime = pl.LocalStartDateTime.ToString("HH:mm");
            pl.EndTime = pl.LocalEndDateTime.ToString("HH:mm");
            pl.DurationMin = pl.Duration / 60;

            programList.Add(pl);
        }

        private ushort CalculateTimePercentage(ProgramListItem pl)
        {
            if (pl.LocalStartDateTime < DateTime.Now && pl.LocalEndDateTime > DateTime.Now)
            {
                double num = 100 - (100 * (1 - ((DateTime.Now - pl.LocalStartDateTime).TotalSeconds / (pl.LocalEndDateTime - pl.LocalStartDateTime).TotalSeconds)));
                return ((ushort)Math.Round(num));
            }
            
            return 0;
        }
    }
}
