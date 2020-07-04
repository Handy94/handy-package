namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public partial class DebuggerOptions {

		private static DebuggerOptions current = new DebuggerOptions();
		public static DebuggerOptions Current{
			get{
				if (current == null) {
					current = new DebuggerOptions ();
				}
				return current;
			}
		}


	}
}