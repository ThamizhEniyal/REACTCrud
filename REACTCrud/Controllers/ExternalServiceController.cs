using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REACTCrud.Interface;
using REACTCrud.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace REACTCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalServiceController : ControllerBase
    {
        private readonly IGeneralnjection _generalInjection;
        private readonly ClaimsPrincipal _caller;
        private readonly HttpContext httpContext;


        public ExternalServiceController(IHttpContextAccessor httpContextAccessor, IGeneralnjection generalnjection)
        {
            _caller = httpContextAccessor.HttpContext.User;
            httpContext = httpContextAccessor.HttpContext;
            _generalInjection = generalnjection;
        }
        // GET api/GetAllProducts

        [Route("GetCountries")]
        public async Task<List<string>> GetCountries()
        {
            Claim claim = _caller.Claims.FirstOrDefault();

          return await _generalInjection.GetCountryData();

           
        }
        [Route("GetStatistics")]
        public async Task<List<StatisticsVM>> GetStatistics()
        {
            Claim claim = _caller.Claims.FirstOrDefault();

            return await _generalInjection.GetStatistics();


        }

    }
}
