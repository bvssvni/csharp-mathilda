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

		public override bool Can(IComparable node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			
			return list.Operation == ListNode.ListOperation.Product;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			list.Product ();
			return node;
		}

		public static void Product (SearchModule.Search search) {
			search.Alternative (new ScalarProductOperator ());
		}
	}
}

