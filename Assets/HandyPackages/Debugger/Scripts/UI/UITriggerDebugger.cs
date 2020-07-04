namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Handy.UI;

	public class UITriggerDebugger : MonoBehaviour
	{
		private const string UI_PREFAB_NAME = "CanvasTriggerDebugger";
		private static UITriggerDebugger _instance;
		public static UITriggerDebugger Instance
		{
			get
			{
				if (_instance == null) {
					_instance = GameObject.FindObjectOfType<UITriggerDebugger> ();
				}
				if (_instance == null) {
					UITriggerDebugger uiPrefab = Resources.Load<UITriggerDebugger> (UI_PREFAB_NAME);
					if(uiPrefab != null)
					{
						_instance = Instantiate(uiPrefab) as UITriggerDebugger;
					}
				}
				return _instance;
			}
		}

		private Canvas _canvas;

		public ButtonClickCountListener buttonClickCountListener;

		private void Awake()
		{
			_canvas = GetComponent<Canvas> ();
		}

		public void Init()
		{
			_canvas.enabled = true;
			buttonClickCountListener.buttonClickCountList.Add (
				new ButtonClickCountEventData(3).WithEvent(
					delegate() {
						UIDebugger.Instance.Show();
					}
				)
			);
		}
	}
}