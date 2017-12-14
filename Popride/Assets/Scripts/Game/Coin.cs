﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.CompareTag ("Player")) {
			AudioManager.GetInstance ().PlayCollectCoin ();

			Destroy (this.gameObject);
		}
	}
}