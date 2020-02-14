using System;
using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace GloboChat.Servicos.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanalController : ControllerBase
    {
        public readonly ICanalRepository _canalRepository;
        public CanalController(ICanalRepository canalRepository)
        {
            _canalRepository = canalRepository;
        }


        [HttpPost]
        public IActionResult Post([FromBody]Canal canal)
        {
            try
            {
                _canalRepository.Insert(canal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Canal canal)
        {
            try
            {
                _canalRepository.Update(canal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var canal = _canalRepository.SelectById(id);
            if (canal == null)
                return Ok(canal);
            else
                return NotFound(canal);
        }



    }
}