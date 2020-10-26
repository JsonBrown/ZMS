using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ZMS.Domain
{
    public class Applicant
    {
        public Applicant()
        {
            Conversations = new List<Conversation>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime AppDate { get; set; }
        [Required]
        public bool Hired { get; set; }
        [Required]
        public TrainingDates Training { get; set; }
        [Required]
        public string JobSource { get; set; }
        [Required]
        public string Availability { get; set; }
        public string Notes { get; set; }
        public bool Returning { get; set; }
        public List<Conversation> Conversations { get; set; }
    }
}
