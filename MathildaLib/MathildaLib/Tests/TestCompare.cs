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

	}
}

