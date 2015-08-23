namespace System.Collections.Generic
{
	public static class StackExtensions
	{
		public static ElementT PushIn<ElementT, CElementT>(this ElementT element, Stack<CElementT> stack)
			where ElementT : CElementT
		{
			stack.Push(element);
			return element;
		}

		public static bool IsIn<ElementT, CElementT>(this ElementT element, Stack<CElementT> stack)
			where ElementT : CElementT
		{
			return stack.Contains(element);
		}
	}
}
