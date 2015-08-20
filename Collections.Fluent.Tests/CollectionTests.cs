using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Collections.Fluent.Tests
{
	[TestFixture]
    public class CollectionTests
    {
		[Test]
		public void CollectionAddToAndIsContainedIn()
		{
			var col = new List<int>();
			Assert.True(10.AddTo(col).IsIn(col));
		}

		[Test]
		public void CollectionRemoveFrom()
		{
			var col = new List<int>();
			Assert.False(10.AddTo(col).RemoveFrom(col).IsIn(col));
		}

		[Test]
		public void DictionaryAddWithKey()
		{
			var dict = new Dictionary<int, string>();

			"Hello".AddTo(10, dict);
			Assert.True(10.IsKeyIn(dict));
		}

		[Test]
		public void DictionaryAddAndRemove()
		{
			var dict = new Dictionary<int, string>();

			"Hello".AddTo(10, dict);
			10.RemoveKeyFrom(dict);
			Assert.False(10.IsKeyIn(dict));
		}

		[Test]
		public void DictionarySet()
		{
			var dict = new Dictionary<int, string>();
			"Hello".Set(10, dict);
			Assert.True(10.IsKeyIn(dict));
		}

		[Test]
		public void DictionaryAddWithKeyFun()
		{
			var dict = new Dictionary<int, string>();
			Func<string, int> kf = s => s.Length;

			"Hello".AddTo(kf, dict);
			Assert.True(5.IsKeyIn(dict));
		}

		[Test]
		public void SortedListCanUseSetAt()
		{
			var l = new SortedList<int, string>();
			"Hello".Set(10, l);
			Assert.True(10.IsKeyIn(l));
		}

#if false
		// SortedList is not support in PCLs
		[Test]
		public void SortedListCanUseIsIn()
		{
			var l = new SortedList<int, string>();
			"Hello".AddTo(10, l);
			Assert.True("Hello".IsIn(l));
		}
#endif

		[Test]
		public void SortedDictionaryCanUseIsIn()
		{
			var l = new SortedDictionary<int, string>();
			"Hello".AddTo(10, l);
			Assert.True("Hello".IsIn(l));
		}

		[Test]
		public void SortedDictionaryCanUseSet()
		{
			var l = new SortedDictionary<int, string>();
			"Hello".Set(10, l);
			Assert.True(10.IsKeyIn(l));
		}

		[Test]
		public void SortedSetCanUseAddTo()
		{
			var l = new SortedSet<int>();
			Assert.True(0.AddTo(l).IsIn(l));
		}

		[Test]
		public void SortedSetCanUseRemoveFrom()
		{
			var l = new SortedSet<int>();
			Assert.False(0.AddTo(l).RemoveFrom(l).IsIn(l));
		}

		[Test]
		public void StackCanUseIsIn()
		{
			var l = new Stack<int>();
			l.Push(10);
			Assert.True(10.IsIn(l));
		}

		[Test]
		public void StackPush()
		{
			var l = new Stack<int>();
			Assert.True(10.PushIn(l).IsIn(l));
		}
	}
}
