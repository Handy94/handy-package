namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIDebugger : MonoBehaviour {

		private const string UI_PREFAB_NAME = "CanvasDebugger";
		private static UIDebugger _instance;
		public static UIDebugger Instance{
			get{
				if (_instance == null) {
					_instance = GameObject.FindObjectOfType<UIDebugger> ();
				}
				if (_instance == null) {
					UIDebugger uiPrefab = Resources.Load<UIDebugger> (UI_PREFAB_NAME);
					if(uiPrefab != null)
					{
						_instance = Instantiate(uiPrefab) as UIDebugger;
					}
				}
				return _instance;
			}
		}

		private Canvas _canvas;
		private GameObject currentMenuObject;

		[SerializeField] private Button buttonClose;

		[Header("Menu")]
		[SerializeField] private Button buttonMenuConsole;
		[SerializeField] private Button buttonMenuOptions;

		[SerializeField] private GameObject objectMenuConsole;
		[SerializeField] private UIMenuOptions objectMenuOptions;

		#region Mono
		void Awake(){
			_canvas = GetComponent<Canvas> ();
			if (_canvas != null)
				_canvas.enabled = false;
			DontDestroyOnLoad (gameObject);
		}

		void OnEnable(){
			buttonClose.onClick.AddListener (HandleButtonCloseClicked);
			buttonMenuConsole.onClick.AddListener (HandleButtonMenuConsoleClicked);
			buttonMenuOptions.onClick.AddListener (HandleButtonMenuOptionsClicked);
		}

		void OnDisable(){
			buttonClose.onClick.RemoveListener (HandleButtonCloseClicked);
			buttonMenuConsole.onClick.RemoveListener (HandleButtonMenuConsoleClicked);
			buttonMenuOptions.onClick.RemoveListener (HandleButtonMenuOptionsClicked);
		}
		#endregion

		public void Init(){
			objectMenuOptions.Init ();
		}

		public void Show(){
			_canvas.enabled = true;
		}

		private void HandleButtonCloseClicked(){
			_canvas.enabled = false;
		}

		private void HandleButtonMenuConsoleClicked(){
			OpenMenu (objectMenuConsole);
		}

		private void HandleButtonMenuOptionsClicked(){
			OpenMenu (objectMenuOptions.gameObject);
		}

		private void OpenMenu(GameObject menuObject){
			if (menuObject == null)
				return;
			if (currentMenuObject != menuObject) {
				if(currentMenuObject != null) currentMenuObject.SetActive (false);
				menuObject.SetActive (true);
				currentMenuObject = menuObject;
			}
		}
	}
}