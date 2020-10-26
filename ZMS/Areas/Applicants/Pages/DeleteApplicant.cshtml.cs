using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZMS.Data;
using ZMS.Domain;

namespace ZMS.Areas.Applicants.Pages
{
    public class DeleteApplicantModel : PageModel
    {
        private readonly IApplicantData applicantData;
        public Applicant Applicant { get; set; }
        public DeleteApplicantModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public IActionResult OnGet(int applicantId)
        {
            Applicant = applicantData.GetById(applicantId);
            if (Applicant == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
        public IActionResult OnPost(int applicantId)
        {
            var applicant = applicantData.Delete(applicantId);
            applicantData.Commit();
            if (applicant == null)
            {
                return RedirectToPage("/NotFound");
            }
            TempData["ApplicantsMessage"] = $"{applicant.Name} deleted!";
            return RedirectToPage("/AllApplicants");
        }
    }
}
