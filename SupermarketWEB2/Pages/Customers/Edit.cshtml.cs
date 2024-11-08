using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB2.Data;

namespace SupermarketWEB2.Pages.Customers
{
    public class EditModel : PageModel
    {
		private readonly SupermarketContext _context;
		public EditModel(SupermarketContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Costumers Customer { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Customers == null)
			{
				return NotFound();
			}
			var customers = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
			if (customers == null)
			{
				return NotFound();
			}
			Customer = Customer;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(Customer).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CustomersExists(Customer.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");
		}
		private bool CustomersExists(int id)
		{
			return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
