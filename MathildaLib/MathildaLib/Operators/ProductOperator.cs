using System;

namespace MathildaLib
{
	public class ProductOperator : Operator
	{
		public ProductOperator()
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

		public override void Do(Node node, out Node result)
		{
			var list = node as ListNode;
			list.Product ();
			result = list;
		}

		public static void Product (SearchModule.Search search) {
			search.Alternative (new ProductOperator ());
		}
	}
}

