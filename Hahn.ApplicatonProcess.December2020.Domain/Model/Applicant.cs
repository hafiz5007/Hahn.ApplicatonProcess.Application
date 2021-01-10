using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public class Applicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Family Name is required")]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country of Origin is required")]
        public string CountryOfOrigin { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string EMailAdress { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        public bool Hired { get; set; }

    }
}
