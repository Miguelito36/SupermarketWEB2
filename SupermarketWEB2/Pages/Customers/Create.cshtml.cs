using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB2.Data;
using SupermarketWEB2.Models;

namespace SupermarketWEB2.Pages.Customers
{
    public class CreateModel : PageModel
    {
		private readonly SupermarketContext _context;

		public CreateModel(SupermarketContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Costumers Customer { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Categories == null || Costumers == null)
			{
				var errors = ModelState.Values.SelectMany(m => m.Errors);
				foreach (var error in errors)
				{
					Console.WriteLine(error.ErrorMessage);
				}
				return Page();
			}

			_context.Customers.Add(Costumers);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
