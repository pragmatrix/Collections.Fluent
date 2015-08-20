namespace System.Collections.Generic
{
	public static class SortedDictionaryExtensions
	{
		public static bool IsIn<ElementT, CKeyT, CElementT>(this ElementT element, SortedDictionary<CKeyT, CElementT> dictionary)
			where ElementT : CElementT
		{
			return dictionary.ContainsValue(element);
		}
	}
}
