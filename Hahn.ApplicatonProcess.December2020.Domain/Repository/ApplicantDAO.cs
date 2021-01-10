using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repository
{
    public class ApplicantDAO : IApplicantDAO
    {
        private readonly ApplicantManagementDBContext dbContext;

        public ApplicantDAO(ApplicantManagementDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Model.Applicant> CreateApplicant(Model.Applicant applicant)
        {

            await dbContext.applicant.AddAsync(applicant);
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return applicant;
        }

        public async Task<Model.Applicant> GetApplicantById(int id)
        {
            Model.Applicant applicant = await dbContext.applicant.FindAsync(id);

            if (applicant == null)
            {
                return null;
            }

            return applicant;
        }

        public List<Model.Applicant> GetAll()
        {
            return dbContext.applicant.ToList();
        }

        public async Task<Model.Applicant> UpdateApplicant(Model.Applicant applicant)
        {
            var checkApplicant = await GetApplicantById(applicant.ID);
            if (checkApplicant == null)
                return null;

            var local = dbContext.Set<Model.Applicant>()
                .Local
                .FirstOrDefault(entry => entry.ID.Equals(applicant.ID));

            if (local != null)
            {
                // detach
                dbContext.Entry(local).State = EntityState.Detached;
            }

            dbContext.Entry(applicant).State = EntityState.Modified;

            dbContext.applicant.Update(applicant);
            await dbContext.SaveChangesAsync();

            return applicant;
        }
    }
}
