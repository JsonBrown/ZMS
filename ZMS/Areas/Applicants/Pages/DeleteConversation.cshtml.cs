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
    public class DeleteConversationModel : PageModel
    {
        private readonly IApplicantData applicantData;
        [BindProperty]
        public Conversation Conversation { get; set; }
        public Applicant Applicant { get; set; }
        public DeleteConversationModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public IActionResult OnGet(int conversationId)
        {
            var Conversation = applicantData.GetConversationById(conversationId);
            this.Conversation = Conversation;
            this.Applicant = applicantData.GetById(Conversation.ApplicantId);
            if (Conversation == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int conversationId)
        {
            var conversation = applicantData.DeleteConversation(conversationId);
            applicantData.Commit();
            if (conversation == null)
            {
                return RedirectToPage("/NotFound");
            }
            TempData["ConversationMessage"] = "Conversation deleted!";
            return RedirectToPage("/ApplicantDetails", new { applicantId = conversation.ApplicantId });
        }
    }
}
