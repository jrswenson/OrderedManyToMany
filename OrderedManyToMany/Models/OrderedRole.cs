using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderedManyToMany.Models
{
	public class OrderedRole
	{
		//private int userId;

		public virtual User User { get; set; }

		[Key, Column(Order = 1), ForeignKey("User")]
		public int UserId { get; set; }
		//{
		//	get { return userId == 0 ? User != null ? (userId = User.Id) : userId : userId; }
		//	set { userId = value; }
		//}

		public virtual Role Role { get; set; }

		[Key, Column(Order = 2), ForeignKey("Role")]
		public int RoleId { get; set; }

		public int Order { get; set; }
	}
}