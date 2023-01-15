using GlobeFa.DAL.Entities;
using GlobeFa.DAL.EntitiesDTO;
using GlobeFa.DAL.Repository;
using GlobeFa.Infrastructure.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GlobeFA.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService = new ContactService(new UnitOfWork());
        private readonly EmployeeService _employeeService = new EmployeeService(new UnitOfWork());

        public ActionResult ContactDetails()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllContactsToGrid()
        {
            var contacts = _contactService.GetContacts("Employee");

            var empDtoList = contacts.Select(obj => new ContactDto
            {
                Id = obj.Id,
                EmployeeName = obj.Employee.FirstName + " " + obj.Employee.MiddleName + " " + obj.Employee.LastName,
                EmployeeNumber = obj.Employee.EmployeeNumber,
                ContactMobile = obj.ContactMobile,
                ContactHome = obj.ContactHome,
                ContactCountryCode = obj.ContactCountryCode,
                Address1 = obj.Address1,
                Address2 = obj.Address2,
                City = obj.City,
                Country = obj.Country,
                PostalCode = obj.PostalCode,
                EmailPersonal = obj.EmailPersonal,
                EmailWork = obj.EmailWork
            });
            return Json(empDtoList.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateOrUpdateContact(ContactDto dtoObj)
        {
            var emp = _employeeService.GetEmployeeById(1);
            var contactExist = _contactService.GetContactById(dtoObj.Id);
            if (contactExist == null)
            {
                var contactNew = new Contact
                {
                    EmployeeId = 1,
                    ContactMobile = dtoObj.ContactMobile,
                    ContactHome = dtoObj.ContactHome,
                    ContactCountryCode = dtoObj.ContactCountryCode,
                    Address1 = dtoObj.Address1,
                    Address2 = dtoObj.Address2,
                    City = dtoObj.City,
                    Country = dtoObj.Country,
                    PostalCode = dtoObj.PostalCode,
                    EmailPersonal = dtoObj.EmailPersonal,
                    EmailWork = dtoObj.EmailWork,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };
                var contactAdded = _contactService.AddContact(contactNew);
                return Json(contactAdded);
            }

            contactExist.ContactMobile = dtoObj.ContactMobile;
            contactExist.ContactHome = dtoObj.ContactHome;
            contactExist.ContactCountryCode = dtoObj.ContactCountryCode;
            contactExist.Address1 = dtoObj.Address1;
            contactExist.Address2 = dtoObj.Address2;
            contactExist.City = dtoObj.City;
            contactExist.Country = dtoObj.Country;
            contactExist.PostalCode = dtoObj.PostalCode;
            contactExist.EmailPersonal = dtoObj.EmailPersonal;
            contactExist.EmailWork = dtoObj.EmailWork;
            contactExist.DateModified = DateTime.Now;
            var contactUpdated = _contactService.UpdateContact(contactExist);
            return Json(contactUpdated);
        }
    }
}