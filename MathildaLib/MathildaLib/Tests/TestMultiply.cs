using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestMultiply
	{
		[Test()]
		public void TestMultiply1 () {
			// 2 * 3 = 6
			var a = new NumberNode (2).Multiply (3);
			var b = new NumberNode (6);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply2 () {
			// 2 * a
			var a = new NumberNode (2).Multiply ("a");
			Assert.True (a.ToString () == "(*2*a)");
		}

		[Test()]
		public void TestMultiply3 () {
			// 2 * (a + b)
			var a = new NumberNode (2).Multiply (
				new VariableNode ("a").Add ("b"));
			var b = new NumberNode (2).Multiply ("a").Add (
				new NumberNode (2).Multiply ("b"));

			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply4 () {
			// a * 2
			var a = new VariableNode ("a").Multiply (2);
			Assert.True (a.ToString () == "(*a*2)");
		}

		[Test()]
		public void TestMultiply5 () {
			// a * b
			var a = new VariableNode ("a").Multiply ("b");
			Assert.True (a.ToString () == "(*a*b)");
		}

		[Test()]
		public void TestMultiply6 () {
			// a * (1 + 2)
			var a = new VariableNode ("a").Multiply (
				new NumberNode (1).Add (2));
			// a + 2*a
			var b = new VariableNode ("a").Add (
				new NumberNode (2).Multiply ("a"));
			var aMin = a.Minimize (SearchModule.CreateOperators ());
			var bMin = b.Minimize (SearchModule.CreateOperators ());

			// TEST
			Console.WriteLine ("aMin {0} bMin {1}", aMin, bMin);
			Console.WriteLine ("aMass {0} bMass {1}", ((ListNode)aMin).Mass (), ((ListNode)bMin).Mass ());

			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply7 () {
			// (1 + 2) * 3
			var a = new NumberNode (1).Add (2).Multiply (3);
			var b = new NumberNode (1).Multiply (3).Add (
				new NumberNode (2).Multiply (3));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply8 () {
			// (1 + 2) * a
			var a = new NumberNode (1).Add (2).Multiply ("a");
			var b = new NumberNode (1).Multiply ("a").Add (
				new NumberNode (2).Multiply ("a"));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply9 () {
			// (1 + 2) * (3 + 4)
			var a = new NumberNode (1).Add (2).Multiply (
				new NumberNode (3).Add (4));
			var b = new NumberNode (21);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply10 () {
			// (1 + 2) * (3 * 4)
			var a = new NumberNode (1).Add (2).Multiply (
				new NumberNode (3).Multiply (4));
			var b = new NumberNode (36);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply11 () {
			// (1 * 2) * 3
			var a = new NumberNode (1).Multiply (2).Multiply (3);
			Assert.True (a.IsEqualTo (new NumberNode (6)));
		}

		[Test()]
		public void TestMultiply12 () {
			// (1 * 2) * a
			var a = new NumberNode (1).Multiply (2).Multiply ("a");
			Assert.True (a.IsEqualTo (new NumberNode (2).Multiply ("a")));
		}

		[Test()]
		public void TestMultiply13 () {
			// (1 * 2) * (3 + 4)
			var a = new NumberNode (1).Multiply (2).Multiply (
				new NumberNode (3).Add (4));
			var b = new NumberNode (14);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply14 () {
			// (1 * 2) * (3 * 4)
			var a = new NumberNode (1).Multiply (2).Multiply (
				new NumberNode (3).Multiply (4));
			var b = new NumberNode (24);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply15 () {
			// (a + b) * (c + d)
			var a = new VariableNode ("a").Add ("b").Multiply (
				new VariableNode ("c").Add ("d"));
			var res = a.Minimize (SearchModule.CreateOperators ());

			// TEST
			Console.WriteLine (res.ToString ());

			Assert.True (res.ToString () == "(+(*a*c)+(*a*d)+(*b*c)+(*b*d))");
		}

		[Test()]
		public void TestMultiply16 () {
			// (*b*(-i)) -> (-(*b*i))
			var mi = new ListNode (ListNode.ListOperation.Sum, new VariableNode ("i"));
			mi.SetInverted (0, true);
			var a = new VariableNode ("b").Multiply (mi);
			var res = a.Minimize (SearchModule.CreateOperators ());
			Assert.True (res.ToString () == "(-(*b*i))");
		}
	}
}

