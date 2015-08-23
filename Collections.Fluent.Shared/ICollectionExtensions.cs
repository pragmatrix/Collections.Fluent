namespace System.Collections.Generic
{
	public static class ICollectionExtensions
	{
		public static ElementT AddTo<ElementT, CElementT>(this ElementT element, ICollection<CElementT> collection)
			where ElementT : CElementT
		{
			collection.Add(element);
			return element;
		}

		public static ElementT RemoveFrom<ElementT, CElementT>(this ElementT element, ICollection<CElementT> collection)
			where ElementT : CElementT
		{
			collection.Remove(element);
			return element;
		}

		public static bool IsIn<ElementT, CElementT>(this ElementT element, ICollection<CElementT> collection)
			where ElementT : CElementT
		{
			return collection.Contains(element);
		}
	}
}
