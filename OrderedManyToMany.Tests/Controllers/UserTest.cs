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
	public class UserTest
	{
		[TestMethod]
		public void CreateUser()
		{
			var context = new Context();

			var user = context.Users.FirstOrDefault(i => i.Name == "Stan") ?? new User { Name = "Stan" };
			if (context.Users.Any(i => i.Id == user.Id) == false)
				context.Users.Add(user);

			context.SaveChanges();
		}
	}
}
