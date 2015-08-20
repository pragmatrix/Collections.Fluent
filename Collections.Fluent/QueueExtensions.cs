namespace System.Collections.Generic
{
	public static class QueueExtensions
	{
		public static ElementT EnqueueIn<ElementT, CElementT>(this ElementT element, Queue<CElementT> queue)
			where ElementT : CElementT
		{
			queue.Enqueue(element);
			return element;
		}
	}
}
