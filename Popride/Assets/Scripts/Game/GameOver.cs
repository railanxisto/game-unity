using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameOver : MonoBehaviour {
	[SerializeField]
	private Text highScoreText;

	[SerializeField]
	private Text lastScoreText;

	[SerializeField]
	private Text gameOverText;

	public void OnRetryButtonClick() {
		SceneManager.LoadScene ("Scenes");
	}

	private void Start() {
		int highScore = PlayerPrefs.GetInt ("highScore", 0);
		int lastScore = PlayerPrefs.GetInt ("lastScore", 0) + PlayerPrefs.GetInt ("coins", 0) ;
		this.highScoreText.text = highScore.ToString ();
		this.lastScoreText.text = lastScore.ToString ();
		PlayerPrefs.SetInt ("coins", 0);

		LTDescr tween = LeanTween.scale (this.gameOverText.gameObject, Vector3.one, 0.15f);
		tween.setEase (LeanTweenType.easeInOutQuad);
		tween.setFrom ((Vector3.one * 3f));
	}
}
