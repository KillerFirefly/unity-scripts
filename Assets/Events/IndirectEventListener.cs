using UnityEngine;
using UnityEngine.Events;

public class IndirectEventListener : MonoBehaviour {

	[SerializeField] IndirectEvent gameEvent;
	[SerializeField] UnityEvent unityEvent;

	private void Awake() => gameEvent.Register(this);
	private void OnDestroy() => gameEvent.Deregister(this);
	public void RaiseEvent() => unityEvent.Invoke();
}
