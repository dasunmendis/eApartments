using GlobeFa.DAL.Repository;
using GlobeFa.Infrastructure.Services;
using System.Web.Mvc;

namespace GlobeFA.Web.Controllers
{
    public class TenantsController : Controller
    {
        private readonly TenantService _employeeService = new TenantService(new UnitOfWork());
        private readonly ContactService _contactService = new ContactService(new UnitOfWork());

        public ActionResult TenantDetails()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult GetAllTenantsToGrid()
        //{
        //    var tenants = (from tnt in _tenantService.GetTeants()
        //                     join con in _contactService.GetContacts() on tnt.Id equals con.Tenant.Id
        //                     select new { tnt, con }).ToList();

        //    var allTenants = (User.IsInRole("Admin"))
        //        ? tenants
        //        : tenants.Where(e => e.tnt.IsActive == true);

        //    var empDtoList = allTenants.Select(obj => new EmployeeDto
        //    {
        //        Id = obj.emp.Id,
        //        FirstName = obj.emp.FirstName,
        //        MiddleName = obj.emp.MiddleName,
        //        LastName = obj.emp.LastName,
        //        Mobile = obj.con.ContactMobile,
        //        Email = obj.con.EmailPersonal,
        //        NIC = obj.emp.NICNumber,
        //        IsActive = obj.emp.IsActive,
        //        EmployeeNumber = obj.emp.EmployeeNumber
        //    }).ToList();
        //    return Json(empDtoList.ToList(), JsonRequestBehavior.AllowGet);
        //}
    }
}