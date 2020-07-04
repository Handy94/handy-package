namespace Handy.Debugger{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using UnityEngine;
	using Handy.Utility;

	public class DebuggerCore {

		private static DebuggerCore _instance;
		public static DebuggerCore Instance{
			get{
				if(_instance == null) _instance = new DebuggerCore ();
				return _instance;
			}
		}

		public Dictionary<string, List<DebuggerOptionData>> debuggerOptionList;

		public void Init()
		{
			InitDebuggerTriggerUI ();
			PopulateOptions ();
		}

		private void InitDebuggerTriggerUI()
		{
			UITriggerDebugger.Instance.Init ();
		}

		private void PopulateOptions(){
			debuggerOptionList = new Dictionary<string, List<DebuggerOptionData>> ();

			Type optionType = typeof(DebuggerOptions);

			MemberInfo[] memberInfo = optionType.GetMembers (
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.DeclaredOnly)
				.Where(x => IsMemberInfoValid(x))
				.ToArray();
			
			int fieldInfoLength = memberInfo.Length;
			for (int i = 0; i < fieldInfoLength; i++) {
				DebuggerOptionData option = new DebuggerOptionData ();

				DisplayNameAttribute attrName = memberInfo [i].GetAttribute<DisplayNameAttribute> ();
				option.optionDisplayName = (attrName != null) ? attrName.displayName : memberInfo[i].Name;

				SortingOrderAttribute attrSorting = memberInfo [i].GetAttribute<SortingOrderAttribute> ();
				option.sortingOrder = (attrSorting != null) ? attrSorting.sortingOrder : SortingOrderAttribute.DEFAULT_SORTING_ORDER;

				GroupAttribute attrGroup = memberInfo [i].GetAttribute<GroupAttribute> ();
				string groupName = (attrGroup != null) ? attrGroup.groupName : GroupAttribute.DEFAULT_GROUP_NAME;

				option.memberInfo = memberInfo [i];

				if (!debuggerOptionList.ContainsKey (groupName)) {
					debuggerOptionList.Add (groupName, new List<DebuggerOptionData> ());
				}
				debuggerOptionList [groupName].Add (option);
			}
		}

		private bool IsMemberInfoValid(MemberInfo memberInfo){
			if (memberInfo.MemberType == MemberTypes.Constructor)
				return false;
			if (memberInfo is MethodInfo) {
				MethodInfo m = (MethodInfo)memberInfo;
				if (m.IsSpecialName)
					return false;
			}
			return true;
		}
	}
}