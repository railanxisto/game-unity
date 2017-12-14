using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	private Background[] backgrounds;

	public void Awake () {
		this.backgrounds = this.GetComponentsInChildren<Background> ();
	}

	public void Start() {
		for (int i = 0; i < this.backgrounds.Length; i++) {
			if (i == 0) {
				Background currentBackground = this.backgrounds [i];
				Vector3 viewportPoint = Vector3.zero; 
				Vector3 worldPosition = CameraController.GetInstance ().GetWorldPositionFromViewPort (viewportPoint);

				Vector3 backgroundPosition = new Vector3 (worldPosition.x, 0, 0);
				backgroundPosition.x += (currentBackground.GetWidth () / 2);
				currentBackground.transform.position = backgroundPosition;
			} else {
				Background previousBackground = this.backgrounds [(i - 1)];
				Background currentBackground = this.backgrounds [i];
				Vector3 position = previousBackground.transform.position;
				position.x = (position.x + (previousBackground.GetWidth() / 2) + (currentBackground.GetWidth() /2));  
				currentBackground.transform.position = position;
			}
		}
	}
 
	/*public void CreateBackground () {
		Background.Instantiate ();
	}*/


	public Background GetLastBackground() {
		Background lastBackground = null;
		Background currentBackground;
		for (int i = 0; i < backgrounds.Length; i++) {
			currentBackground = this.backgrounds [i];
			if (lastBackground == null) {
				lastBackground = currentBackground;
			} else {
				Vector3 lastBackgroundPosition = lastBackground.transform.position;
				Vector3 currentBackgroundPosition = currentBackground.transform.position;
				if (currentBackgroundPosition.x > lastBackgroundPosition.x) {
					lastBackground = currentBackground;
				}
			}
		}
		return lastBackground;
	}

	public void OnOutOfCamera (Background background) {
		Background lastBackground = GetLastBackground ();
		Vector3 position = lastBackground.transform.position;;
		position.x += (lastBackground.GetWidth () / 2) + (background.GetWidth () / 2);
		background.transform.position = position;
	}

}
