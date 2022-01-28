using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputEvent : MonoBehaviour {

	public InputActionProperty inputAction;
	public UnityEvent onInput;

	private void OnEnable() {
		inputAction.action.performed += DoInput;
	}
	private void OnDisable() {
		inputAction.action.performed -= DoInput;
	}

	private void DoInput(InputAction.CallbackContext context) {
		onInput.Invoke();
	}
}
