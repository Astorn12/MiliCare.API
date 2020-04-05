using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiliCare.Data;

namespace MiliCare.Controllers
{
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

        [HttpGet("userHistory/{userId}/{sensorId}")]
        public async Task<IActionResult> GetUserHistory(int userId, int sensorId){
            return Ok(await _context.SensorMeasurments.Where(x=>x.UserId==userId & x.SensorId==sensorId).Take(10).ToListAsync());
        }
    }
}               