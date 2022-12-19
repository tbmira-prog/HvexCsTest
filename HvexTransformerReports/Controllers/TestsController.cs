using HvexTransformerReports.Models;
using HvexTransformerReports.Services;
using Microsoft.AspNetCore.Mvc;

namespace HvexTransformerReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : Controller
    {
        private readonly TestsService _testsService;

        public TestsController(TestsService testService) => _testsService = testService;

        [HttpGet]
        public async Task<List<Test>> Get() => await _testsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Test>> Get(string id)
        {
            var test = await _testsService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Test newTest)
        {
            await _testsService.CreateAsync(newTest);

            return CreatedAtAction(nameof(Get), new { id = newTest.Id }, newTest);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Test updatedTest)
        {
            var test = await _testsService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            updatedTest.Id = test.Id;

            await _testsService.UpdateAsync(id, updatedTest);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var test = await _testsService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            await _testsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
