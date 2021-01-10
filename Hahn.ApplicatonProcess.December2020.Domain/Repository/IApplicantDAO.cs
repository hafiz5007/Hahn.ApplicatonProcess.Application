using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repository
{
    public interface IApplicantDAO
    {
        List<Model.Applicant> GetAll();

        Task<Model.Applicant> CreateApplicant(Model.Applicant applicant);

        Task<Model.Applicant> GetApplicantById(int id);

        Task<Model.Applicant> UpdateApplicant(Model.Applicant applicant);       
    }
}
