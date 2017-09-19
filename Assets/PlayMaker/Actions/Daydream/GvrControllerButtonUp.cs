using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Daydream VR")]
[Tooltip("DescriptionSends an event when the selected button is down")]
public class GvrControllerButtonUp : FsmStateAction
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
			bool buttonUp = GvrController.TouchUp;
			if (buttonUp)
			{
				Fsm.Event(sendEvent);
			}

			storeResult.Value = buttonUp;
		}

		void DoClickButton()
		{
			bool buttonUp = GvrController.ClickButtonUp;
			if (buttonUp)
			{
				Fsm.Event(sendEvent);
			}

			storeResult.Value = buttonUp;
		}

		void DoAppButton()
		{
			bool buttonUp = GvrController.AppButtonUp;
			if (buttonUp)
			{
				Fsm.Event(sendEvent);
			}

			storeResult.Value = buttonUp;
		}

		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(sendEvent))
				return "Action sends no events!";
			return "";
		}

}

}
