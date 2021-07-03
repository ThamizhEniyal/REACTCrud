using Microsoft.AspNetCore.Mvc;
using REACTCrud.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace REACTCrud.Interface
{
    public interface IGeneralnjection
    {

        public Task<List<string>> GetCountryData();
        public Task<List<StatisticsVM>> GetStatistics();
    }
}
