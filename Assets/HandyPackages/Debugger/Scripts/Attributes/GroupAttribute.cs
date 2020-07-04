namespace Handy.Debugger{
	public class GroupAttribute : System.Attribute {

		public const string DEFAULT_GROUP_NAME = "Default";

		public string groupName;

		public GroupAttribute(){
			this.groupName = DEFAULT_GROUP_NAME;
		}

		public GroupAttribute(string groupName){
			this.groupName = groupName;
		}
	}
}