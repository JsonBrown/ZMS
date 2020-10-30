using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZMS.Data.Applicants;
using ZMS.Domain.Applicants;

namespace ZMS.Pages.Applicants
{
    public class ReturningModel : PageModel
    {
        private readonly IApplicantData applicantData;

        public IEnumerable<Applicant> Applicants { get; set; }
        public ReturningModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public void OnGet()
        {
            Applicants = applicantData.GetAll();
        }
    }
}
