using System;
using System.ComponentModel.DataAnnotations;

namespace ST10102524_APPR6312_POE_PART_2.Models
{
    public class Volunteer
    {
        [Key]
        public int VolunteerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
