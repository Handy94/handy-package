namespace Handy.UI{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public class ButtonClickCountListener : MonoBehaviour {

		private const float RESET_CLICK_COUNT_TIME = 0.3f;

		private Button button;
		private int currentClickCount = 0;
		private float timeLastClicked = 0;

		public List<ButtonClickCountEventData> buttonClickCountList;

		#region Mono
		void Awake(){
			button = GetComponent<Button> ();
		}

		void OnEnable(){
			button.onClick.AddListener(HandleButtonClickedAction);
		}

		void OnDisable(){
			button.onClick.RemoveListener(HandleButtonClickedAction);
		}
		#endregion

		void HandleButtonClickedAction ()
		{
			float clickTime = Time.time;
			float clickGapTime = clickTime - timeLastClicked;
			if (clickGapTime > RESET_CLICK_COUNT_TIME) {
				currentClickCount = 0;
			}
			this.timeLastClicked = clickTime;
			currentClickCount++;
			OnButtonClickWithClickCount (currentClickCount);
		}

		void OnButtonClickWithClickCount(int clickCount){
			if (buttonClickCountList == null)
				return;
			int count = buttonClickCountList.Count;
			if (count <= 0)
				return;
			for (int i = 0; i < count; i++) {
				if (buttonClickCountList [i].clickCount == clickCount) {
					buttonClickCountList [i].clickEvent.Invoke ();
				}
			}
		}
	}
}