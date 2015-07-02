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
	public class TaskTest
	{
		[TestMethod]
		public void CreateTasks()
		{
			var context = new Context();

			var task = context.Tasks.FirstOrDefault(i => i.Description == "Lev1") ?? new Task { Description = "Lev1" };
			if (context.Tasks.Any(i => i.Id == task.Id) == false)
				context.Tasks.Add(task);

			var sub1 = context.Tasks.FirstOrDefault(i => i.Description == "Lev2-1") ?? new Task { Description = "Lev2-1" };
			if (context.Tasks.Any(i => i.Id == sub1.Id) == false)
				context.Tasks.Add(sub1);

			context.SaveChanges();
		}

		[TestMethod]
		public void InsertSubTasks()
		{
			var context = new Context();

			var task = context.Tasks.FirstOrDefault(i => i.Description == "Lev1");
			Assert.IsNotNull(task);

			var sub1 = context.Tasks.FirstOrDefault(i => i.Description == "Lev2-1");
			Assert.IsNotNull(sub1);

			if (task.SubTasks.Any(i => i.TaskId == sub1.Id) == false)
			{
				var ot = new OrderedTask { Parent = task, Task = sub1, Order = task.SubTasks.Count + 1 };
				task.SubTasks.Add(ot);
			}

			context.SaveChanges();
		}

		[TestMethod]
		public void InsertSubTasks2()
		{
			var context = new Context();

			var task = context.Tasks.FirstOrDefault(i => i.Description == "Lev1");
			Assert.IsNotNull(task);

			var sub1 = context.Tasks.FirstOrDefault(i => i.Description == "Lev2-1");
			Assert.IsNotNull(sub1);

			if (task.SubTasks.Any(i => i.TaskId == sub1.Id) == false)
			{
				var ot = new OrderedTask { Parent = task, Task = sub1, Order = task.SubTasks.Count + 1 };
				context.OrderedTasks.Add(ot);
			}

			context.SaveChanges();
		}

		[TestMethod]
		public void InsertSubTasks3()
		{
			var context = new Context();

			var task = context.Tasks.FirstOrDefault(i => i.Description == "Lev1");
			Assert.IsNotNull(task);

			var sub1 = context.Tasks.FirstOrDefault(i => i.Description == "Lev2-1");
			Assert.IsNotNull(sub1);

			if (task.SubTasks.Any(i => i.TaskId == sub1.Id) == false)
			{
				var ot = new OrderedTask { Parent = task, Task = sub1, Order = task.SubTasks.Count + 1 };
				context.OrderedTasks.Add(ot);
				task.SubTasks.Add(ot);
			}

			context.SaveChanges();
		}
	}
}
