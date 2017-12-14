using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rbody2d;

	// Use this for initialization
	void Start () {
		this.rbody2d.velocity = new Vector2 (-5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
