﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {
            var users = await context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null) return NotFound();
            
            return user;
        }
    }
}
