namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class UIMenuOptions : MonoBehaviour {

		[SerializeField] private Transform contentContainer;
		[SerializeField] private GameObject prefabGroup;

		private Dictionary<string, LayoutElementOptionGroup> groupList;

		public void Init(){
			groupList = new Dictionary<string, LayoutElementOptionGroup> ();

			if (DebuggerCore.Instance.debuggerOptionList != null) {
				foreach (var item in DebuggerCore.Instance.debuggerOptionList) {
					int count = item.Value.Count;
					for (int i = 0; i < count; i++) {
						AddOption (item.Key, item.Value[i]);
					}
				}
			}
		}

		public void AddGroup(string groupName){
			LayoutElementOptionGroup go = Instantiate (prefabGroup, contentContainer).GetComponent<LayoutElementOptionGroup>();
			go.Init (groupName);
			groupList.Add (groupName, go);
		}

		public void AddOption(string groupName, DebuggerOptionData optData){
			if (!groupList.ContainsKey (groupName)) {
				this.AddGroup (groupName);
			}
			groupList [groupName].AddOption (optData);
		}
	}
}