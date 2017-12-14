using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private bool hasBeenInsideCamera;
	private Zapper zapper;
	private CoinGroup coinGroup;
	private int cont = 0;

	[SerializeField]
	private BackgroundManager backgroundManager;
	[SerializeField]
	private ZapperPlaceHolder[] zapperPlaceHolders;
	[SerializeField]
	private CoinPlaceholder[] coinPlaceHolders;

	private List<Zapper> zappers;
	private List<CoinGroup> coins;


	private void Awake() {
		this.spriteRenderer = GetComponent<SpriteRenderer> ();
		this.zappers = new List<Zapper> ();
		this.coins = new List<CoinGroup> ();
	}

	private void Start() {
		Vector3 position = this.transform.position;
		this.hasBeenInsideCamera = CameraController.GetInstance ().IsInsideCamera (position);
	}

	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		float halfWidth = GetWidth () / 2;
		position.x += halfWidth;
		if (this.hasBeenInsideCamera) {
			if (CameraController.GetInstance ().BackgroundIsOver (position)) {
				/*
				 * Destruir objeto
				GameObject.Destroy (this.gameObject);
				*/
				this.backgroundManager.OnOutOfCamera (this);

				if (cont % 6 == 0) {
					MovesPlayer.GetInstance ().IncreaseSpeed ();
				}
				this.hasBeenInsideCamera = false;
				OnExitCameraBounds ();
			}
		} else {
			position = this.transform.position;
			position.x = (position.x - GetWidth () / 2);
			this.hasBeenInsideCamera = CameraController.GetInstance ().IsInsideCamera (position);
			if (hasBeenInsideCamera) {
				OnEnterCameraBounds ();
			}
		}
	}

	private void OnEnterCameraBounds() {
		//Cria obstaculo
		if (this.zapperPlaceHolders.Length > 0) {
			CreateZapper(); 
		}


		//Cria Grupo de Coins
		if (this.coinPlaceHolders.Length > 0) {
			CreateCoins ();
		}
	}

	private void CreateZapper() {
		int zapperCount = Random.Range (0, (this.zapperPlaceHolders.Length + 1));


		this.cont++;
		for (int i = 0; i < zapperCount; i++) {
			int zapperIndex = Random.Range (0, this.zapperPlaceHolders.Length);
			ZapperPlaceHolder placeHolder = this.zapperPlaceHolders [zapperIndex];

			if (!placeHolder.wasUsed) {
				placeHolder.wasUsed = true;
				Vector3 placeHolderPosition = placeHolder.transform.position;
				Zapper newZapper = ZapperManager.GetIntance ().CreateZapperAt (placeHolderPosition);
				zappers.Add (newZapper);
				//newZapper.transform.SetParent (this.transform, false);
			}
		}
	}

	private void CreateCoins() {
		int coinCount = Random.Range (0, (this.coinPlaceHolders.Length + 1));


		this.cont++;
		for (int i = 0; i < coinCount; i++) {
			int coinIndex = Random.Range (0, this.coinPlaceHolders.Length);
			CoinPlaceholder placeHolder = this.coinPlaceHolders [coinIndex];

			if (!placeHolder.wasUsed) {
				placeHolder.wasUsed = true;
				Vector3 placeHolderPosition = placeHolder.transform.position;
				CoinGroup newCoinGroup = CoinManager.GetIntance ().CreateCoinGroupAt (placeHolderPosition, placeHolder.GetRandomGroupType());
				coins.Add (newCoinGroup);
				//newCoinGroup.transform.SetParent (this.transform, false);
			}
		}
	}

	private void OnExitCameraBounds() {
		for (int i = 0; i < zappers.Count; i++) {
			GameObject.Destroy (zappers [i].gameObject);
		}
		this.zappers.Clear ();

		for (int i = 0; i < zapperPlaceHolders.Length; i++) {
			zapperPlaceHolders [i].wasUsed = false;
		}

		for (int i = 0; i < coins.Count; i++) {
			GameObject.Destroy (coins [i].gameObject);
		}
		this.coins.Clear ();

		for (int i = 0; i < coinPlaceHolders.Length; i++) {
			coinPlaceHolders [i].wasUsed = false;
		}
	}

	public float GetWidth() {
		Bounds bounds = this.spriteRenderer.bounds;
		return bounds.size.x;
	}
}
