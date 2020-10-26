using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZMS.Data;
using ZMS.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZMS.Pages.Applicants
{
    public class DeclinedModel : PageModel
    {
        private readonly IApplicantData applicantData;
        public IEnumerable<Applicant> Applicants { get; set; }
        public DeclinedModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public void OnGet()
        {
            Applicants = applicantData.GetAll();
        }

    }
}