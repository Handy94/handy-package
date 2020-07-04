namespace Handy.Debugger{
	using UnityEngine;

	static class DebuggerInitiator {

		[RuntimeInitializeOnLoadMethod]
		static void InitDebugger(){
			DebuggerCore.Instance.Init ();
			UIDebugger.Instance.Init ();
		}

	}
}