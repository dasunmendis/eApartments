using GlobeFa.DAL.Entities;
using GlobeFa.DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace GlobeFa.Infrastructure.Services
{
    public class TenantService :AbstractService
    {
        public TenantService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Tenant> GetTenants(string toInclude = "")
        {
            return unitOfWork.TenantRepository.GetAll(null, null, toInclude);
        }

        public Tenant GetTenantById(int id, string toInclude = "")
        {
            return GetTenants(toInclude).FirstOrDefault(m => m.Id == id);
        }

        public Tenant AddTenant(Tenant employee)
        {
            unitOfWork.TenantRepository.Insert(employee);
            unitOfWork.Save();

            return GetTenantById(employee.Id);
        }

        public Tenant UpdateTenant(Tenant employee)
        {
            unitOfWork.TenantRepository.Update(employee);
            unitOfWork.Save();

            return GetTenantById(employee.Id);
        }

        public bool DeleteTenantById(int id)
        {
            unitOfWork.TenantRepository.DeleteById(id);
            unitOfWork.Save();

            return true;
        }
    }
}
