namespace Handy.UI{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[System.Serializable]
	public class ButtonClickCountEventData{
		public int clickCount = 1;
		public UnityEvent clickEvent;

		public ButtonClickCountEventData ()
		{
			clickEvent = new UnityEvent ();
		}

		public ButtonClickCountEventData (int clickCount) : this()
		{
			this.clickCount = clickCount;
		}

		public ButtonClickCountEventData WithEvent(Action action)
		{
			if (clickEvent == null)
			{
				clickEvent = new UnityEvent ();
			}
			clickEvent.AddListener (new UnityAction(action));
			return this;
		}
	}
}