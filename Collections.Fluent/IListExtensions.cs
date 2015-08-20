﻿namespace System.Collections.Generic
{
	public static class IListExtensions
	{
		public static ElementT InsertIn<ElementT, CElementT>(this ElementT element, int index, IList<CElementT> list)
			where ElementT : CElementT
		{
			list.Insert(index, element);
			return element;
		}

		public static int IndexIn<ElementT, CElementT>(this ElementT element, IList<CElementT> list)
			where ElementT : CElementT
		{
			return list.IndexOf(element);
		}

		public static ElementT SetAt<ElementT, CElementT>(this ElementT element, int index, IList<CElementT> list)
			where ElementT : CElementT
		{
			list[index] = element;
			return element;
		}

		public static ElementT RemoveAtFrom<ElementT, CElementT>(this ElementT element, int index, IList<CElementT> list)
			where ElementT : CElementT
		{
			list.RemoveAt(index);
			return element;
		}
	}
}
