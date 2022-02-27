using System.Threading.Tasks;
using PubgTournament.Models;
using PubgTournament.Store;
using Microsoft.AspNetCore.Mvc;
using System.IO;
 using System;
 using  Newtonsoft.Json;
 using System.Collections.Generic;


namespace PubgTournament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemSettingController : BaseApiController
    {
        private readonly IStore<SystemSetting> _store;
        [JsonConstructorAttribute]
        public SystemSettingController(IStore<SystemSetting> store)
        {
            _store = store;
        }
        // [Authorize]
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> AddAsync(SystemSetting model)
        {
            var result = await _store.FindOneAsync(x=>true);
            if (result!=null)
            {
                var item = result;
                item.AliveCounterBgImage = model.AliveCounterBgImage;
                item.DominationBgImage = model.DominationBgImage;
                item.EliminatedBgImage = model.EliminatedBgImage;
                item.PrimaryColor = model.PrimaryColor;
                item.SecondaryColor = model.SecondaryColor;
                item.AliveColor = model.AliveColor;
                item.DeadColor = model.DeadColor;

                await _store.ReplaceOneAsync(item);
            }
            else
            {
                await _store.InsertOneAsync(model);
            }
            
            return Ok(CreateSuccessResponse("Updated successfully"));
            
        }

     
        // [Authorize]
       [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _store.FindOneAsync(x=>true);
            return Ok(CreateSuccessResponse(result));
        }
        // [Authorize]
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetAsync( [FromRoute] string Id)
        {
            var response = await _store.FindByIdAsync(Id);
            return Ok(CreateSuccessResponse(response));
        }
        // [Authorize]
 
        // [Route("get-by-user/{userId}")]
        // public async Task<IActionResult> GetByUserAsync( [FromRoute] string userId)
        // {
        //     var response = await _store.GetByUserAsync( userId);
        //     return Ok(CreateSuccessResponse(response));
        // }
        // [Authorize]
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _store.DeleteById(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
