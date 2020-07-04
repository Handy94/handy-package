namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;

	public class LayoutElementOptionBase : MonoBehaviour {

		protected DebuggerOptionData optData;

		[SerializeField] protected Text textDisplayName;

		public virtual void SetOptionData(DebuggerOptionData optData){
			if (optData == null)
				return;

			this.optData = optData;
			if(this.textDisplayName != null) this.textDisplayName.text = this.optData.optionDisplayName;
		}

		public virtual void SetAction(UnityAction action){}

	}
}