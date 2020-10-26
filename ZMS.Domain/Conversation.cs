using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZMS.Domain
{
    public class Conversation
    {
        public int Id { get; set; }
        public bool Interview { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Summary { get; set; }
        public Applicant Applicant { get; set; }
        public int ApplicantId { get; set; }
    }
}
