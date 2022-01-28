using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Triggers contained unityEvent if all of group of indirectEvents have been triggered
/// </summary>
public class IndirectEventGroupListener : MonoBehaviour {

	[SerializeField] List<IndirectEvent> indirectEvents;
	private Dictionary<IndirectEvent, bool> eventList = new Dictionary<IndirectEvent, bool>();
	[SerializeField] UnityEvent unityEvent;

	private void Awake() {
		foreach (var item in indirectEvents) {
			item.Register(this);
		}
		
		foreach (var item in indirectEvents) {
			eventList.Add(item, false);
		}
	}
	private void OnDestroy() {
		foreach (var item in indirectEvents) {
			item.Deregister(this);
		}
	}

	public void Evaluate(IndirectEvent indirectEvent) {
		if (eventList.ContainsKey(indirectEvent)) {
			eventList[indirectEvent] = true;
		}

		if (!eventList.ContainsValue(false)) {  //All True
			unityEvent.Invoke();
		}
	}

}
