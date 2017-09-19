using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("DescriptionSends an event when the selected button is down")]
public class GvrControllerButtonDown : FsmStateAction
{

		public enum ButtonType
		{
			Touchpad,
			ClickTouchpad,
			AppButton
		}

		public ButtonType buttonType;
		[Tooltip("Event to send if the selected button is down")]
		public FsmEvent sendEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("Store the button state in a Bool Variable.")]
		public FsmBool storeResult;

		public override void Reset()
		{
			sendEvent = null;
			storeResult = null;

		}

		public override void OnUpdate()
		{
			switch (buttonType)
			{
			case ButtonType.Touchpad:
				DoIsTouching();
				break;

			case ButtonType.ClickTouchpad:
				DoClickButton();
				break;

			case ButtonType.AppButton:
				DoAppButton();
				break;

			}
		}
		void DoIsTouching()
		{
			bool buttonDown = GvrController.TouchDown;
			if (buttonDown)
			{
				Fsm.Event(sendEvent);
			}

			storeResult.Value = buttonDown;
		}

		void DoClickButton()
		{
			bool buttonDown = GvrController.ClickButtonDown;
			if (buttonDown)
			{
				Fsm.Event(sendEvent);
			}

			storeResult.Value = buttonDown;
		}

		void DoAppButton()
		{
			bool buttonDown = GvrController.AppButtonDown;
			if (buttonDown)
			{
				Fsm.Event(sendEvent);
			}

			storeResult.Value = buttonDown;
		}

		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(sendEvent))
				return "Action sends no events!";
			return "";
		}

}

}
