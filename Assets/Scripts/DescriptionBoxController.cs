using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DescriptionBoxController : MonoBehaviour {
	public TextMesh theText;
	private TextMesh textCopy;
	public float popUpStartTime;
	public bool isAnimating = false;
	public bool isDoneAnimating = false;
	public Camera cam;

	private float screenWidth;
	private float screenHeight;
	public float height;
	public float width;
	private static float X_MARGIN = 0.25f;
	private static float Y_MARGIN = -0.2f;



	// Use this for initialization
	void Start () {
		Vector2 screenSize = Handles.GetMainGameViewSize();
		screenWidth = screenSize.x;
		screenHeight = screenSize.y;
		width = renderer.bounds.size.x;
		height = renderer.bounds.size.y;


	}

	public void Hide() {
		renderer.enabled = false;
		textCopy.renderer.enabled = false;
		Destroy (textCopy);
	}

	// Update is called once per frame
	void Update () {
		//doMessage ("yolo");
		if (isAnimating) {
			renderer.enabled = true;
			popUp();
		} else if (isDoneAnimating) {
			renderer.enabled = true;
			Vector3 newpos = cam.ScreenToWorldPoint(new Vector3(screenWidth / 2, screenHeight / 5, 0));
			newpos = new Vector3(newpos.x, newpos.y, 0);
			transform.position = newpos;
		}
		else {
			renderer.enabled = false;
		}

		float text_x_pos = transform.position.x - (width / 2) + X_MARGIN;
		float text_y_pos = transform.position.y + (height / 2) + Y_MARGIN;
		Vector3 text_newPos = new Vector3 (text_x_pos, text_y_pos, transform.position.z);

		if (textCopy != null) {
			textCopy.transform.position = text_newPos;
		}
	}

	float posFunc(float t, float target) {
		float logScale = Screen.height / 2;
		float calc = (-10 / t) + (target) + 10;
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
		float vert = posFunc ((Time.time) - popUpStartTime, screenHeight / 5);
		Vector3 newpos = new Vector3 (screenWidth / 2, vert, 0);
		Vector3 transformed = cam.ScreenToWorldPoint (newpos);
		transformed = new Vector3 (transformed.x, transformed.y, 0);
		transform.position = transformed;
	}

	public void doMessage (string message) {
		if(isDoneAnimating || isAnimating) {
			isDoneAnimating = false;
			isAnimating = false;
			Hide();
		}
		isAnimating = true;
		popUpStartTime = Time.time;

		float text_x_pos = transform.position.x - (width / 2) + X_MARGIN;
		float text_y_pos = transform.position.y + (height / 2) + Y_MARGIN;
		Vector3 text_newPos = new Vector3 (text_x_pos, text_y_pos, transform.position.z);

		textCopy = (TextMesh)Instantiate (theText, text_newPos, Quaternion.identity);
		textCopy.renderer.enabled = true;
		textCopy.text = message;
	}
}
