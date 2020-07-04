namespace Handy.Debugger{
	public class SortingOrderAttribute : System.Attribute {

		public const int DEFAULT_SORTING_ORDER = 0;

		public int sortingOrder;

		public SortingOrderAttribute(int sortingOrder){
			this.sortingOrder = sortingOrder;
		}
	}
}