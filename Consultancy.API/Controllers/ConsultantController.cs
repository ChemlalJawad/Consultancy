using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultancy.API.ViewModels.Consultant;
using Consultancy.Core.Domains;
using Consultancy.Service.Consultant;
using Consultancy.Service.Mission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultancy.API.Controllers
{
    [Route("api/consultants")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly IMapper _mapper;

        public ConsultantController(IConsultantService consultantService, IMapper mapper)
        {
            _consultantService = consultantService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Consultant>> GetAll()
        {
            var consultants = _consultantService.GetAll();

            return Ok(consultants);
        }

        [HttpGet("{id}")]
        public ActionResult<Consultant> GetById([FromRoute] int id)
        {
            var consultant = _consultantService.HistoryMissions(id);
            var consultantModel = _mapper.Map<HistoryConsultantProfile>(consultant);
            return Ok(consultantModel);
        }
    }
}
