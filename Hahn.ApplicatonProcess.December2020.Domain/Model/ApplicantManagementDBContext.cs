using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public class ApplicantManagementDBContext : DbContext
    {
        public ApplicantManagementDBContext(DbContextOptions<ApplicantManagementDBContext> options) : base(options)
        {
        }

        public DbSet<Applicant> applicant { get; set; }

    }
}
