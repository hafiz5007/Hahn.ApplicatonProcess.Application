using Microsoft.EntityFrameworkCore;
using System;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
      
    }
}
