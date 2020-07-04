namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;
	using Handy.Utility;

	public class LayoutElementOptionProperty : LayoutElementOptionBase {

		[SerializeField] private InputField propertyInputField;
		[SerializeField] private Button buttonDecrement;
		[SerializeField] private Button buttonIncrement;

		void OnEnable(){
			propertyInputField.onValueChanged.AddListener (HandleInputFieldPropertyValueChanged);
			buttonDecrement.onClick.AddListener (HandleButtonDecrementClicked);
			buttonIncrement.onClick.AddListener (HandleButtonIncrementClicked);
		}

		void OnDisable(){
			propertyInputField.onValueChanged.RemoveListener (HandleInputFieldPropertyValueChanged);
			buttonDecrement.onClick.RemoveListener (HandleButtonDecrementClicked);
			buttonIncrement.onClick.RemoveListener (HandleButtonIncrementClicked);
		}

		public override void SetOptionData (DebuggerOptionData optData)
		{
			base.SetOptionData (optData);

			if (optData.IsProperty) {
				bool isNumeric = optData.memberInfo.IsPropertyNumber ();
				bool isDecimal = optData.memberInfo.IsPropertyDecimal ();
				if(isDecimal){
					propertyInputField.contentType = InputField.ContentType.DecimalNumber;
				}else if (isNumeric) {
					propertyInputField.contentType = InputField.ContentType.IntegerNumber;
				} else {
					propertyInputField.contentType = InputField.ContentType.Standard;
				}

				RefreshTextValue ();
				buttonDecrement.gameObject.SetActive (isNumeric || isDecimal);
				buttonIncrement.gameObject.SetActive (isNumeric || isDecimal);
			}
		}

		private void HandleInputFieldPropertyValueChanged(string val){
			if (this.optData == null)
				return;
			this.optData.SetValue (val);
		}

		private void HandleButtonDecrementClicked(){
			if (this.optData == null)
				return;
			this.optData.AddValue (-1f);
			RefreshTextValue ();
		}

		private void HandleButtonIncrementClicked(){
			if (this.optData == null)
				return;
			this.optData.AddValue (1f);
			RefreshTextValue ();
		}

		private void RefreshTextValue(){
			this.propertyInputField.text = this.optData.GetValue () + string.Empty;
		}
	}
}