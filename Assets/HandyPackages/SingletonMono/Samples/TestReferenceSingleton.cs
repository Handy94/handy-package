namespace Handy.Singleton.Test{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TestReferenceSingleton : MonoBehaviour {

		// Use this for initialization
		void Start () {
			Debug.Log ("Singleton Number : " + TestSingleton.Instance.number);
		}
	}
}