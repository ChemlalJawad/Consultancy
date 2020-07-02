using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultancy.API.ViewModels.Mission;
using Consultancy.Core.Domains;
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
        public ActionResult<List<Mission>> GetMissions()
        {
            var missions = _missionService.GetMissions();

            var missionProfile = new List<MissionProfile>();
            foreach (var mission in missions)
            {
                foreach (var x in mission.ConsultantMissions)
                {
                    if (x.isActive)
                    {
                        missionProfile.Add(new MissionProfile
                        {
                            Consultants = new List<ConsultantProfile> {
                                 new ConsultantProfile()
                                 {
                                     Rate = x.Rate,
                                     Experience = x.Consultant.Experience,
                                     Firstname = x.Consultant.Firstname,
                                     Lastname = x.Consultant.Lastname,
                                     JobName = x.JobName
                                 }
                        }});
                    }
                }
            }
            var missionModel = new GetMissionsProfile()
            {
                Missions = _mapper.Map<List<MissionProfile>>(missionProfile)
            };
            return Ok(missionModel);
        } 
        
        [HttpPost]
        [Route("{missionId}/consultants")]
        public ActionResult AddConsultant([FromRoute] int missionId, [FromBody] AddConsultant consultant)
        {
            consultant.MissionId = missionId;
            var consultantMission = _missionService.AddConsultant(consultant);

            return Ok(consultantMission);
        }

    }
}
