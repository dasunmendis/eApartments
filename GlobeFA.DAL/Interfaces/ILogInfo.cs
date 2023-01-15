using System;

namespace GlobeFa.DAL.Interfaces
{
    public interface ILogInfo
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
