using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/1")]
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
        [HttpGet("PrimaryId:nchar")]
        public IActionResult GetMieszkanie(string PrimaryId)
        {
            var mieszkanie = _context.Ipbpr.FirstOrDefault(e => e.PrimaryId == PrimaryId);
            if (mieszkanie == null)
            {
                return NotFound();
            }
            return Ok(mieszkanie);
        }
    }
}