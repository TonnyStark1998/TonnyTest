using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TonnyTest.Models;


namespace TonnyTest.Controllers
{
    [EnableCors("mypolicy")]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly AppDbContext context;
        public PersonController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Tb_PersonasFisicas> Get()
        {
            return context.Tb_PersonasFisicas.ToList();
        }
        [HttpGet("{nombre}")]
        public Tb_PersonasFisicas Get(string nombre)
        {
            return context.Tb_PersonasFisicas.FirstOrDefault(p => p.Nombre == nombre);
        }
        [DisableCors]
        [HttpPost]
        public ActionResult Post([FromBody]Tb_PersonasFisicas tb_PersonasFisicas)
        {
            try
            {
                context.Tb_PersonasFisicas.Add(tb_PersonasFisicas);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Tb_PersonasFisicas td_PersonasFisicas)
        {
            if (td_PersonasFisicas.IdPersonaFisica == id)
            {
                context.Entry(td_PersonasFisicas).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var td_PersonasFisicas = context.Tb_PersonasFisicas.FirstOrDefault(p => p.IdPersonaFisica == id);
            if (td_PersonasFisicas != null)
            {
                context.Tb_PersonasFisicas.Remove(td_PersonasFisicas);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
