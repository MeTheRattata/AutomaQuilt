using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutomaQuilt.Models;

namespace AutomaQuilt.Pages.Blocks
{
    public class DeleteModel : PageModel
    {
        private readonly AutomaQuilt.Models.AutomaQuiltContext _context;

        public DeleteModel(AutomaQuilt.Models.AutomaQuiltContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Block Block { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Block = await _context.Block.FirstOrDefaultAsync(m => m.Id == id);

            if (Block == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Block = await _context.Block.FindAsync(id);

            if (Block != null)
            {
                _context.Block.Remove(Block);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
