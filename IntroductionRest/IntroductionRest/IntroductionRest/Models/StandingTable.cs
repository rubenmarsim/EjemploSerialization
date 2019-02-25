using System.Collections.Generic;

namespace IntroductionRest.Models
{
    public class StandingTable
    {
        public string Season { get; set; }
        public List<StandingList> StandingsLists { get; set; }
    }
}
