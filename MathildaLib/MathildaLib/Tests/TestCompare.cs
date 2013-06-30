using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestCompare
	{
		[Test()]
		public void TestProductListEquivalentToSumListWithOnlyOneElement()
		{
			var a = new NumberNode (-1).Add ("i");
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new NumberNode (-1).Add ("i"));
			Assert.True (a.CompareTo (b) == -1);
		}

		[Test()]
		public void TestSubListLessThanSize () {
			var a = new ListNode (ListNode.ListOperation.Product,
			                      new VariableNode ("c").Multiply ("i").Multiply ("i"));
			var b = new VariableNode ("c").Multiply ("i").Multiply ("i");
			Assert.True (a.CompareTo (b) == 1);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestNestedProductList () {
			// (*(*(-c+(*b*i))))
			var a = new ListNode (ListNode.ListOperation.Product,
			                      new ListNode (ListNode.ListOperation.Product,
				new ListNode (ListNode.ListOperation.Sum,
			              new VariableNode ("c"),
			              new VariableNode ("b").Multiply ("i"))));
			var changeSign = ((a [0] as ListNode) [0]) as ListNode;
			changeSign.SetInverted (0, true);
			Assert.True (a.ToString () == "(*(*(-c+(*b*i))))");

			// (*(-c+(*b*i)))
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new ListNode (ListNode.ListOperation.Sum,
			              new VariableNode ("c"),
			              new VariableNode ("b").Multiply ("i")));
			var changeSign2 = b [0] as ListNode;
			changeSign2.SetInverted (0, true);

			// TEST
			Console.WriteLine (b);

			Assert.True (b.ToString () == "(*(-c+(*b*i)))");

			// TEST
			Console.WriteLine (a.CompareTo (b));

			Assert.True (a.CompareTo (b) == 1);
		}
	}
}

