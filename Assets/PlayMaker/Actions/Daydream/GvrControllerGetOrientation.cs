using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("Gets the orientation of the Daydream VR Controller")]
public class GvrControllerGetOrientation : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmQuaternion quaternion;
		[UIHint(UIHint.Variable)]
		public FsmFloat xAngle;
		[UIHint(UIHint.Variable)]
		public FsmFloat yAngle;
		[UIHint(UIHint.Variable)]
		public FsmFloat zAngle;
		public bool everyFrame;

		public override void Reset()
		{
			quaternion = null;
			xAngle = null;
			yAngle = null;
			zAngle = null;
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
			var go = GvrController.Orientation;
				
			{
				quaternion.Value = go;

				xAngle.Value = GvrController.Orientation.eulerAngles.x;
				yAngle.Value = GvrController.Orientation.eulerAngles.y;
				zAngle.Value = GvrController.Orientation.eulerAngles.z;
			}

		}


	}
}