using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Pillar.Server.Models;
using Pillar.Server.DataContext.Repository;
using Pillar.Server.Dto;

namespace Pillar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> logger;
        private IPlayerRepository playerRepository;

        private IMapper mapper;

        public PlayerController(ILogger<PlayerController> logger, IPlayerRepository playerRepository, IMapper mapper)
        {
            this.logger = logger;
            this.playerRepository = playerRepository;
            this.mapper =  mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return Ok(playerRepository.GetAll().OrderBy(p => p.ID).ToList());
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public ActionResult<Player> Get(int id)
        {
            return Ok(playerRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlayerCreateDto playerCreateDto)
        {
            if (playerCreateDto == null || ModelState.IsValid == false)
            {
                return BadRequest();
            }   

            var savedPlayer = mapper.Map<Player>(playerCreateDto);

            playerRepository.Create(savedPlayer);
            
            if (playerRepository.Save() == false)
            {
                return StatusCode(500, "Unable to Save Player");
            }

            return CreatedAtRoute("GetPlayer", new { savedPlayer.ID }, savedPlayer);;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlayerUpdateDto playerUpdateDto)
        {
            if (playerUpdateDto == null || ModelState.IsValid == false)
            {
                return BadRequest();
            }

            if (playerRepository.Exists(id) == false)
            {
                return NotFound();
            }

            Models.Player playerToUpdate = playerRepository.Get(id);

            if (playerToUpdate == null)
            {
                return NotFound();
            }

            mapper.Map(playerUpdateDto, playerToUpdate);

            if (!playerRepository.Save())
            {
                return StatusCode(500, "A problem occured");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            if (playerRepository.Exists(id) == false)
            {
                return NotFound();
            }

            Models.Player playerToDelete = playerRepository.Get(id);

            if (playerToDelete == null)
            {
                return NotFound();
            }

            playerRepository.Delete(playerToDelete);

            if (!playerRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}