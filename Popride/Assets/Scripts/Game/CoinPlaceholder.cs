using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlaceholder : MonoBehaviour {

	public CoinGroup.CoinType[] coinType;

	public bool wasUsed;

	public CoinGroup.CoinType GetRandomGroupType() {
		int index = Random.Range (0, this.coinType.Length);
		return this.coinType [index];
	
	}

}
