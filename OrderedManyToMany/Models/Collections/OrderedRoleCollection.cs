using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderedManyToMany.Models.Collections
{
	public class OrderedRoleCollection : ICollection<OrderedRole>
	{
		private readonly ICollection<OrderedRole> roles = new List<OrderedRole>();
		private User user;

		private void Reorder()
		{
			var order = 1;
			foreach (var orderedRole in roles.OrderBy(i => i.Order))
			{
				orderedRole.Order = order++;
			}
		}

		public OrderedRoleCollection(User userRef)
		{
			user = userRef;
		}

		public IEnumerator<OrderedRole> GetEnumerator()
		{
			return roles.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return roles.GetEnumerator();
		}

		public void Add(OrderedRole item)
		{
			if (item.Role == null)
			{
				if (roles.Any(i => i.RoleId == item.RoleId)) return;
			}
			else
			{
				if (roles.Any(i => i.Role.Name == item.Role.Name)) return;
			}

			if (user != null)
			{
				item.User = user;
			}

			roles.Add(item);
			Reorder();
		}

		public void Clear()
		{
			roles.Clear();
		}

		public bool Contains(OrderedRole item)
		{
			return roles.Contains(item);
		}

		public void CopyTo(OrderedRole[] array, int arrayIndex)
		{
			roles.CopyTo(array, arrayIndex);
			Reorder();
		}

		public bool Remove(OrderedRole item)
		{
			var tmpItem = roles.FirstOrDefault(i => i.RoleId == item.RoleId);
			var result = roles.Remove(tmpItem);
			Reorder();
			return result;
		}

		public int Count
		{
			get { return roles.Count; }
		}

		public bool IsReadOnly
		{
			get { return roles.IsReadOnly; }
		}
	}

}