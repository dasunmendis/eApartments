using System.Collections.Generic;
using System.Linq;
using GlobeFa.DAL.Entities;
using GlobeFa.DAL.Repository;

namespace GlobeFa.Infrastructure.Services.eCorp
{
    public class ContactService : AbstractService
    {
        public ContactService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Contact> GetContacts(string toInclude = "")
        {
            return unitOfWork.ContactRepository.GetAll(null, null, toInclude);
        }

        public Contact GetContactById(int id, string toInclude = "")
        {
            return GetContacts(toInclude).FirstOrDefault(c => c.Id == id);
        }

        public Contact AddContact(Contact contact)
        {
            unitOfWork.ContactRepository.Insert(contact);
            unitOfWork.Save();

            return GetContactById(contact.Id);
        }

        public Contact UpdateContact(Contact contact)
        {
            unitOfWork.ContactRepository.Update(contact);
            unitOfWork.Save();

            return GetContactById(contact.Id);
        }

        public bool DeleteContactById(int id)
        {
            unitOfWork.ContactRepository.DeleteById(id);
            unitOfWork.Save();

            return true;
        }
    }
}
