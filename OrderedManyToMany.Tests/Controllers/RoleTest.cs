using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderedManyToMany;
using OrderedManyToMany.Controllers;
using OrderedManyToMany.Models;

namespace OrderedManyToMany.Tests.Controllers
{
	[TestClass]
	public class RoleTest
	{
		[TestMethod]
		public void CreateRole()
		{
			var context = new Context();

			var role = context.Roles.FirstOrDefault(i => i.Name == "Admin") ?? new Role { Name = "Admin" };
			if (context.Roles.Any(i => i.Id == role.Id) == false)
				context.Roles.Add(role);

			role = context.Roles.FirstOrDefault(i => i.Name == "User") ?? new Role { Name = "User" };
			if (context.Roles.Any(i => i.Id == role.Id) == false)
				context.Roles.Add(role);

			role = context.Roles.FirstOrDefault(i => i.Name == "Guest") ?? new Role { Name = "Guest" };
			if (context.Roles.Any(i => i.Id == role.Id) == false)
				context.Roles.Add(role);

			context.SaveChanges();
		}
	}
}
