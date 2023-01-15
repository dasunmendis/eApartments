using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobeFa.DAL.Entities;
using GlobeFa.DAL.Enums;
using GlobeFa.DAL.Repository;

namespace GlobeFa.Infrastructure.Services
{
    public class EmployeeService : AbstractService
    {
        public EmployeeService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Employee> GetEmployees(string toInclude = "")
        {
            return unitOfWork.EmployeeRepository.GetAll(null, null, toInclude);
        }

        public Employee GetEmployeeById(int id, string toInclude = "")
        {
            return GetEmployees(toInclude).FirstOrDefault(m => m.Id == id);
        }

        public Employee AddEmployee(Employee employee)
        {
            unitOfWork.EmployeeRepository.Insert(employee);
            unitOfWork.Save();

            return GetEmployeeById(employee.Id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            unitOfWork.EmployeeRepository.Update(employee);
            unitOfWork.Save();

            return GetEmployeeById(employee.Id);
        }

        public bool DeleteEmployeeById(int id)
        {
            unitOfWork.EmployeeRepository.DeleteById(id);
            unitOfWork.Save();

            return true;
        }

        public int GetNextEmployeeId()
        {
            var nextId = 0;
            var latestEmp = (from emp in GetEmployees()
                             orderby emp.Id descending
                             select emp).FirstOrDefault();
            nextId = (latestEmp != null ? latestEmp.Id++ : 1);
            return nextId;
        }

        public string GenerateEmployeeNumber()
        {
            string nextNumber = "EMP" + "00001";
            var latestEmp = (from emp in GetEmployees()
                             orderby emp.Id descending
                             select emp).FirstOrDefault();

            if (latestEmp != null)
            {
                var splitArray = (latestEmp.EmployeeNumber != null)
                    ? Regex.Split(latestEmp.EmployeeNumber, @"(?<=\p{L})(?=\p{N})")
                    : Regex.Split(nextNumber, @"(?<=\p{L})(?=\p{N})");
                var latestNo = (Convert.ToInt32(splitArray[1]) + 1).ToString();
                nextNumber = "EMP" + latestNo.PadLeft(5, '0');
            }
            return nextNumber;
        }

        public string GenerateEmployeeNumberByType(EmploymentTypeEnum empType)
        {
            string nextNumber;
            var latestEmp = (from emp in GetEmployees()
                             where emp.EmploymentType == empType
                             orderby emp.Id descending
                             select emp).FirstOrDefault();

            if (latestEmp != null)
            {
                var existingEmpType = ReturnEmploymentType(latestEmp.EmploymentType);
                if (latestEmp.EmployeeNumber != null)
                {
                    var splitArray = Regex.Split(latestEmp.EmployeeNumber, @"(?<=\p{L})(?=\p{N})");
                    var latestNo = (existingEmpType.ToUpper().Trim() == splitArray[0].ToUpper().Trim())
                        ? (Convert.ToInt32(splitArray[1]) + 1).ToString()
                        : "00001";
                    nextNumber = existingEmpType.ToUpper().Trim() + latestNo;
                }
                else
                    nextNumber = "EMP" + "00001";
            }
            else
                nextNumber = "EMP" + "00001";
            return nextNumber;
        }

        private string ReturnEmploymentType(EmploymentTypeEnum? empType)
        {
            switch (empType)
            {
                case EmploymentTypeEnum.Permanent:
                    return "Permanant";
                    break;
                case EmploymentTypeEnum.Probation:
                    return "Probation";
                    break;
                case EmploymentTypeEnum.Trainee:
                    return "Trainee";
                    break;
                default:
                    return "Probation";
                    break;
            }
        }

        public IEnumerable<EmploymentTypeEnum> GetAllEmploymentTypes()
        {
            var list = Enum.GetValues(typeof(EmploymentTypeEnum)).Cast<EmploymentTypeEnum>().Cast<int>().ToList();
            var values = (EmploymentTypeEnum[])Enum.GetValues(typeof(EmploymentTypeEnum));
            return values;
        }

    }
}
