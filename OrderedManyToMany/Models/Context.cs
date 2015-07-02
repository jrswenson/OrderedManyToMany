using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;
using OrderedManyToMany.Models.Maps;

namespace OrderedManyToMany.Models
{
	public class Context : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<OrderedRole> OrderedRoles { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<OrderedTask> OrderedTasks { get; set; }

		public Context()
		{
			Tasks.Local.CollectionChanged +=
			delegate(object sender, NotifyCollectionChangedEventArgs e)
			{
				switch (e.Action)
				{
					case NotifyCollectionChangedAction.Add:						
						break;
					case NotifyCollectionChangedAction.Move:
						break;
					case NotifyCollectionChangedAction.Remove:
						break;
					case NotifyCollectionChangedAction.Replace:
						break;
					case NotifyCollectionChangedAction.Reset:
						break;
					default:
						break;
				}

				if (e.Action == NotifyCollectionChangedAction.Add)
				{
					foreach (Task task in e.NewItems)
					{
						var entities = task.SubTasks as EntityCollection<OrderedTask>;
						if (entities != null)
						{
							var x = 1;
							//entities.AssociationChanged +=
							//	delegate(object sender2, CollectionChangeEventArgs e2)
							//	{
							//		if (e2.Action == CollectionChangeAction.Remove)
							//		{
							//			var entity = e2.Element as OrderedTask;
							//			if (entity != null)
							//			{
							//				Entry<OrderedTask>(entity).State = EntityState.Deleted;
							//			}
							//		}
							//	};
						}
					}
				}
			};
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new TaskMap());
		}
	}
}