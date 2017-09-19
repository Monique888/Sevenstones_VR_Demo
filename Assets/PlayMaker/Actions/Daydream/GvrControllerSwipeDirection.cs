using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("Sends an event based on the connection state of the controller")]
public class GvrControllerSwipeDirection : FsmStateAction
	{
		[Tooltip("How far a touch has to travel to be considered a swipe. Uses normalized distance (e.g. 1 = 1 screen diagonal distance). Should generally be a very small number.")]
		public FsmVector2 swipeStart;
		[Tooltip("How far a touch has to travel to be considered a swipe. Uses normalized distance (e.g. 1 = 1 screen diagonal distance). Should generally be a very small number.")]
		public FsmVector2 swipeEnd;
		[Tooltip("Event sent if controller is swipeLeft")]
		public FsmEvent swipeLeft;
		[Tooltip("Event sent if controller is swipeRight")]
		public FsmEvent swipeRight;
		[Tooltip("Event sent if controller is swipeUp")]
		public FsmEvent swipeUp;
		[Tooltip("Event sent if controller is swipeDown")]
		public FsmEvent swipeDown;

		public override void Reset()
		{
			swipeStart = null;
			swipeEnd = null;
			swipeLeft = null;
			swipeRight = null;
			swipeUp = null;
			swipeDown = null;
		}

		public override void OnUpdate()
		{
			if (GvrController.IsTouching == true) 
				return;

			Vector2 direction = swipeEnd.Value - swipeStart.Value;

			if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
				if (direction.x > 0) 
					Fsm.Event(swipeRight);
				else
					Fsm.Event(swipeLeft);
			}
			else{
				if (direction.y > 0)
					Fsm.Event(swipeDown);
				else
					Fsm.Event(swipeUp);
			}
		}
			public override string ErrorCheck()
			{
				if (FsmEvent.IsNullOrEmpty(swipeLeft) &&
					FsmEvent.IsNullOrEmpty(swipeRight) &&
					FsmEvent.IsNullOrEmpty(swipeUp) &&
					FsmEvent.IsNullOrEmpty(swipeDown))
					return "Action sends no events!";
				return "";
			}
	}
}