using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroup : MonoBehaviour {

	[SerializeField] 
	private CoinType coinType;

	public enum CoinType {
		GRUPO_1 = 0,
		GRUPO_2 = 1
	}

	public CoinType GetCoinType () {
		return this.coinType;
	}


}
