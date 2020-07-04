namespace Handy.Pool{
	using UnityEngine;

	[System.Serializable]
	public class PoolData{
		public GameObject objectPrefab;
		public int initialPoolCount = 10;
		public ExpandMethod expandMethod = ExpandMethod.FIXED;

		public PoolData ()
		{
		}

		public PoolData (PoolData poolData)
		{
			this.objectPrefab = poolData.objectPrefab;
			this.initialPoolCount = poolData.initialPoolCount;
			this.expandMethod = poolData.expandMethod;
		}
		
	}
}