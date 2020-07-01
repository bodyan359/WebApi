using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/all_mieszkania")]
    [ApiController]
    public class MieszkanieController : ControllerBase
    {
        private masterContext _context;
        public MieszkanieController(masterContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMieszkanie()
        {
            return Ok(_context.Ipbpr.ToList());
        }
        // api/4
        [HttpGet("api/{PrimaryID}")]
        public IActionResult GetMieszkanie(string PrimaryId)
        {
            var mieszkanie = _context.Ipbpr.FirstOrDefault(e => e.PrimaryId == PrimaryId);
            if (mieszkanie == null)
            {
                return NotFound();
            }
            return Ok(mieszkanie);
        }
        //category A B C D
        [HttpGet("category/{Kategory}")]
        public IActionResult GetKategory(string Kategory)
        {
            var mieszkanie = _context.Ipbpr.Where(e => e.Kategoria == Kategory);
            if (mieszkanie == null)
            {
                return NotFound();
            }
            return Ok(mieszkanie);
        }
        //4 PARAMETRA возвращает Буy0у
        // A  ot ceny 100   
        // B  ot ceny 200
        // C ot ceny 500
        // D        1000

        [HttpGet("price/{Cena}")]
        public IActionResult GetCategory(int Cena)
        {
            if (Cena < 200000)
            {
                return Ok("A");
            }
            if (Cena < 500000)
            {
                return Ok("B");
            }
            if (Cena < 1000000)
            {
                return Ok("C");
            }
            return Ok("D");

        }

        [HttpGet("Kod")]
        public IActionResult GetKey()
        {
            string randoms = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(8, 8);
            return Ok(randoms);
        }
    }
}