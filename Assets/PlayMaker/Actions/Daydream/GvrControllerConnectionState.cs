using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("Sends an event based on the connection state of the controller")]
public class GvrControllerConnectionState : FsmStateAction
	{
		[Tooltip("Event sent if controller is Disconnected")]
		public FsmEvent Disconnected;
		[Tooltip("Event sent if controller is Scanning")]
		public FsmEvent Scanning;
		[Tooltip("Event sent if controller is Connecting")]
		public FsmEvent Connecting;
		[Tooltip("Event sent if controller is Connected")]
		public FsmEvent Connected;
		public bool everyFrame;

		public override void Reset()
		{
			Disconnected = null;
			Scanning = null;
			Connecting = null;
			Connected = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoIntCompare();

			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoIntCompare();
		}		

		void DoIntCompare()
		{

			if (GvrController.State == GvrConnectionState.Disconnected)
			{
				Fsm.Event(Disconnected);
				return;
			}

			if (GvrController.State == GvrConnectionState.Scanning)
			{
				Fsm.Event(Scanning);
				return;
			}

			if (GvrController.State == GvrConnectionState.Connecting)
			{
				Fsm.Event(Connecting);
			}

			if (GvrController.State == GvrConnectionState.Connected)
			{
				Fsm.Event(Connected);
			}

		}

		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(Disconnected) &&
				FsmEvent.IsNullOrEmpty(Scanning) &&
				FsmEvent.IsNullOrEmpty(Connecting) &&
				FsmEvent.IsNullOrEmpty(Connected))
				return "Action sends no events!";
			return "";
		}
	}
}