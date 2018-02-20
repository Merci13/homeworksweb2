using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Workshopmvc.Models
{
    public class CarroContext : DbContext
    {
        
            public CarroContext(DbContextOptions<CarroContext> options)
                : base(options)
            {
            }

            public DbSet<Workshopmvc.Models.Carro> Movie { get; set; }
        
    }
}
