using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperManager : MonoBehaviour {

	public static ZapperManager instance;
	[SerializeField]
	private Zapper zapperPrefab;

	private void Awake() {
		ZapperManager.instance = this;
	}

	public static ZapperManager GetIntance() {
		return ZapperManager.instance;
	}

	public Zapper CreateZapperAt(Vector3 position) {
		Zapper zapper = Zapper.Instantiate (this.zapperPrefab);
		zapper.transform.position = position;
		return zapper;
	}
}
