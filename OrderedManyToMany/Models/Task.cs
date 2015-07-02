using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OrderedManyToMany.Models.Collections;

namespace OrderedManyToMany.Models
{
	public class Task
	{
		private ICollection<OrderedTask> subTasks;

		public Task()
		{
//			subTasks = new OrderedTaskCollection(this);
			subTasks = new List<OrderedTask>();
		}

		public int Id { get; set; }
		public string Description { get; set; }

		public virtual User AssignedUser { get; set; }
		public int? AssignedUserId { get; set; }

		//[InverseProperty("Parent")] 
		public virtual ICollection<OrderedTask> SubTasks
		{
			get { return subTasks; }
			set { subTasks = value; }
		}
	}
}