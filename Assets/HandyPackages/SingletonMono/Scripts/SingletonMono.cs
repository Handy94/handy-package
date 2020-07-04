namespace Handy.Singleton{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour {
		private static T _instance;
		public static T Instance{
			get{
				if (_instance == null) {
					_instance = GameObject.FindObjectOfType<T> ();
					InitInstance ();
				}
				if (_instance == null) {
					GameObject go = new GameObject ();
					_instance = go.AddComponent<T> ();
					go.name = "<SingletonMono : " + _instance.GetType ().Name + ">";
					InitInstance ();
				}
				return _instance;
			}
		}

		private static void InitInstance(){
			if (_instance != null) {
				if (_instance is IInitializeable) {
					((IInitializeable)_instance).Initialize ();
				}
			}
		}

		private static void DisposeInstance(){
			if (_instance != null) {
				if (_instance is IDisposable) {
					((IDisposable)_instance).Dispose ();
				}
			}
		}

		void OnDestroy(){
			DisposeInstance ();
		}
	}
}