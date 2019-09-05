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
    public class DetailsModel : PageModel
    {
        private readonly AutomaQuilt.Models.AutomaQuiltContext _context;

        public DetailsModel(AutomaQuilt.Models.AutomaQuiltContext context)
        {
            _context = context;
        }

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
    }
}
