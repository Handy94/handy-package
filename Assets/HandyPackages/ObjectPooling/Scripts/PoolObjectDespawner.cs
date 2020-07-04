namespace Handy.Pool{
	public static class PoolObjectDespawner {
		public static void Despawn(this IPoolable poolObject){
			poolObject.OnDespawned ();
			poolObject.GameObject.SetActive(false);
		}
	}
}