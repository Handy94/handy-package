namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;

	public class LayoutElementOptionMethod : LayoutElementOptionBase {

		[SerializeField] private Button buttonOption;

		void OnDisable(){
			buttonOption.onClick.RemoveAllListeners ();
		}

		public override void SetOptionData (DebuggerOptionData optData)
		{
			base.SetOptionData (optData);

			SetAction (
				delegate() {
					optData.InvokeMethod();
				}
			);
		}

		public override void SetAction (UnityAction action)
		{
			buttonOption.onClick.RemoveAllListeners ();
			buttonOption.onClick.AddListener (action);
		}
	}
}