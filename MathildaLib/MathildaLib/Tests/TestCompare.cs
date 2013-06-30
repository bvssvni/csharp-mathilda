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
			Assert.True (b.ToString () == "(*(-c+(*b*i)))");
			Assert.True (a.CompareTo (b) == 1);
		}

		[Test()]
		public void Test2 () {
			// (*b*i)
			var bi = new VariableNode ("b").Multiply ("i");
			// (-c+(*b*i))
			var c = new ListNode (ListNode.ListOperation.Sum,
			                      new VariableNode ("c"), bi);
			c.SetInverted (0, true);

			// (*(-c+(*b*i)))
			var a = new ListNode (ListNode.ListOperation.Product, c);

			Assert.True (a.CompareTo (c) == 1);

			var amin = a.Minimize (SearchModule.CreateOperators ());
			Assert.True (amin.ToString () == "(-c+(*b*i))");
		}

		[Test()]
		public void Test3 () {
			// (*(-1)*a) vs (-a)
			var a = new NumberNode (-1).Multiply ("a");
			var b = new ListNode (ListNode.ListOperation.Sum, 
			                      new VariableNode ("a"));
			b.SetInverted (0, true);

			var compareResult = b.CompareTo (a);
			Assert.True (compareResult == -1);
		}

		[Test()]
		public void Test4 () {
			// (*2*a) vs (+(*2*a))
			var a = new NumberNode (2).Multiply ("a");
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new NumberNode (2).Multiply ("a"));
			Assert.True (a.CompareTo (b) == -1);
		}

		[Test()]
		public void Test5 () {
			// (+(*(+(*a*c)+(*a*d)))+(*(+(*b*c)+(*b*d))))
			var ac = new VariableNode ("a").Multiply ("c");
			var ad = new VariableNode ("a").Multiply ("d");
			var bc = new VariableNode ("b").Multiply ("c");
			var bd = new VariableNode ("b").Multiply ("d");

			var test = ac.Copy ().Add (ad);
			Assert.True (test.ToString () == "(+(*a*c)+(*a*d))");

			var exp = new ListNode (ListNode.ListOperation.Sum,
			                        ac.Copy ().Add (ad),
			                        bc.Copy ().Add (bd));
			// (+(*a*c)+(*a*d)+(*b*c)+(*b*d))
			var exp2 = ac.Add (ad).Add (bc).Add (bd);
			var compareResult = exp.CompareTo (exp2);
			Assert.True (compareResult == 1);
		}

		[Test()]
		public void TestCompareSmartList () {
			// (+(*a*c)+(*a*d)+(*b*c)+(*b*d))
			var a = new VariableNode ("a").Multiply ("c").Add (
				new VariableNode ("a").Multiply ("d")).Add (
				new VariableNode ("b").Multiply ("c")).Add (
				new VariableNode ("b").Multiply ("d"));
			Assert.True (a.ToString () == "(+(*a*c)+(*a*d)+(*b*c)+(*b*d))");
			// (+(*(+(*a*c)+(*a*d)))+(*(+(*b*c)+(*b*d))))
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new ListNode (ListNode.ListOperation.Product,
			                      new VariableNode ("a").Multiply ("c").Add (
				new VariableNode ("a").Multiply ("d"))),
			                      new ListNode (ListNode.ListOperation.Product,
			                      new VariableNode ("b").Multiply ("c").Add (
				new VariableNode ("b").Multiply ("d"))));
			Assert.True (b.ToString () == "(+(*(+(*a*c)+(*a*d)))+(*(+(*b*c)+(*b*d))))");
			int compareResult = a.CompareTo (b);
			Assert.True (compareResult == -1);
			Assert.True (b.CompareTo (a) == 1);
		}
	}
}

