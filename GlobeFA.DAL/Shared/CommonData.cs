using System;
using System.Collections.Generic;
using System.Linq;
using GlobeFa.DAL.Enums;

namespace GlobeFa.DAL.Shared
{
    public class CommonData
    {
        //public const string Admin = "Admin";
        //public const string Accountant = "Accountant";
        //public const string User = "User";

        //public static string GetProperName(string roleName)
        //{
        //    switch (roleName)
        //    {
        //        case Admin:
        //            return "Admin";
        //        case Accountant:
        //            return "Accountant";
        //        case User:
        //            return "User";
        //        default:
        //            return "User";
        //    }
        //}

        public static List<string> GetRoleTypeName()
        {
            return (from object item in Enum.GetValues(typeof(UserRoleTypeEnum)) select item.ToString().Trim()).ToList();
        }
    }
}
