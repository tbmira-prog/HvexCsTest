using HvexTransformerReports.Models;
using HvexTransformerReports.Services;
using Microsoft.AspNetCore.Mvc;

namespace HvexTransformerReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransformersController : Controller
    {
        private readonly TransformersService _transformersService;

        public TransformersController(TransformersService transformerService) => _transformersService = transformerService;

        [HttpGet]
        public async Task<List<Transformer>> Get() => await _transformersService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Transformer>> Get(string id)
        {
            var transformer = await _transformersService.GetAsync(id);

            if (transformer is null)
            {
                return NotFound();
            }

            return transformer;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Transformer newTransformer)
        {
            await _transformersService.CreateAsync(newTransformer);

            return CreatedAtAction(nameof(Get), new { id = newTransformer.Id }, newTransformer);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Transformer updatedTransformer)
        {
            var transformer = await _transformersService.GetAsync(id);

            if (transformer is null)
            {
                return NotFound();
            }

            updatedTransformer.Id = transformer.Id;

            await _transformersService.UpdateAsync(id, updatedTransformer);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var transformer = await _transformersService.GetAsync(id);

            if (transformer is null)
            {
                return NotFound();
            }

            await _transformersService.RemoveAsync(id);

            return NoContent();
        }
    }
}
