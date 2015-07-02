using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderedManyToMany.Models
{
	public class OrderedTask
	{
		private Task parent;
		private Task task;
		//private int parentId;
		//private int taskId;

		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public int Id { get; set; }

		public virtual Task Parent
		{
			get { return parent; }
			set
			{
				parent = value;
				if (parent.Id != ParentId)
					ParentId = parent.Id;
			}
		}

		[Key, Column(Order = 1), ForeignKey("Parent")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ParentId { get; set; }

		public virtual Task Task
		{
			get { return task; }
			set
			{
				task = value;
				if(task == null) return;

				if (task.Id != TaskId)
					TaskId = task.Id;
			}
		}

		[Key, Column(Order = 2), ForeignKey("Task")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TaskId { get; set; }

		public int Order { get; set; }		
	}
}