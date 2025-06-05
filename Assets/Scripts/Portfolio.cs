using UnityEngine;
using UnityEngine.UI;

public class Portfolio : MonoBehaviour {

	[SerializeField] private Button resumeButton;
	[SerializeField] private Button gitButton;
	[SerializeField] private ScrollRect scrollRect;
	[SerializeField] private ProjectVideo[] videos;
	
	private void Awake() {
		
		Debug.LogError("Screen size " + Screen.width + " x " + Screen.height);
		
		if (!Application.isEditor) {
			scrollRect.scrollSensitivity = 0.02f;
		}
		
		resumeButton.onClick.AddListener(() => {
			Application.OpenURL("https://plapi.github.io/Portfolio/resume.pdf");
		});
		gitButton.onClick.AddListener(() => {
			Application.OpenURL("https://github.com/Plapi");
		});
		
		for (int i = 0; i < videos.Length; i++) {
			int ii = i;
			videos[i].Init(() => {
				for (int j = 0; j < videos.Length; j++) {
					if (ii != j) {
						videos[j].StopVideo();	
					}
				}		
			});
		}
	}
}
