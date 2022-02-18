using System.Threading.Tasks;
using PubgTournament.Models;
using PubgTournament.Store;
using Microsoft.AspNetCore.Mvc;
using System.IO;
 using System;
 using  Newtonsoft.Json;


namespace PubgTournament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : BaseApiController
    {
        private readonly IStore<Group> _store;
        [JsonConstructorAttribute]
        public GroupController(IStore<Group> store)
        {
            _store = store;
        }
        // [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(Group model)
        {
            model.Id =  Guid.NewGuid().ToString();
            await _store.InsertOneAsync(model);
            return Ok(CreateSuccessResponse("Created successfully"));
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(Group model)
        {
            await _store.ReplaceOneAsync(model);
            return Ok(CreateSuccessResponse("Updated successfully"));
        }
        // [Authorize]
       [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = _store.FilterBy(x=>true);
            return Ok(CreateSuccessResponse(response));
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
