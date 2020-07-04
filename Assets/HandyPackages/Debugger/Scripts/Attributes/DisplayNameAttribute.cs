namespace Handy.Debugger{
	public class DisplayNameAttribute : System.Attribute {
		public string displayName;

		public DisplayNameAttribute(string displayName){
			this.displayName = displayName;
		}
	}
}