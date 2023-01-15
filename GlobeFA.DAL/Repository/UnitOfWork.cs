using System;
using GlobeFa.DAL.Entities;

namespace GlobeFa.DAL.Repository
{
    public class UnitOfWork
    {
        private readonly GlobeFAContext _context;
        private bool _disposed = false;

        public UnitOfWork()
        {
            this._context = new GlobeFAContext();
        }

        private GenericRepository<Employee> _employeeRepository;
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                return _employeeRepository ?? (_employeeRepository = new GenericRepository<Employee>(_context));
            }
        }

        private GenericRepository<Tenant> _tenantRepository;
        public GenericRepository<Tenant> TenantRepository
        {
            get
            {
                return _tenantRepository ?? (_tenantRepository = new GenericRepository<Tenant>(_context));
            }
        }

        private GenericRepository<Contact> _contactRepository;
        public GenericRepository<Contact> ContactRepository
        {
            get
            {
                return _contactRepository ?? (_contactRepository = new GenericRepository<Contact>(_context));
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
