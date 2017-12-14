using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera gameCamera;

	private static CameraController instance;

	private void Awake() {
		CameraController.instance = this;
		this.gameCamera = GetComponent<Camera>();
	}

	public static CameraController GetInstance() {
		return CameraController.instance;
	}

	public bool IsInsideCamera(Vector3 position) {
		Vector2 viewPortPosition = this.gameCamera.WorldToViewportPoint (position);
		if (viewPortPosition.x < 0 || viewPortPosition.x > 1) {
			return false;
		}
		return true;
	}

	public Vector3 GetWorldPositionFromViewPort (Vector2 viewPortPosition) {
		return this.gameCamera.ViewportToWorldPoint (viewPortPosition);
	}

	public bool BackgroundIsOver(Vector3 position) {
		Vector2 viewPortPosition = this.gameCamera.WorldToViewportPoint (position);
		if (viewPortPosition.x < 0) {
			return true;
		}
		return false;
	}
}
