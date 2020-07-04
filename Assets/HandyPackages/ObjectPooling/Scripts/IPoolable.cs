namespace Handy.Pool{
	using UnityEngine;

	public interface IPoolable {
		GameObject GameObject { get; }
		void OnCreated();
		void OnSpawned();
		void OnDespawned();
	}
}