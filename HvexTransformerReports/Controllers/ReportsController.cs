using HvexTransformerReports.Models;
using HvexTransformerReports.Services;
using Microsoft.AspNetCore.Mvc;

namespace HvexTransformerReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly ReportsService _reportsService;

        public ReportsController(ReportsService reportService) => _reportsService = reportService;

        [HttpGet]
        public async Task<List<Report>> Get() => await _reportsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Report>> Get(string id)
        {
            var report = await _reportsService.GetAsync(id);

            if (report is null)
            {
                return NotFound();
            }

            return report;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Report newReport)
        {
            await _reportsService.CreateAsync(newReport);

            return CreatedAtAction(nameof(Get), new { id = newReport.Id }, newReport);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Report updatedReport)
        {
            var report = await _reportsService.GetAsync(id);

            if (report is null)
            {
                return NotFound();
            }

            updatedReport.Id = report.Id;

            await _reportsService.UpdateAsync(id, updatedReport);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var report = await _reportsService.GetAsync(id);

            if (report is null)
            {
                return NotFound();
            }

            await _reportsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
