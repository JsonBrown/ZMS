using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZMS.Data.Applicants;
using ZMS.Domain.Applicants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZMS
{
    public class EditApplicantModel : PageModel
    {
        private readonly IApplicantData applicantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Applicant Applicant { get; set; }
        public IEnumerable<SelectListItem> TrainingDates { get; set; }
        public EditApplicantModel(IApplicantData applicantData, IHtmlHelper htmlHelper)
        {
            this.applicantData = applicantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? applicantId)
        {
            TrainingDates = htmlHelper.GetEnumSelectList<TrainingDates>();
            if (applicantId.HasValue)
            {
                Applicant = applicantData.GetById(applicantId.Value);
            }
            else
            {
                Applicant = new Applicant();
            }
            if (Applicant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TrainingDates = htmlHelper.GetEnumSelectList<TrainingDates>();
                return Page();
            }
            if (Applicant.Id > 0)
            {
                applicantData.Update(Applicant);
            }
            else
            {
                applicantData.Add(Applicant);
            }
            TempData["ApplicantMessage"] = "Applicant Saved!";
            applicantData.Commit();
            return RedirectToPage("./AllApplicants", new { applicantId = Applicant.Id });

        }
    }
}