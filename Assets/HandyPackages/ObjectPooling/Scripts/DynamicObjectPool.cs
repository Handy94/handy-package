namespace Handy.Pool{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class DynamicObjectPool : MonoBehaviour {

		private Dictionary<string, ObjectPool> _pools;

		[SerializeField] private PoolData defaultPoolData;
		private PoolData tempPoolData;

		void Awake(){
			if (_pools == null)
				_pools = new Dictionary<string, ObjectPool> ();
		}

		private bool ValidateObjectPrefab(GameObject objectPrefab){
			if (objectPrefab == null)
				return false;

			IPoolable poolable = objectPrefab.GetComponent<IPoolable> ();
			if (poolable == null)
				return false;
			
			return true;
		}

		private bool IsPoolExistsForObject(string poolID){
			return _pools.ContainsKey (poolID);
		}

		private bool IsPoolExistsForObject(GameObject objectPrefab){
			return _pools.ContainsKey (objectPrefab.name);
		}

		public void CreateNewPool(){
			CreateNewPool (defaultPoolData);
		}

		public void CreateNewPool(PoolData poolData){
			if (!this.ValidateObjectPrefab (poolData.objectPrefab))
				return;
			if (IsPoolExistsForObject (poolData.objectPrefab))
				return;

			string objectName = poolData.objectPrefab.name;
			string newPoolName = "<ObjectPool - "+ poolData.objectPrefab.name +">";
			GameObject go = new GameObject (newPoolName);
			ObjectPool newPool = go.AddComponent<ObjectPool>();
			newPool.InitPool (poolData);

			this._pools.Add (objectName, newPool);
		}

		public void SpawnObject(GameObject objectPrefab, Vector3 spawnPosition){
			if (!this.ValidateObjectPrefab (objectPrefab))
				return;
			if (!IsPoolExistsForObject (objectPrefab)) {
				if (tempPoolData == null) {
					tempPoolData = new PoolData (defaultPoolData);
				}
				tempPoolData.objectPrefab = objectPrefab;
				CreateNewPool (tempPoolData);
			}

			this._pools [objectPrefab.name].SpawnObject (spawnPosition);
		}

		public void DespawnObject(IPoolable obj){
			obj.Despawn ();
		}
	}
}