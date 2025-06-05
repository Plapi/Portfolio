using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	private void Start() {
		SceneManager.LoadSceneAsync(IsMobileResolution() ? "PortfolioPhone" : "PortfolioBrowser");
	}
	
	private static bool IsMobileResolution() {
		float aspectRatio = (float)Screen.width / Screen.height;
		return Screen.width <= 800 || aspectRatio < 1.0f;
	}
}
