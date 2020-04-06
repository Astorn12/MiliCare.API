using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiliCare.Data;
using MiliCare.Model;

namespace MiliCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class SensorController : ControllerBase
    {
        private readonly DataContext _context;

        public SensorController(DataContext context)
        {
            _context = context;
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
            
            return Ok(await _context.SensorMeasurments.Where(x=>x.UserId==userId & x.SensorId==sensorId).Take(10).ToListAsync());
        }
    }
}               