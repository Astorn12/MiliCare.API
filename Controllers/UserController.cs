using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiliCare.Data;
using MiliCare.DTOs;
using MiliCare.Model;

namespace MiliCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
      
        private DataContext _context;
        private readonly IMapper _mapper;
        public UserController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Users.Where(x => true).ToListAsync());
        }
        [HttpPost("add")]
        public async Task<IActionResult> Post(UserForRegisterDto userForRegisterDto)
        {
            var newUser=_mapper.Map<User>(userForRegisterDto);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok(200);
        }

        [HttpPost("addmeasurement")]
        public async Task<IActionResult> AddUserSensorMeasurment(SensorMeasurmenToAddDto mea){
            var v= _mapper.Map<SensorMeasurment>(mea);
            v.Date=DateTime.Now;
            await _context.AddAsync(v);
            await  _context.SaveChangesAsync();
            return Ok(await _context.AddAsync(v));
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test(){
            return Ok( new List<User>{
                new User(){
                    Id=1,
                    Name="Słoń",
                    Surname="Trąbalski"
                },
                new User(){
                    Id=2,
                    Name="Kaczka",
                    Surname="Dziwaczka"
                }
            });
        }
    }
}