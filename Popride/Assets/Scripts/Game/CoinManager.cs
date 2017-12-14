using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public static CoinManager instance;

	[SerializeField]
	private CoinGroup[] coinGroupPrefabs;

	private void Awake() {
		CoinManager.instance = this;
	}

	public static CoinManager GetIntance() {
		return CoinManager.instance;
	}

	private CoinGroup GetCoinGroupByGroupType(CoinGroup.CoinType groupType) {
		CoinGroup coinGroup;
		for (int i = 0; i < this.coinGroupPrefabs.Length; i++) {
			coinGroup = this.coinGroupPrefabs [i];
			if (coinGroup.GetCoinType() == groupType) {
				return coinGroup;
			}
		}
		return null;
	}

	public CoinGroup CreateCoinGroupAt(Vector3 position, CoinGroup.CoinType type) {
		CoinGroup coinGroupPreFab = GetCoinGroupByGroupType (type);
		CoinGroup coinGroup = CoinGroup.Instantiate (coinGroupPreFab);
		coinGroup.gameObject.SetActive (true);
		coinGroup.transform.position = position;
		Debug.Log ("Entrou");
		return coinGroup;
	}
}
