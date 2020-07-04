namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public partial class DebuggerOptions{
		
		[Group("Test")] public int testInteger { get; set; }
		[Group("Test"), DisplayName("Float")] public float testFloat { get; set; }
		[Group("Test")] public string testString { get; set; }

		public void MethodTestDebugInteger(){
			Debug.Log ("Debug " + testInteger);
		}

		public void MethodTestDebugFloat(){
			Debug.Log ("Debug " + testFloat);
		}

		public void MethodTestDebugString(){
			Debug.Log ("Debug " + testString);
		}
	}
}