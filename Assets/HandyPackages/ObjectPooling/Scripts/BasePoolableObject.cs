namespace Handy.Pool{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class BasePoolableObject : MonoBehaviour, IPoolable {

		public void OnCreated ()
		{
			
		}

		public void OnSpawned ()
		{
			
		}

		public void OnDespawned ()
		{
			
		}

		public GameObject GameObject {
			get {
				return gameObject;
			}
		}

	}
}