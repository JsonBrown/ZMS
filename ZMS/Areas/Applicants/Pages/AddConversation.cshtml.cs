using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZMS.Data.Applicants;
using ZMS.Domain.Applicants;

namespace ZMS.Areas.Applicants.Pages
{
    public class AddConversationModel : PageModel
    {
        private readonly IApplicantData applicantData;
        [BindProperty]
        public Conversation Conversation { get; set; }
        public Applicant Applicant { get; set; }
        public AddConversationModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public IActionResult OnGet(int? applicantId)
        {
            if (applicantId.HasValue)
            {
                Applicant = applicantData.GetById(applicantId.Value);
                Conversation = new Conversation
                {
                    ApplicantId = Applicant.Id,
                    Applicant = this.Applicant
                };
            }
            else if (Applicant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int? applicantId)
        {
            if (!ModelState.IsValid)
            {
                Applicant = applicantData.GetById(applicantId.Value);
                Conversation = new Conversation
                {
                    ApplicantId = Applicant.Id,
                    Applicant = this.Applicant
                };
                return Page();
            }
            else
            {
                applicantData.AddConversation(Conversation);
            }
            TempData["ConversationMessage"] = "Conversation Saved!";
            applicantData.Commit();
            return RedirectToPage("./ApplicantDetails", new { applicantId = Conversation.ApplicantId });
        }
    }
}
