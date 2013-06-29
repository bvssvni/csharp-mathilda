using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestSum
	{
		[Test()]
		public void Test1Plus2Equals3()
		{
			var a = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				1.0,
				2.0});
			a.Sum ();
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				3.0});
			Assert.True (a.CompareTo (b) == 0);
		}

		[Test()]
		public void TestIgnoringVariable () {
			var a = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new VariableNode ("hello"),
				2.0,
				5.0});
			a.Sum ();
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<IComparable> () {
				new VariableNode ("hello"),
				7.0});
			Assert.True (a.CompareTo (b) == 0);
		}
	}
}

