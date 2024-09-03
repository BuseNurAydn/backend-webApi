using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaxDefinitionController : ControllerBase
    {
        private readonly TaxDefinitionDbContext _context;

        public TaxDefinitionController(TaxDefinitionDbContext context)
        {
            _context = context;
        }

     

        //Tüm kategorileri listelemek için 
        // GET: api/taxdefinition
        [HttpGet]   //get isteği
        public async Task<ActionResult<IEnumerable<TaxDefinition>>> GetTaxDefinitions()
        {
            return await _context.TaxDefinitions.ToListAsync();
        }

        //Belirli bir kategoriye ait bilgileri almak için kullanılır
        // GET: api/taxdefinition/2
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxDefinition>> GetTaxDefinition(int id)
        {
            var tax = await _context.TaxDefinitions.FindAsync(id);

            if (tax == null)
            {
                return NotFound();
            }

            return tax;
        }
        //Yeni kategori eklemek için
        // POST: api/taxdefinition
        [HttpPost]  //post isteği
        public async Task<ActionResult<TaxDefinition>> PostTaxDefinition(TaxDefinition taxDefinition) //TaxDefinition nesnesi
        {
            _context.TaxDefinitions.Add(taxDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxDefinition", new { id = taxDefinition.Id }, taxDefinition);
        }

        //Kategoriyi güncellemek için 
        // PUT: api/taxdefinition/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxDefinition(int id, TaxDefinition taxDefinition)
        {
            taxDefinition.Id = id;

            _context.Entry(taxDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxDefinitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //Belirli kategoriyi silmek için
        // DELETE: api/taxdefinition/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxDefinition(int id)
        {
            var tax = await _context.TaxDefinitions.FindAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            _context.TaxDefinitions.Remove(tax);
            await _context.SaveChangesAsync();//veritabanına işlemek için

            return NoContent();
        }

        //Kategori veritabanında var mı yok mu kontrolünü yapmak için
        private bool TaxDefinitionExists(int id)
        {
            return _context.TaxDefinitions.Any(e => e.Id == id);
        }

        //Filtreleme işlemi 
        [HttpGet("filter")]
        public async Task<IActionResult> FilterTaxDefinitions([FromQuery] string? firstName, [FromQuery] string? legalTaxCode, [FromQuery] decimal? ratio)
        {
            var query = _context.TaxDefinitions.AsQueryable();

            // FirstName'e göre filtreleme
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(td => td.FirstName.Contains(firstName));
            }

            // LegalTaxCode'a göre filtreleme
            if (!string.IsNullOrEmpty(legalTaxCode))
            {
                query = query.Where(td => td.LegalTaxCode.Contains(legalTaxCode));
            }

            // Ratio'ya göre filtreleme
            if (ratio.HasValue)
            {
                query = query.Where(td => td.Ratio == ratio.Value);
            }

            var filteredTaxDefinitions = await query.ToListAsync();
            return Ok(filteredTaxDefinitions);
        }

    }


}

