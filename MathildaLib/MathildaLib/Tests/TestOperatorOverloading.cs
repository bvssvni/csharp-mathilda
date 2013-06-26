using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestOperatorOverloading
	{
		[Test()]
		public void TestNumberAddNumber()
		{
			var a = new NumberNode (1) + 2;
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1) + new NumberNode (2);
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberMultiplyNumber()
		{
			var a = new NumberNode (1) * 2;
			var b = new ListNode (ListNode.ListOperation.Multiply,
			                      new List<Node> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1) * new NumberNode (2);
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberAddVariable ()
		{
			var a = new NumberNode (1) + new VariableNode ("a");
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
			    new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1) + "a";
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberMultiplyVariable ()
		{
			var a = new NumberNode (1) * new VariableNode ("a");
			var b = new ListNode (ListNode.ListOperation.Multiply,
			                      new List<Node> () {
				new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1) * "a";
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableAddNumber () {
			var a = new VariableNode ("a") + 2;
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new VariableNode ("a"),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a") + new NumberNode (2);
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableMultiplyNumber () {
			var a = new VariableNode ("a") * 2;
			var b = new ListNode (ListNode.ListOperation.Multiply,
			                      new List<Node> () {
				new VariableNode ("a"),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a") * new NumberNode (2);
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableAddVariable () {
			var a = new VariableNode ("a") + "b";
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new VariableNode ("a"),
				new VariableNode ("b")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a") + new VariableNode ("b");
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableMultiplyVariable () {
			var a = new VariableNode ("a") * "b";
			var b = new ListNode (ListNode.ListOperation.Multiply,
			                      new List<Node> () {
				new VariableNode ("a"),
				new VariableNode ("b")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new VariableNode ("a") * new VariableNode ("b");
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestListAddNumber () {
			var a = new ListNode (ListNode.ListOperation.List,
			                      new List<Node> () {
				new NumberNode (1)});
			a += 2;
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestListAddVariable () {
			var a = new ListNode (ListNode.ListOperation.List,
			                      new List<Node> () {
				new NumberNode (1)});
			a += "a";
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
		}
	}
}

