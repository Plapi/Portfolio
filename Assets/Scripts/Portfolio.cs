using UnityEngine;
using UnityEngine.UI;

public class Portfolio : MonoBehaviour {
	
	[SerializeField] private ScrollRect scrollRect;
	[SerializeField] private ProjectVideo[] videos;

	private void Awake() {
		if (!Application.isEditor) {
			scrollRect.scrollSensitivity = 0.02f;
		}
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
