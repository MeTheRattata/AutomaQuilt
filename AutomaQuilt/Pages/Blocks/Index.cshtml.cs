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
    public class IndexModel : PageModel
    {
        private readonly AutomaQuilt.Models.AutomaQuiltContext _context;

        public IndexModel(AutomaQuilt.Models.AutomaQuiltContext context)
        {
            _context = context;
        }

        public IList<Block> Block { get;set; }

        public async Task OnGetAsync()
        {
            Block = await _context.Block.ToListAsync();
        }
    }
}
