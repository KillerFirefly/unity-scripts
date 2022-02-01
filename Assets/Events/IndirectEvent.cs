using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Indirect Event", fileName = "New Indirect Event")]
public class IndirectEvent : ScriptableObject {
	HashSet<IndirectEventListener> listeners = new HashSet<IndirectEventListener>();
	HashSet<IndirectEventGroupListener> listListeners = new HashSet<IndirectEventGroupListener>();

	public void Invoke() {
		foreach (var globalEventListener in listeners) {
			globalEventListener.RaiseEvent();
		}
		foreach (var item in listListeners) {
			item.Evaluate(this);
		}
	}

	public void Register(IndirectEventListener gameEventListener) => listeners.Add(gameEventListener);
	public void Deregister(IndirectEventListener gameEventListener) => listeners.Remove(gameEventListener);
	public void Register(IndirectEventGroupListener listListener) => listListeners.Add(listListener);
	public void Deregister(IndirectEventGroupListener listListener) => listListeners.Remove(listListener);

}
