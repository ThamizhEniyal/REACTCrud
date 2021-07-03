using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REACTCrud.Models.Shared
{
    public class SharedVM
    {
    }

    public class CountryListVM
    {
        public List<string> Countries { get; set; }
    }

    public class CountryResponseVM
    {
        public string Type { get; set; }
        public List<string> Parameters { get; set; }
        public List<string> Errors { get; set; }
        public string Result { get; set; }

        public List<string> Response { get; set; }
    }

    public class StatisticsResponseVM
    {
        public string Type { get; set; }
        public List<string> Parameters { get; set; }
        public List<string> Errors { get; set; }
        public string Result { get; set; }

        public List<StatisticsVM> Response { get; set; }
    }


    public class CaseVM
        {
           public string New { get; set; }
           public string Active { get; set; }
           public string Critical { get; set; }
           public string Recovered { get; set; }
           public string Pop { get; set; }
           public string Total { get; set; }
           }
    public class DeathVM
    {

        public string Pop { get; set; }
        public string Total { get; set; }
    }
    public class TestVM
    {
        public string Pop { get; set; }
        public string Total { get; set; }
    }

    public class StatisticsVM
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Population { get; set; }
        public CaseVM Cases { get; set; }
        public DeathVM Deaths { get; set; }
        public TestVM Tests { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }
}
      

