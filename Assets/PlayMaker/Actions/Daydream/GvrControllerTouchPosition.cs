using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("Gets the X and Y values of the touchpad")]
public class GvrControllerTouchPosition : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmVector2 vector2;
		[UIHint(UIHint.Variable)]
		public FsmFloat xPosition;
		[UIHint(UIHint.Variable)]
		public FsmFloat yPosition;

		public bool everyFrame;

		public override void Reset()
		{
			vector2 = null;
			xPosition = null;
			yPosition = null;
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
			Vector2 newVector2 = vector2.Value;
			var vX = Mathf.Clamp(GvrController.TouchPos.x,0,1);
			var vY = Mathf.Clamp(GvrController.TouchPos.y,0,1);
				
			{

				xPosition.Value = vX;
				yPosition.Value = vY;
				newVector2.x = xPosition.Value;
				newVector2.y = yPosition.Value;
				vector2.Value = newVector2;
			}

		}


	}
}