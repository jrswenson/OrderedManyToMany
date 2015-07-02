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
	public class OrderedRoleTest
	{
		[TestMethod]
		public void AddRoles()
		{
			var context = new Context();

			var user = context.Users.FirstOrDefault(i => i.Name == "Stan");
			Assert.IsNotNull(user);

			var role1 = context.Roles.FirstOrDefault(i => i.Name == "Admin");
			Assert.IsNotNull(role1);

			var role2 = context.Roles.FirstOrDefault(i => i.Name == "User");
			Assert.IsNotNull(role2);

			user.Roles.Clear();
			user.Roles.Add(new OrderedRole{Order = user.Roles.Count() + 1, Role = role1});
			user.Roles.Add(new OrderedRole { Order = user.Roles.Count() + 1, Role = role2 });

			var x = context.SaveChanges();
			Assert.IsTrue(x > 0);
		}

		[TestMethod]
		public void ChangeOrder()
		{
			var context = new Context();

			var user = context.Users.FirstOrDefault(i => i.Name == "Stan");
			Assert.IsNotNull(user);

			var order = 1;
			foreach (var o in user.Roles.OrderByDescending(i => i.Order))
			{
				o.Order = order++;
			}

			var x = context.SaveChanges();
			Assert.IsTrue(x > 0);
		}

		[TestMethod]
		public void RemoveRole()
		{
			var context = new Context();

			var user = context.Users.FirstOrDefault(i => i.Name == "Stan");
			Assert.IsNotNull(user);

			var firstRole = user.Roles.LastOrDefault();
			if (firstRole == null)
				return;

			user.Roles.Remove(firstRole);

			var x = context.SaveChanges();
			Assert.IsTrue(x > 0);
		}
	}
}
