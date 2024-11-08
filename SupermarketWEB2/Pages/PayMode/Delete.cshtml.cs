using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB2.Data;

namespace SupermarketWEB2.Pages.PayMode
{
    public class DeleteModel : PageModel
    {
            private readonly SupermarketContext _context;

            public DeleteModel(SupermarketContext context)
            {
                _context = context;
            }

            [BindProperty]
            public PayMode PayMode { get; set; } = default!;

            public async Task<IActionResult> OnGetAsync(int id)
            {
                PayMode = await _context.PayModes.FindAsync(id);

                if (PayMode == null)
                {
                    return NotFound();
                }
                return Page();
            }

            public async Task<IActionResult> OnPostAsync(int id)
            {
                var payMode = await _context.PayModes.FindAsync(id);

                if (payMode != null)
                {
                    _context.PayModes.Remove(payMode);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("Index");
            }
    }
}
