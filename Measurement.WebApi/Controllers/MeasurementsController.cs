#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Measurement.WebApi.Data;

namespace Measurement.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : Controller
    {
        private readonly MeasurementWebApiContext _context;

        public MeasurementsController(MeasurementWebApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Measurement.ToListAsync());
        }
    }
}
