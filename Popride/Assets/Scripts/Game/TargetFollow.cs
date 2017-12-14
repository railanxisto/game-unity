using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour {

	[SerializeField]
	public Transform target;

	[SerializeField]
	public float offset;

	// Update is called once per frame
	private void Update () {
		Vector3 currentPosition = this.transform.position;
		currentPosition.x = this.target.position.x + offset;
		this.transform.position = currentPosition;
	}
}
