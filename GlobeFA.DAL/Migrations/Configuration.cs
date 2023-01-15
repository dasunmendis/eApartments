using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using GlobeFa.DAL.Entities;
using GlobeFa.DAL.Enums;
using GlobeFa.DAL.Shared;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlobeFa.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GlobeFAContext>
    {
        private readonly string _adminName = ConfigurationManager.AppSettings["AdminUserName"];
        private readonly string _adminPassword = ConfigurationManager.AppSettings["AdminPassword"];
        private readonly string _demoUserName = ConfigurationManager.AppSettings["DemoUserName"];
        private readonly string _demoUserPassword = ConfigurationManager.AppSettings["DemoPassword"];

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GlobeFAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            CreateRoles(context);
            CreateUsers(context);
        }

        private void CreateRoles(GlobeFAContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            foreach (string roleName in CommonData.GetRoleTypeName())
            //foreach (string roleName in new string[] { CommonData.Admin, CommonData.Accountant, CommonData.User })
            {
                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }
        }

        private void CreateUsers(GlobeFAContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.FindByName(_adminName) == null)
            {
                var user = new ApplicationUser { UserName = _adminName };
                var result = userManager.Create(user, _adminPassword);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Format("Admin User couldn't be created. {0}", string.Join(",", result.Errors)));
                }
                //userManager.AddToRole(user.Id, CommonData.Admin);
                userManager.AddToRole(user.Id, UserRoleTypeEnum.Admin.ToString());
            }

            if (userManager.FindByName(_demoUserName) == null)
            {
                var user = new ApplicationUser { UserName = _demoUserName };
                var result = userManager.Create(user, _demoUserPassword);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Format("Regular User couldn't be created. {0}",
                        string.Join(",", result.Errors)));
                }
                //userManager.AddToRole(user.Id, CommonData.User);
                userManager.AddToRole(user.Id, UserRoleTypeEnum.User.ToString());
            }

            foreach (var user in GetUsers())
            {
                if (userManager.FindByName(user.UserName) == null)
                {
                    user.Employee.DateCreated = DateTime.Now;
                    user.Employee.DateModified = DateTime.Now;
                    user.Employee.IsActive = true;
                    user.Contact = new Contact
                    {
                        Employee = user.Employee,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };

                    var result = userManager.Create(user, "p@$$w0rd");
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Format("User couldn't be created. {0}",
                                string.Join(",", result.Errors)));
                    }
                    //userManager.AddToRole(user.Id, CommonData.User);
                    userManager.AddToRole(user.Id, UserRoleTypeEnum.User.ToString());
                }
            }
        }

        private IEnumerable<ApplicationUser> GetUsers()
        {
            var applicationUsers = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    UserName = "dasun",
                    Employee = new Employee
                    {
                        FirstName = "Dasun",
                        MiddleName = "Lakshitha",
                        LastName = "Mendis",
                        EmploymentType = EmploymentTypeEnum.Permanent,
                        EmployeeNumber = "EMP00001"
                    }
                },
                new ApplicationUser
                {
                    UserName = "john",
                    Employee = new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        EmploymentType = EmploymentTypeEnum.Probation,
                        EmployeeNumber = "EMP00002"
                    }
                }
            };

            return applicationUsers;
        }

    }
}
