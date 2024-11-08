using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB2.Data;

namespace SupermarketWEB2.Pages.Customers
{
	[Authorize]
    public class IndexModel : PageModel
    {
		private readonly SupermarketContext _context;

		public IndexModel(SupermarketContext context)
		{
			_context = context;
		}

		public IList<Customers> Costumers { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Customers != null)
			{
				Costumers = await _context.Customers.ToListAsync();
			}
		}
	}
}
