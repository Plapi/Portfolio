using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProjectVideo : MonoBehaviour {

	[SerializeField] private string videoName;
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private Button playButton;

	private bool videoPlaying;
	private Action onPlay;
	
	private void Awake() {
		playButton.onClick.AddListener(() => {
			videoPlaying = !videoPlaying;
			UpdatePlayButton();
			
			if (videoPlaying) {
				onPlay?.Invoke();
				videoPlayer.gameObject.SetActive(true);
				if (string.IsNullOrEmpty(videoPlayer.url)) {
					videoPlayer.url = Application.isEditor ? $"{Application.streamingAssetsPath}/{videoName}.mp4" :
						$"StreamingAssets/{videoName}.mp4";
				}
				videoPlayer.Play();
			} else {
				videoPlayer.Pause();
			}
		});
	}

	private void UpdatePlayButton() {
		playButton.GetComponent<Image>().SetAlpha(videoPlaying ? 0f : 0.5f);
		playButton.transform.GetChild(0).gameObject.SetActive(!videoPlaying);
	}

	public void Init(Action onPlay) {
		this.onPlay = onPlay;
	}

	public void StopVideo() {
		if (videoPlayer.gameObject.activeSelf) {
			videoPlaying = false;
			videoPlayer.Stop();
			UpdatePlayButton();
			videoPlayer.gameObject.SetActive(false);
		}
	}

}
