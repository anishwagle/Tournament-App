using System.Threading.Tasks;
using PubgTournament.Models;
using PubgTournament.Store;
using Microsoft.AspNetCore.Mvc;
using System.IO;
 using System;
 using MongoDB.Driver;
  using Microsoft.Extensions.Options;
 using System.Collections.Generic;
 using  Newtonsoft.Json;
using System.Linq.Expressions;
using System.Linq;

namespace PubgTournament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : BaseApiController
    {
        private readonly IStore<Team> _store;
        private readonly IStore<Player> _playerStore;
        [JsonConstructorAttribute]
        public TeamController(IStore<Team> store, IStore<Player> playerStore)
        {
            _store = store;
            _playerStore = playerStore;
        }
        // [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody]Team model)
        {
            try{
            // if (Request?.Form?.Files?.Count > 0)
            // {
            //     var file = Request.Form.Files[0];
            //     using (var ms = new MemoryStream())
            //     {
            //         file.CopyTo(ms);
            //         var fileBytes = ms.ToArray();
            //         string s = Convert.ToBase64String(fileBytes);
            //         model.TeamLogo = fileBytes;
            //     }

            // }
            foreach (var item in model.Players){
                item.Id =  Guid.NewGuid().ToString();
                await _playerStore.InsertOneAsync(item);
            }
            // await _playerStore.InsertManyAsync(model.Players);
            model.Id =  Guid.NewGuid().ToString();
            await _store.InsertOneAsync(model);
            
            return Ok(CreateSuccessResponse("Created successfully"));
            }catch(Exception e){
                return Ok(CreateErrorResponse(e.Message));
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(Team model)
        {
            await _store.ReplaceOneAsync(model);
            return Ok(CreateSuccessResponse("Updated successfully"));
        }
        // [Authorize]
       [HttpGet]
        [Route("get-all")]
        public IActionResult GetAsync()
        {
            var response =  _store.FilterBy(x=>true);
            return Ok(CreateSuccessResponse(response));
        }
        // [Authorize]
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync( [FromRoute] string Id)
        {
            var response = await _store.FindByIdAsync(Id);
            return Ok(CreateSuccessResponse(response));
        }
    
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _store.DeleteById(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
