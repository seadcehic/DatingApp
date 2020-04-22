
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatinApp.API.Data;
using DatinApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            //var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            //// var users = JsonConvert.DeserializeObject<List<User>>(userData);

            //List<User> UserList = JsonConvert.DeserializeObject<List<User>>(userData);
            //foreach (var user in UserList)
            //{
            //    byte[] passwordHash, passwordSalt;
            //    CreatePasswordHash("password", out passwordHash, out passwordSalt);

            //    user.PasswordHash = passwordHash;
            //    user.PasswordSalt = passwordSalt;
            //    user.Username = user.Username.ToLower();
            //    _context.Users.Add(user);
            //}
            //_context.SaveChanges();
            var values =await  _context.Values.ToListAsync();
           return Ok(values);   
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var value = await _context.Values.FirstOrDefaultAsync(x=>x.Id==id);
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
