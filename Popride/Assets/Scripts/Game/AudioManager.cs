using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	private AudioSource backgroundAudioSource;

	[SerializeField]
	private AudioSource effectsAudioSource;

	[SerializeField]
	private AudioClip background;

	[SerializeField]
	private AudioClip[] coinAudioClip;


	private static AudioManager instance;

	private void Awake() {
		AudioManager.instance = this;
		PlayBackground (background);
	}

	public static AudioManager GetInstance() {
		return AudioManager.instance;
	}

	public void PlayCollectCoin() {
		int audioClipIndex = Random.Range(0, this.coinAudioClip.Length);
		AudioClip coinAudioClip = this.coinAudioClip [audioClipIndex];
		PlaySfx (coinAudioClip);
	}

	public void PlaySfx(AudioClip audioClip) {
		this.effectsAudioSource.clip = audioClip;

		this.effectsAudioSource.Play();
	}

	public void PlayBackground(AudioClip audioClip) {
		this.backgroundAudioSource.clip = audioClip;
		this.backgroundAudioSource.loop = true;
		this.backgroundAudioSource.Play();
	}

}
