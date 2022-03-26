using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VersionNumber : MonoBehaviour {
	[SerializeField] string prefix = "v", suffix = "";
	void Start() {
		string versionText = prefix + Application.version + suffix;
		if (GetComponent<TextMeshProUGUI>())
			GetComponent<TextMeshProUGUI>().text = versionText;
		else if (GetComponent<Text>())
			GetComponent<Text>().text = versionText;
	}
	//private void OnValidate() {
	//	Start();
	//}
}
