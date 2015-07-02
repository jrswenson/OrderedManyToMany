using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderedManyToMany.Models.Collections
{
	public class OrderedTaskCollection : ICollection<OrderedTask>
	{
		private readonly ICollection<OrderedTask> tasks = new List<OrderedTask>();
		private Task parent;

		private void Reorder()
		{
			var order = 1;
			foreach (var orderedRole in tasks.OrderBy(i => i.Order))
			{
				orderedRole.Order = order++;
			}
		}

		public OrderedTaskCollection(Task parentRef)
		{
			parent = parentRef;
		}

		private IEnumerator<OrderedTask> GetEnumer()
		{
			var res = tasks.GetEnumerator();
			return res;
		}

		public IEnumerator<OrderedTask> GetEnumerator()
		{
			return GetEnumer();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumer();
		}

		public void Add(OrderedTask item)
		{
			if (item.Task == null)
			{
				if (tasks.Any(i => i.TaskId == item.TaskId)) return;
			}
			else
			{
				if (tasks.Any(i => i.Task.Id == item.Task.Id || i.Task.Description == item.Task.Description)) return;
			}

			//if (tasks.Any(i => i.Id == item.Id)) return;

			item.Parent = item.Parent ?? parent;

			tasks.Add(item);
			Reorder();
		}

		public void Clear()
		{
			tasks.Clear();
		}

		public bool Contains(OrderedTask item)
		{
			return tasks.Contains(item);
		}

		public void CopyTo(OrderedTask[] array, int arrayIndex)
		{
			tasks.CopyTo(array, arrayIndex);
			Reorder();
		}

		public bool Remove(OrderedTask item)
		{
			var tmpItem = tasks.FirstOrDefault(i => i.TaskId == item.TaskId);
			var result = tasks.Remove(tmpItem);
			Reorder();
			return result;
		}

		public int Count
		{
			get { return tasks.Count; }
		}

		public bool IsReadOnly
		{
			get { return tasks.IsReadOnly; }
		}
	}
}