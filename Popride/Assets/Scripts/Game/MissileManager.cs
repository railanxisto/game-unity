using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour {

	private float MIN_MISSILE_DELAY = 3f;
	private float MAX_MISSILE_DELAY = 10f;


	private float elapsedTime;
	private float missileCreationDelay;

	[SerializeField]
	private MissileIndicator missileInidicatorPrefab;

	[SerializeField]
	private Missile missilePrefab;

	private static MissileManager instance;

	private void Awake() {
		MissileManager.instance = this;
	}
	// Use this for initialization
	void Start () {
		this.elapsedTime = 0;
		this.missileCreationDelay = Random.Range (MIN_MISSILE_DELAY, MAX_MISSILE_DELAY);
	}
	
	// Update is called once per frame
	void Update () {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.missileCreationDelay) {
			this.elapsedTime -= this.missileCreationDelay;
			this.missileCreationDelay = Random.Range (MIN_MISSILE_DELAY, MAX_MISSILE_DELAY);
			CreateIndicator ();
		}
	}

	public static MissileManager GetInstance() {
		return MissileManager.instance;
	}

	public void CreateIndicator() {
		MissileIndicator indicator = MissileIndicator.Instantiate (this.missileInidicatorPrefab);
		MovesPlayer player = MovesPlayer.GetInstance ();
		indicator.SetTarget (player.transform);
	}

	public void CreateMissile(Vector3 position) {
		Missile missile = Missile.Instantiate (this.missilePrefab);
		missile.transform.position = position;
		MovesPlayer player = MovesPlayer.GetInstance ();
	}
}
