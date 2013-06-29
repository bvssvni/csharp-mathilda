using System;

namespace MathildaLib
{
	/// <summary>
	/// Scalar product operator.
	/// </summary>
	public class ScalarProductOperator : Operator
	{
		public ScalarProductOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			
			return list.Operation == ListNode.ListOperation.Product;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			list.Product ();
		}

		public static void Product (SearchModule.Search search) {
			search.Alternative (new ScalarProductOperator ());
		}
	}
}

