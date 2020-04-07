using System.Collections.Generic;
using System.Linq;
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
    public class SensorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SensorController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 

        [HttpGet] 
        public async Task<IActionResult> Get(){
            return Ok(await _context.Sensors.Where(x=>true).ToListAsync());
        }

        [HttpPost("add/{name}")]
        public async Task<IActionResult> AddSensor( string name){
            Sensor sensor= new Sensor();
            sensor.Name=name;
            await _context.Sensors.AddAsync(sensor);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("userHistory/{userId}/{sensorId}")]
        public async Task<IActionResult> GetUserHistory(int userId, int sensorId){
            var measurnentList=await _context.SensorMeasurments.Where(x=>x.UserId==userId & x.SensorId==sensorId).OrderByDescending(x=>x.Date).Take(10).ToListAsync();
            var measurmentToReturnList=_mapper.Map<List<SensorMeasurment>,List<SensorMeasurmentToReturnDto>>(measurnentList);
            return Ok(measurmentToReturnList);
        }
    }
}               