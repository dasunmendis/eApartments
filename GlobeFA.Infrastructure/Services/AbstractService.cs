using System;
using GlobeFa.DAL.Repository;

namespace GlobeFa.Infrastructure.Services
{
    public abstract class AbstractService :IDisposable
    {
        protected UnitOfWork unitOfWork;

        public AbstractService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
