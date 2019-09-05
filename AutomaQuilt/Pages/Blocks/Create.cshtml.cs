using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutomaQuilt.Models;

namespace AutomaQuilt.Pages.Blocks
{
    public class CreateModel : PageModel
    {
        private readonly AutomaQuilt.Models.AutomaQuiltContext _context;

        public CreateModel(AutomaQuilt.Models.AutomaQuiltContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Block Block { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Block.Add(Block);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}