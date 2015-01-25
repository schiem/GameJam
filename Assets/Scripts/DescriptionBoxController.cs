using UnityEngine;
//using UnityEditor;
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

	private int MAX_STRING_LENGTH = 36;
	private Queue<string> messageQueue;



	// Use this for initialization
	void Start () {
		//Vector2 screenSize = Handles.GetMainGameViewSize();
		screenWidth = Screen.width;
		screenHeight = Screen.height;
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
		if(messageQueue != null && !isDoneAnimating && !isAnimating) {
			if(messageQueue.Count != 0) {
				string m = messageQueue.Dequeue();
				showTextBoxAndPause(m);
			}
		}
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
		Debug.Log ("popupstarttime:" + popUpStartTime.ToString());
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
		textCopy.text = splitMessageString(message);
	}

	public void showTextBoxAndPause(string message) {
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onPause();
		}
		doMessage(message);
	}
	
	public void destroyTextBoxAndResume() {
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onResume();
		}
		
		isDoneAnimating = false;
		isAnimating = false;
		Hide();
		
		if(messageQueue.Count != 0) {
			string m = messageQueue.Dequeue();
			showTextBoxAndPause(m);
		}
	}

	public string splitMessageString(string message) {
		List<string> words = new List<string> (message.Split (' '));
		string newmessage = "";
		int linelength = 0;
		int nextlength;
		foreach (string word in words) {
			nextlength = linelength + word.Length + 1;
			if(nextlength > MAX_STRING_LENGTH) {
				newmessage+="\n";
				linelength=word.Length + 1;
				newmessage = (newmessage + word + " ");
			} else {
				newmessage = (newmessage + word + " ");
				linelength = nextlength;
			}
		}

		return newmessage;
	}
	
	public void displayMultipleMessages(Queue<string> messages) {
		messageQueue = messages;
	}
}
