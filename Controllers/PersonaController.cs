using interciclolituma.Entities;
using interciclolituma.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interciclolituma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        public readonly Datacontext _datacontex;
        public PersonaController(Datacontext datacontext)
        {
            _datacontex = datacontext;
        }

        [HttpGet("auth/{username}/{password}")]
        public async Task<ActionResult> obtener_LoginAsync(string username, string password)
        {
            try
            {
                persona per = await _datacontex.persona.FirstOrDefaultAsync(x => x.user_p == username && x.password == password);
                if (per != null)
                {
                    return Ok(per);
                }
                else
                {
                    return BadRequest("no existe el usuario");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error por: {ex.Message}");
            }
        }

        [HttpGet("alluser")]
        public async Task<ActionResult> obtener_todos()
        {
            try
            {
                List<persona> per = await _datacontex.persona.ToListAsync();
                if (per != null && per.Count >0)
                {
                    return Ok(per);
                }
                else
                {
                    return BadRequest("no existe el usuario");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error por: {ex.Message}");
            }
        }
    }
}
