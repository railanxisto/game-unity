using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileIndicator : MonoBehaviour {

	private Transform target;
	private float elapsedTime;

	// Use this for initialization
	private void Awake () {
		this.elapsedTime = 0;
		Vector3 worldPOSITION = CameraController.GetInstance() .GetWorldPositionFromViewPort(new Vector3(1,0.5f,0));
		worldPOSITION.z = 0;
		this.transform.position = worldPOSITION;

		
	}
	
	// Update is called once per frame
	void Update () {
		this.elapsedTime += Time.deltaTime;

		Vector3 worldPosition = CameraController.GetInstance ().GetWorldPositionFromViewPort (new Vector3 (1, 0, 0));
		Vector3 myposition = this.transform.position;
		myposition.x = worldPosition.x;
		myposition.y = Mathf.Lerp (myposition.y, this.target.position.y, (25f * Time.deltaTime));


		this.transform.position = myposition;

		if (this.elapsedTime >= 1) {
			Vector3 position = this.transform.position;
			MissileManager.GetInstance ().CreateMissile (position);
			Destroy (this.gameObject);
		}


	}

	public void SetTarget(Transform target) {
		this.target = target;
	}
}
