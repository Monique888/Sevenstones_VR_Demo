using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("Gets the gyroscope of the Daydream VR Controller")]
public class GvrControllerGetGyroscope : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmVector3 gyroVector3;
		[UIHint(UIHint.Variable)]
		public FsmFloat xGyro;
		[UIHint(UIHint.Variable)]
		public FsmFloat yGyro;
		[UIHint(UIHint.Variable)]
		public FsmFloat zGyro;
		public bool everyFrame;

		public override void Reset()
		{
			gyroVector3 = null;
			xGyro = null;
			yGyro = null;
			zGyro = null;
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
			var go = GvrController.Gyro;
				
			{
				gyroVector3.Value = go;

				xGyro.Value = GvrController.Gyro.x;
				yGyro.Value = GvrController.Gyro.y;
				zGyro.Value = GvrController.Gyro.z;
			}

		}


	}
}