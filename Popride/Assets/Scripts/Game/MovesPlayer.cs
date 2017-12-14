using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovesPlayer : MonoBehaviour {

	[SerializeField]
	public float force;
	[SerializeField]
	public Rigidbody2D rb2d;
	[SerializeField]
	public float runningSpeed;
	private static MovesPlayer instance;
	private float originPositionX;
	private int coins;

	[SerializeField]
	private ParticleSystem fireParticleSystem;
	[SerializeField]
	private ParticleSystem bulletParticleSystem;



	private void Awake() {
		MovesPlayer.instance = this;
		this.originPositionX = this.transform.position.x;
	}

	public static MovesPlayer GetInstance() {
		return MovesPlayer.instance;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if (Input.GetMouseButton (0)) {
			ParticleSystem.EmissionModule emissionModule = this.fireParticleSystem.emission;
			emissionModule.enabled = true;
			emissionModule = this.bulletParticleSystem.emission;
			emissionModule.enabled = true;
			this.rb2d.AddForce (new Vector2 (0, force));
		} else {
			ParticleSystem.EmissionModule emissionModule = this.fireParticleSystem.emission;
			emissionModule.enabled = false;
			emissionModule = this.bulletParticleSystem.emission;
			emissionModule.enabled = false;
		}

		Vector2 velocity = this.rb2d.velocity;
		velocity.x = runningSpeed;
		this.rb2d.velocity = velocity;
		//Debug.Log (GetDistanceRun ());
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag ("Coin")) {
			this.coins = PlayerPrefs.GetInt ("coins", 0);
			this.coins++;
			PlayerPrefs.SetInt ("coins", this.coins);
		} else {
			if (collision.CompareTag ("Zapper")) {

				int highScore = PlayerPrefs.GetInt ("highScore", 0);
				int currentDistance = Mathf.RoundToInt (GetDistanceRun ());
				PlayerPrefs.SetInt ("lastScore", currentDistance);
				if (currentDistance > highScore) {
					PlayerPrefs.SetInt ("highScore", currentDistance);
				}
				SceneManager.LoadScene ("GameOver");
			}
		}
		
	}

	public float GetDistanceRun() {
		return (this.transform.position.x - this.originPositionX);
	}

	public float GetCoins() {
		return this.coins;
	}

	public void IncreaseSpeed () {
		this.runningSpeed += 0.5f;
	}
}
