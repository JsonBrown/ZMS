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
    public class EditConversationModel : PageModel
    {
        private readonly IApplicantData applicantData;
        [BindProperty]
        public Conversation Conversation { get; set; }
        public Applicant Applicant { get; set; }
        public EditConversationModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public IActionResult OnGet(int? conversationId)
        {
            if (conversationId.HasValue)
            {
                Conversation = applicantData.GetConversationById(conversationId.Value);
                Applicant = applicantData.GetById(Conversation.ApplicantId);
            }
            else if (Conversation == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                applicantData.UpdateConversation(Conversation);
            }
            TempData["ConversationMessage"] = "Conversation Saved!";
            return RedirectToPage("./ApplicantDetails", new { applicantId = Conversation.ApplicantId });
        }
    }
}
