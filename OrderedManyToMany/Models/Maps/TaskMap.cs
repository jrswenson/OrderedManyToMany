using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OrderedManyToMany.Models.Maps
{
	public class TaskMap : EntityTypeConfiguration<Task>
	{
		public TaskMap()
		{
			//HasMany(i => i.SubTasks).WithRequired(i => i.Parent).WillCascadeOnDelete(false);
			HasMany(i => i.SubTasks).WithRequired(i => i.Task).WillCascadeOnDelete(false);
		}
	}
}