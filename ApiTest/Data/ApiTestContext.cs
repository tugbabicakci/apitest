using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Models
{
    public class ApiTestContext : DbContext
    {
        public ApiTestContext (DbContextOptions<ApiTestContext> options)
            : base(options)
        {
        }

        public DbSet<ApiTest.Models.Costumer> Costumer { get; set; }
    }
}
