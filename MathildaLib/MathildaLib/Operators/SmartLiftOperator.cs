using System;

namespace MathildaLib
{
	/// <summary>
	/// Smart lift operator.
	/// 
	/// (+(*(+(*a*c)+(*a*d)))+(*(+(*b*c)+(*b*d)))) -> (+(*a*c)+(*a*d)+(*b*c)+(*b*d))
	/// </summary>
	public class SmartLiftOperator : Operator
	{
		public SmartLiftOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.Operation != ListNode.ListOperation.Sum) {
				return false;
			}

			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				var item = list [i] as ListNode;
				if (item == null) {
					continue;
				}

				if (item.Operation == ListNode.ListOperation.Product &&
				    item.NodeCount == 1) {
					var subItem = item [i] as ListNode;
					if (subItem.Operation == ListNode.ListOperation.Sum) {
						return true;
					}
				}
			}

			return false;
		}

		public override void Do(ref Node node)
		{
			// TEST
			Console.WriteLine ("before smart lift {0}", node);

			var list = node as ListNode;
			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				var item = list [i] as ListNode;
				if (item == null) {
					continue;
				}

				if (item.Operation == ListNode.ListOperation.Product &&
				    item.NodeCount == 1) {
					list.RemoveNodeAt (i);
					var subItem = item [0] as ListNode;
					n--;
					if (subItem.Operation == ListNode.ListOperation.Sum) {
						int m = subItem.NodeCount;
						for (int j = 0; j < m; j++) {
							list.InsertNode (i, subItem [j]);
							i++;
							n++;
						}
					}

					i--;
				}
			}

			// TEST
			Console.WriteLine ("after smart lift {0}", node);
		}

		public static void SmartLift (SearchModule.Search search) {
			search.Alternative (new SmartLiftOperator ());
		}
	}
}

