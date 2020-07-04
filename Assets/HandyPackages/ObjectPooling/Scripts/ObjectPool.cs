namespace Handy.Pool{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ObjectPool : MonoBehaviour{

		protected List<IPoolable> _objectPool;

		[SerializeField] protected PoolData poolData;

		void Awake(){
			if(_objectPool == null) _objectPool = new List<IPoolable> ();
		}

		public void InitPool(PoolData poolData){
			if (_objectPool == null) {
				_objectPool = new List<IPoolable> ();
			}

			this.poolData = new PoolData(poolData);

			for (int i = 0; i < this.poolData.initialPoolCount; i++) {
				this.InstantiateObject ();
			}
		}

		private void AddObjectToPool(IPoolable obj){
			if (obj == null)
				return;
			this._objectPool.Add (obj);
		}

		private IPoolable InstantiateObject(){
			if (this.poolData.objectPrefab == null) {
				Debug.LogWarningFormat ("[Object Pool ({0})] Prefab Not Found", this.name);
				return null;
			}
			IPoolable newObject = Instantiate (this.poolData.objectPrefab, transform).GetComponent<IPoolable> ();
			newObject.GameObject.SetActive(false);
			newObject.OnCreated ();
			AddObjectToPool (newObject);
			return newObject;
		}

		private void ExpandPool(){
			int expandCount = 0;
			switch (this.poolData.expandMethod) {
			case ExpandMethod.FIXED:
				expandCount = 0;
				break;
			case ExpandMethod.DOUBLE:
				expandCount = this._objectPool.Count;
				if (expandCount == 0) {
					expandCount = 1;
				}
				break;
			case ExpandMethod.ONE_AT_A_TIME:
				expandCount = 1;
				break;
			}
			for (int i = 0; i < expandCount; i++) {
				InstantiateObject ();
			}
		}

		public IPoolable SpawnObject(Vector3 spawnPosition){
			if (this.poolData.objectPrefab == null) {
				Debug.LogWarningFormat ("[Object Pool ({0})] Prefab Not Found", this.name);
				return null;
			}
			IPoolable availableObject = null;
			int poolCount = _objectPool.Count;
			for (int i = 0; i < poolCount; i++) {
				if (_objectPool [i] == null)
					continue;
				if (_objectPool [i].GameObject.activeSelf)
					continue;
				availableObject = _objectPool [i];
				break;
			}
			if (availableObject == null) {
				ExpandPool ();
				if (_objectPool.Count > poolCount) {
					availableObject = _objectPool[poolCount];
				}
			}
			if (availableObject != null) {
				availableObject.GameObject.SetActive (true);
				availableObject.GameObject.transform.position = spawnPosition;
				availableObject.OnSpawned ();
			}
			return availableObject;
		}

		public void DespawnObject(IPoolable obj){
			if (obj == null)
				return;
			if (!this._objectPool.Contains (obj))
				return;

			obj.Despawn ();
		}
	}
}