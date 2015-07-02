using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OrderedManyToMany.Models.Collections;

namespace OrderedManyToMany.Models
{
	public class User
	{
		private ICollection<OrderedRole> roles;

		public User()
		{
			roles = new OrderedRoleCollection(this);
		}

		public int Id { get; set; }
		public string Name { get; set; }

		[InverseProperty("User")] 
		public virtual ICollection<OrderedRole> Roles
		{
			get { return roles; }
			set { roles = value; }
		}

		public virtual ICollection<Task> Tasks { get; set; } 
	}
}