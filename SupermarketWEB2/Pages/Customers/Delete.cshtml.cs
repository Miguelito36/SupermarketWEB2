using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB2.Data;

namespace SupermarketWEB2.Pages.Customers
{
    public class DeleteModel : PageModel
    {
		private readonly SupermarketContext _context;

		public DeleteModel(SupermarketContext context)
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

			var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

			if (customer == null)
			{
				return NotFound();
			}
			else
			{
				Customer = customer;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Customers == null)
			{
				return NotFound();
			}
			var customer = await _context.Customers.FindAsync(id);

			if (customer != null)
			{
				Customer = customer;
				_context.Customers.Remove(customer);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
