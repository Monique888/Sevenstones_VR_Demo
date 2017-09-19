using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Daydream VR")]
	[Tooltip("Returns true if user is touching the controller touchpad")]
public class GvrControllerIsTouching : FsmStateAction
	{

		public enum ButtonType
		{
			Touchpad,
			ClickButton,
			AppButton,
			Recentering,
			Recentered
		}

		public ButtonType buttonType;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the pressed state in a Bool Variable.")]
		public FsmBool storeResult;

		public override void Reset()
		{
			storeResult = null;
		}

//		public override void OnEnter()
//		{
//			storeResult.Value = GvrController.IsTouching;
//		}

		public override void OnUpdate()
		{
			switch (buttonType)
			{
			case ButtonType.Touchpad:
				DoIsTouching();
				break;

			case ButtonType.ClickButton:
				DoClickButton();
				break;

			case ButtonType.AppButton:
				DoAppButton();
				break;

			case ButtonType.Recentering:
				DoRecentering();
				break;

			case ButtonType.Recentered:
				DoRecentered();
				break;
			}
		}
			void DoIsTouching()
			{
			storeResult.Value = GvrController.IsTouching;
			}

			void DoClickButton()
			{
			storeResult.Value = GvrController.ClickButton;
			}

			void DoAppButton()
			{
			storeResult.Value = GvrController.AppButton;
			}

			void DoRecentering()
			{
			storeResult.Value = GvrController.Recentering;
			}

			void DoRecentered()
			{
				storeResult.Value = GvrController.Recentered;
			}
		
	}
}
