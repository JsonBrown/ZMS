using System;
using System.Collections.Generic;
using System.Text;
using ZMS.Domain;

namespace ZMS.Data
{
    public class SqlApplicantData : IApplicantData
    {
        public SqlApplicantData(ApplicantDbContext db)
        {

        }

        public Applicant Add(Applicant newApplicant)
        {
            throw new NotImplementedException();
        }

        public Conversation AddConversation(Conversation newConversation)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Applicant Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Conversation DeleteConversation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Applicant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Applicant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Applicant> GetByTraining()
        {
            throw new NotImplementedException();
        }

        public Conversation GetConversationById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> GetConversations(int id)
        {
            throw new NotImplementedException();
        }

        public Applicant Update(Applicant updatedApplicant)
        {
            throw new NotImplementedException();
        }

        public Conversation UpdateConversation(Conversation updatedConversation)
        {
            throw new NotImplementedException();
        }
    }
}
