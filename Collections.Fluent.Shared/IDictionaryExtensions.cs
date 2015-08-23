namespace System.Collections.Generic
{
	public static class IDictionaryExtensions
	{
		public static ElementT AddTo<ElementT, KeyT, CKeyT, CElementT>(this ElementT element, KeyT key, IDictionary<CKeyT, CElementT> dictionary)
			where KeyT : CKeyT
			where ElementT : CElementT
		{
			dictionary.Add(key, element);
			return element;
		}

		public static KeyT RemoveKeyFrom<KeyT, CKeyT, CElementT>(
			this KeyT key, 
			IDictionary<CKeyT, CElementT> dictionary)
			where KeyT : CKeyT
		{
			dictionary.Remove(key);
			return key;
		}

		public static bool IsKeyIn<KeyT, CKeyT, CElementT>(
			this KeyT key, 
			IDictionary<CKeyT, CElementT> dictionary)
	
			where KeyT : CKeyT
		{
			return dictionary.ContainsKey(key);
		}

		public static ElementT SetIn<KeyT, CKeyT, ElementT, CElementT>(
			this ElementT element,
			KeyT key,
			IDictionary<CKeyT, CElementT> dictionary)
			
			where KeyT : CKeyT
			where ElementT : CElementT
		{
			dictionary[key] = element;
			return element;
		}

		#region Extension methods that take a key function instead of a key.

		public static ElementT AddTo<ElementT, KeyT, CKeyT, CElementT>(
			this ElementT element, 
			Func<ElementT, KeyT> keyFun, 
			IDictionary<CKeyT, CElementT> dictionary)
			
			where KeyT : CKeyT
			where ElementT : CElementT
		{
			return element.AddTo(keyFun(element), dictionary);
		}

		public static ElementT RemoveFrom<ElementT, KeyT, CKeyT, CElementT>(
			this ElementT element, 
			Func<ElementT, KeyT> keyFun, 
			IDictionary<CKeyT, CElementT> dictionary)
			
			where KeyT : CKeyT
			where ElementT : CElementT
		{
			keyFun(element).RemoveKeyFrom(dictionary);
			return element;
		}

		public static bool IsIn<ElementT, KeyT, CKeyT, CElementT>(
			this ElementT element, 
			Func<ElementT, KeyT> keyFun, 
			IDictionary<CKeyT, CElementT> dictionary)
			
			where KeyT : CKeyT
			where ElementT : CElementT
		{
			return keyFun(element).IsKeyIn(dictionary);
		}

		#endregion
	}
}
