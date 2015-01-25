﻿using UnityEngine;
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
	private static float X_MARGIN = 0.40f;
	private static float Y_MARGIN = -0.24f;

	private int MAX_STRING_LENGTH = 36;
	private Queue<string> messageQueue;
	private Queue<Color> colorQueue;
	
	private float waitStartTime;
	private float timeToWait;
	
	public AudioClip nuts;


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
		if(waitStartTime != 0) {
			if(Time.time - waitStartTime > timeToWait) {
				waitStartTime = 0;
				resumeStuff();
			}
			return;
		}
	
		if(messageQueue != null && !isDoneAnimating && !isAnimating) {
			if(messageQueue.Count != 0) {
				string m = messageQueue.Dequeue();
				Color c = colorQueue.Dequeue();
				showTextBoxAndPause(m, c);
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
		float calc = (-10 / (t+0.0001f)) + (target) + 10;
		if (calc < target) {
			return calc;
		} else {
			isAnimating = false;
			isDoneAnimating = true;
		}
		return (calc < target) ? calc : target;
	}

	void popUp () {
		//Debug.Log ("popupstarttime:" + popUpStartTime.ToString());
		float vert = posFunc ((Time.time) - popUpStartTime, screenHeight / 5);
		Vector3 newpos = new Vector3 (screenWidth / 2, vert, 0);
		Vector3 transformed = cam.ScreenToWorldPoint (newpos);
		transformed = new Vector3 (transformed.x, transformed.y, 0);
		transform.position = transformed;
	}

	public void doMessage (string message, Color colorToWrite) {
		
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
		textCopy.color = colorToWrite;
		Debug.Log (colorToWrite.r.ToString() +  message.ToString ());
		textCopy.renderer.enabled = true;
		textCopy.text = splitMessageString(message);

	}
	
	public void pauseStuff() {
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onPause();
		}
	}
	
	public void resumeStuff() {
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onResume();
		}
	}

	public void showTextBoxAndPause(string message, Color color) {
		if(message == "pause") {
			timeToWait = 1.2f;
			waitStartTime = Time.time;
			pauseStuff ();
			return;
		}
		
		if (message == "Nuts." || message == "Nuts!") {
			audio.PlayOneShot(nuts, 5.0f);
		}
		pauseStuff ();
		doMessage(message, color);
	}
	
	public void destroyTextBoxAndResume() {
		if(waitStartTime != 0) return;
		resumeStuff ();
		isDoneAnimating = false;
		isAnimating = false;
		Hide();
		
		if(messageQueue != null && messageQueue.Count != 0) {
			string m = messageQueue.Dequeue();
			Color c = colorQueue.Dequeue();
			showTextBoxAndPause(m, c);
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
	
	public void displayMultipleMessages(Queue<string> messages, Queue<Color> colors) {
		messageQueue = new Queue<string>(messages);
		colorQueue = new Queue<Color>(colors);
	}
}
