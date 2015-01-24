using UnityEngine;
using UnityEditor;
using System.Collections;

public class DescriptionBoxController : MonoBehaviour {
	public float popUpStartTime;
	public bool isAnimating = false;
	public bool isDoneAnimating = false;
	public Camera cam;

	private float screenWidth;
	private float screenHeight;

	// Use this for initialization
	void Start () {
		Vector2 screenSize = Handles.GetMainGameViewSize();
		screenWidth = screenSize.x;
		screenHeight = screenSize.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAnimating) {
			renderer.enabled = true;
			popUp();
		} else if (isDoneAnimating) {
			renderer.enabled = true;
			Vector3 newpos = cam.ScreenToWorldPoint(new Vector3(screenWidth / 2, screenHeight / 4, 0));
			newpos = new Vector3(newpos.x, newpos.y, 0);
			transform.position = newpos;
		}
		else {
			renderer.enabled = false;
		}
	}

	float posFunc(float t, float target) {
		float logScale = Screen.height / 2;
		float calc = Mathf.Log (t * 1.1f) * logScale;
		if (calc < target) {
			return calc;
		} else {
			isAnimating = false;
			isDoneAnimating = true;
		}
		return (calc < target) ? calc : target;
	}

	void popUp () {
		float targetHeight = screenHeight;
		float vert = posFunc ((Time.time) - popUpStartTime, screenHeight / 4);
		Vector3 newpos = new Vector3 (screenWidth / 2, vert, 0);
		Vector3 transformed = cam.ScreenToWorldPoint (newpos);
		transformed = new Vector3 (transformed.x, transformed.y, 0);
		transform.position = transformed;
	}
}
