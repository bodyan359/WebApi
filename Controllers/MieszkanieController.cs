using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
       // api/emps/4
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
        [HttpGet("cena/500000")]
        public IActionResult GetMieszkanie(int Cena)
        {
            var mieszkanie = _context.Ipbpr.FirstOrDefault(e => e.Cenam > 50000);
            if (mieszkanie == null)
            {
                return NotFound();
            }
            return Ok(mieszkanie);
        }
    }
}