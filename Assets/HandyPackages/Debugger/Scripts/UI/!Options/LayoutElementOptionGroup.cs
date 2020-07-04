namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class LayoutElementOptionGroup : MonoBehaviour {

		[SerializeField] private Text textGroupName;
		[SerializeField] private Transform optionContainer;
		[SerializeField] private GameObject methodOptionPrefab;
		[SerializeField] private GameObject propertyOptionPrefab;

		public void Init(string groupName){
			if (textGroupName == null)
				return;
			textGroupName.text = groupName;
		}

		public void AddOption(DebuggerOptionData optData){
			GameObject prefab = null;
			if (optData.IsMethod)
				prefab = methodOptionPrefab;
			if (optData.IsProperty)
				prefab = propertyOptionPrefab;
			if (prefab == null)
				return;

			LayoutElementOptionBase option = Instantiate (prefab, optionContainer).GetComponent<LayoutElementOptionBase>();
			option.SetOptionData (optData);
		}

	}
}