using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomaQuilt.Models;

namespace AutomaQuilt.Pages.Blocks
{
    public class EditModel : PageModel
    {
        private readonly AutomaQuilt.Models.AutomaQuiltContext _context;

        public EditModel(AutomaQuilt.Models.AutomaQuiltContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Block).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockExists(Block.Id))
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

        private bool BlockExists(int id)
        {
            return _context.Block.Any(e => e.Id == id);
        }
    }
}
