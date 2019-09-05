using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomaQuilt.Models
{
    public class AutomaQuiltContext : DbContext
    {
        public AutomaQuiltContext (DbContextOptions<AutomaQuiltContext> options)
            : base(options)
        {
        }

        public DbSet<AutomaQuilt.Models.Block> Block { get; set; }
    }
}
