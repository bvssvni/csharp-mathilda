using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestOperations
	{
		[Test()]
		public void TestNumberAddNumber()
		{
			var a = new NumberNode (1).Add (2);
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1).Add (new NumberNode (2));
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberMultiplyNumber()
		{
			var a = new NumberNode (1).Multiply (2);
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new List<IComparable> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1).Multiply (new NumberNode (2));
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberAddVariable ()
		{
			var a = new NumberNode (1).Add (new VariableNode ("a"));
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
			    new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1).Add ("a");
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberMultiplyVariable ()
		{
			var a = new NumberNode (1).Multiply (new VariableNode ("a"));
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new List<IComparable> () {
				new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1).Multiply ("a");
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableAddNumber () {
			var a = new VariableNode ("a").Add (2);
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new VariableNode ("a"),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a").Add (new NumberNode (2));
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableMultiplyNumber () {
			var a = new VariableNode ("a").Multiply (2);
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new List<IComparable> () {
				new VariableNode ("a"),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a").Multiply (new NumberNode (2));
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableAddVariable () {
			var a = new VariableNode ("a").Add ("b");
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new VariableNode ("a"),
				new VariableNode ("b")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a").Add (new VariableNode ("b"));
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableMultiplyVariable () {
			var a = new VariableNode ("a").Multiply ("b");
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new List<IComparable> () {
				new VariableNode ("a"),
				new VariableNode ("b")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a").Multiply (new VariableNode ("b"));
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestListAddNumber () {
			var a = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new NumberNode (1)});
			a.Add (2);
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestListAddVariable () {
			var a = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new NumberNode (1)});
			a.Add ("a");
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberAddNumberMultiplyNumber () {
			var a = new NumberNode (1).Add (2).Multiply (3);
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new List<IComparable> () {
				new ListNode (ListNode.ListOperation.Sum,
				              new List<IComparable> () {
					new NumberNode (1),
					new NumberNode (2)}),
				new NumberNode (3)});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberMultiplyNumberAddNumber () {
			var a = new NumberNode (1).Multiply (2).Add (3);
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new ListNode (ListNode.ListOperation.Product,
				              new List<IComparable> () {
					new NumberNode (1),
					new NumberNode (2)}),
				new NumberNode (3)});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberAddNumberMultiplyVariable () {
			var a = new NumberNode (1).Add (2).Multiply ("a");
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new List<IComparable> () {
				new ListNode (ListNode.ListOperation.Sum,
				              new List<IComparable> () {
					new NumberNode (1),
					new NumberNode (2)}),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberMultiplyNumberAddVariable () {
			var a = new NumberNode (1).Multiply (2).Add ("a");
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new ListNode (ListNode.ListOperation.Product,
				              new List<IComparable> () {
					new NumberNode (1),
					new NumberNode (2)}),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableMultiplyProductList () {
			var a = new VariableNode ("a").Multiply (
				new NumberNode (1).Multiply (2));
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new VariableNode ("a"),
			                      new NumberNode (1),
			                      new NumberNode (2));
			Assert.True (a.CompareTo (b) == 0);
		}
		
		[Test()]
		public void TestNumberMultiplyProductList () {
			var a = new NumberNode (3).Multiply (
				new NumberNode (1).Multiply (2));
			var b = new ListNode (ListNode.ListOperation.Product,
			                      new NumberNode (3),
			                      new NumberNode (1),
			                      new NumberNode (2));
			Assert.True (a.CompareTo (b) == 0);
		}
	}
}

