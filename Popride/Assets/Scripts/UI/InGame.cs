using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InGame : MonoBehaviour {

	[SerializeField]
	private Text distanceText;

	[SerializeField]
	private Text coinsText;

	public int distanceRun;
	public int coins;

	
	// Update is called once per frame
	void Update () {
		this.distanceRun = (int)Mathf.Floor (MovesPlayer.GetInstance ().GetDistanceRun ());
		this.coins = (int)Mathf.Floor (MovesPlayer.GetInstance ().GetCoins());
		this.distanceText.text = (distanceRun.ToString() + "M");
		this.coinsText.text = (coins.ToString());
	}
}
