using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Post([FromBody]Canal user)
        {
            try
            {
                _canalRepository.Insert(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Canal user)
        {
            try
            {
                _canalRepository.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public Canal GetById(int id)
        {
            var user = _canalRepository.SelectById(id);
            return user;
        }



    }
}