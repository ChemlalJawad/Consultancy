using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultancy.API.ViewModels.Mission;
using Consultancy.Core.Domain;
using Consultancy.Service.Mission;
using Consultancy.Service.Mission.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultancy.API.Controllers
{
    [Route("api/missions")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;
        private readonly IMapper _mapper;

        public MissionController(IMissionService missionService, IMapper mapper)
        {
            _missionService = missionService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetMissionsProfile>> GetMissions()
        {
            var missions = _missionService.GetMissions();
            
            foreach(var item in missions.ToList()) 
            {
                item.ConsultantMissions = item.ConsultantMissions.Where(e => e.IsActive).ToList();
            }
            var missionModel = new GetMissionsProfile()
            {
                Missions = _mapper.Map<List<MissionProfile>>(missions)
            };

            return Ok(missionModel);
        } 
        
        [HttpPost]
        [Route("{missionId}/consultants")]
        public ActionResult AddConsultant([FromRoute] int missionId, [FromBody] AddConsultantRequest consultant)
        {
            consultant.MissionId = missionId;
            var consultantMissionModel = _missionService.AddConsultant(consultant);

            return Ok(consultantMissionModel);
        }

    }
}
