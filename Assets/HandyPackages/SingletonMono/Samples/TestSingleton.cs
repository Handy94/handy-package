namespace Handy.Singleton.Test{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Singleton;

	public class TestSingleton : SingletonMono<TestSingleton>, IInitializeable, IDisposable {

		public int number = 10;

		public void Initialize(){
			number = 100;
			Debug.Log ("Test Singleton Initialized");
		}

		public void Dispose(){
			Debug.Log ("Test Singleton Disposed");
		}

	}
}