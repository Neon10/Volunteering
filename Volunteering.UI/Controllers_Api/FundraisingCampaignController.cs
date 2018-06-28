using System.Collections.Generic;
using System.Web.Http;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Dtos;
using Volunteering.Service;
using Volunteering.Service.Identity;
using Microsoft.AspNet.Identity;

namespace Volunteering.UI.Controllers_Api
{
    [RoutePrefix("api/Campaign")]
    public class FundraisingCampaignController : ApiController
    {

        private readonly FundraisingCampaignService campaignDtos = new FundraisingCampaignService();
        private readonly UserService us = new UserService();


        [Route("GetAllCampaigns")]
        // GET: api/FundraisingCampaign
        public IEnumerable<FundraisingCampaignDto> GetAllCampaigns()
        {

           List <FundraisingCampaignDto> campaignDtos = new List<FundraisingCampaignDto>();

            foreach (FundraisingCampaign f in this.campaignDtos.QueryCampaigns())
            {
                f.OwnerNgo = us.UserManager.FindById(f.OwnerNgoId) as Ngo;
                FundraisingCampaignDto fdto = new FundraisingCampaignDto();

                fdto.CampaignId = f.CampaignId;
                fdto.Name = f.Name;
                fdto.Description = f.Description ;
                fdto.StartDate = f.StartDate ;
                fdto.EndDate = f.EndDate ;
                fdto.TargetAmount = f.TargetAmount ;

                fdto.OwnerNgo = new UserDto {
                  Id = f.OwnerNgoId,
                  Name= f.OwnerNgo.Name,
                  Email= f.OwnerNgo.Email,
                  Role="Ngo",
                  PhoneNumber= "23232323" 
                };

                campaignDtos.Add(fdto);
            }

            return campaignDtos;
        }

        // GET: api/FundraisingCampaign/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FundraisingCampaign
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FundraisingCampaign/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FundraisingCampaign/5
        public void Delete(int id)
        {
        }
    }
}
