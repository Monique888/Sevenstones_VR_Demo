using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("Gets the acceleration of the Daydream VR Controller")]
public class GvrControllerGetAcceleration : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmVector3 accelVector3;
		[UIHint(UIHint.Variable)]
		public FsmFloat xAccel;
		[UIHint(UIHint.Variable)]
		public FsmFloat yAccel;
		[UIHint(UIHint.Variable)]
		public FsmFloat zAccel;
		public bool everyFrame;

		public override void Reset()
		{
			accelVector3 = null;
			xAccel = null;
			yAccel = null;
			zAccel = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoGetRotation();

			if (!everyFrame)
			{
				Finish();
			}		
		}

		public override void OnUpdate()
		{
			DoGetRotation();
		}

		void DoGetRotation()
		{
			var go = GvrController.Accel;
				
			{
				accelVector3.Value = go;

				xAccel.Value = GvrController.Accel.x;
				yAccel.Value = GvrController.Accel.y;
				zAccel.Value = GvrController.Accel.z;
			}

		}


	}
}