using GlobeFa.DAL.Entities;
using GlobeFa.DAL.EntitiesDTO;
using GlobeFa.DAL.Repository;
using GlobeFa.Infrastructure.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GlobeFA.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService = new EmployeeService(new UnitOfWork());
        private readonly ContactService _contactService = new ContactService(new UnitOfWork());

        public ActionResult EmployeeDetails()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetAllEmployeesToGrid()
        {
            var employees = (from emp in _employeeService.GetEmployees()
                             join con in _contactService.GetContacts() on emp.Id equals con.Employee.Id
                             select new { emp, con }).ToList();

            var allEmployees = (User.IsInRole("Admin"))
                ? employees
                : employees.Where(e => e.emp.IsActive == true);

            var empDtoList = allEmployees.Select(obj => new EmployeeDto
            {
                Id = obj.emp.Id,
                FirstName = obj.emp.FirstName,
                MiddleName = obj.emp.MiddleName,
                LastName = obj.emp.LastName,
                Mobile = obj.con.ContactMobile,
                Email = obj.con.EmailPersonal,
                NIC = obj.emp.NICNumber,
                IsActive = obj.emp.IsActive,
                EmployeeNumber = obj.emp.EmployeeNumber
            }).ToList();
            return Json(empDtoList.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateOrUpdateEmployee(EmployeeDto empDto)
        {
            var empObj = new Employee
            {
                Id = empDto.Id,
                FirstName = empDto.FirstName,
                MiddleName = empDto.MiddleName,
                LastName = empDto.LastName,
                Initials = empDto.Initials,
                Title = empDto.Title,
                Gender = empDto.Gender,
                DateOfBirth = empDto.DateOfBirth,
                NICNumber = empDto.NIC,
                EmploymentType = empDto.EmploymentType,
                RoleTypeDes = empDto.RoleTypeDes,
                UserGroup = empDto.UserGroup,
                MaritalStatus = empDto.MaritalStatus,
                IsActive = empDto.IsActive
            };

            var employeeCheck = _employeeService.GetEmployeeById(empDto.Id);
            if (employeeCheck == null)
            {
                empObj.EmployeeNumber = _employeeService.GenerateEmployeeNumber();
                empObj.DateCreated = DateTime.Now;
                empObj.DateModified = DateTime.Now;

                var emp = _employeeService.AddEmployee(empObj);
                var conStat = _contactService.AddContact(new Contact { EmployeeId = empObj.Id });

                return Json(emp);
            }
            empObj.EmployeeNumber = employeeCheck.EmployeeNumber;
            empObj.DateCreated = employeeCheck.DateCreated;
            empObj.DateModified = DateTime.Now;
            var empUpdated = _employeeService.UpdateEmployee(empObj);
            return Json(empUpdated);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            bool isMapped = HaveDependencies(employee);
            if (isMapped)
            {
                return null;
            }
            else
            {
                var empDeleted = _employeeService.DeleteEmployeeById(employee.Id);
                return Json(empDeleted);
            }
        }

        //ToDo: check dependencies here
        public bool HaveDependencies(object obj)
        {
            return true;
        }
    }
}