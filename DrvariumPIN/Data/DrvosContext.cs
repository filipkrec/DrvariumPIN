using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DrvariumPIN.Models
{
    public class DrvosContext : DbContext
    {
        public DrvosContext (DbContextOptions<DrvosContext> options)
            : base(options)
        {
        }

        public DbSet<DrvariumPIN.Models.Drvo> Drvo { get; set; }
    }
}
