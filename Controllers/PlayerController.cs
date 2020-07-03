using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pillar.Models;
using Pillar.DataContext;

namespace Pillar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private PlayerContext playerContext;

        public PlayerController(ILogger<PlayerController> logger, PlayerContext playerContext)
        {
            _logger = logger;
            this.playerContext = playerContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return Ok(playerContext.Players);
        }

        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Player player)
        {
            try
            {
                if (player == null || ModelState.IsValid == false)
                {
                    return BadRequest();
                }

                this.playerContext.Add(player);

                if(this.playerContext.SaveChanges() == 0)
                {
                    return StatusCode(500, "Unable to save player");
                }

                return CreatedAtRoute("Get", new { playerId = player.ID }, player);
            }
            catch(Exception ex)
            {
                string exception = ex.Message;
                return null;
            }

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Player player)
        {

        }

        [HttpDelete("{id}")]
        public void Delete (int id)
        {

        }
    }
}