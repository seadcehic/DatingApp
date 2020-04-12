
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatinApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatinApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }
        // GET: api/student
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
           var values =await  _context.Value.ToListAsync();
           return Ok(values);   
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var value = await _context.Value.FirstOrDefaultAsync(x=>x.Id==id);
          return Ok(value);
        }

        // POST: api/student
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
