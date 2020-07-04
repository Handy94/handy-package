namespace Handy.Pool{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class PoolObjectTimeBasedDespawner : MonoBehaviour {

		private IPoolable poolable;
		public float despawnDelayTime = 1f;

		void Awake () {
			poolable = GetComponent<IPoolable>();
		}

		void OnEnable () {
			if (poolable != null) {
				StartCoroutine (Coroutine_Despawn ());
			}
		}

		IEnumerator Coroutine_Despawn(){
			yield return new WaitForSeconds (despawnDelayTime);
			poolable.Despawn ();
		}
	}
}