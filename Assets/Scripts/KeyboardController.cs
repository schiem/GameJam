using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardController : Pausable {
	public float speed = 100.0f;
	public Vector3 lastPos;
	public bool swinging;
	public MonoBehaviour textBox;

	/*
	public Vector2 savedVelocity;
	public float savedAngularVelocity;
	*/	
	public AudioClip swingSound;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (!paused) {
			Vector2 forcing = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			float current_magnitude = forcing.magnitude;
			if (current_magnitude > 1) {
					float ratio = (1 / current_magnitude);
					forcing.Scale (new Vector2 (ratio, ratio));
			}

		forcing *= speed;

			rigidbody2D.AddForce (forcing);
			UpdateAnimations ();
			UpdateCamera ();
		}

		GetKeys ();
	}
/*
	void showTextBoxAndPause() {
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onPause();
		}
		tbox.doMessage("The quick brown fox jumps over the lazy dog.");
	}

	void destroyTextBoxAndResume() {
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onResume();
		}
		
		tbox.isDoneAnimating = false;
		tbox.isAnimating = false;
		tbox.Hide();
	}
	*/

	void GetKeys() {
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		if (Input.GetKeyDown ("escape")) {
			if(tbox.isDoneAnimating || tbox.isAnimating) {
				tbox.destroyTextBoxAndResume();
			} else {
				/*
				tbox.showTextBoxAndPause("     PAUSED     ");
				*/
				Queue<string> messages = new Queue<string>(new[] {"A dark night in a city that knows how to keep its secrets.",
															      "But one man is still trying to find the answers to life's persistent questions:",
															      "Guy noir, private eye."});
			    tbox.displayMultipleMessages(messages);
			}
		}
		if (Input.GetKeyDown ("return")) {
			tbox.destroyTextBoxAndResume();
		}
	}

	void UpdateAnimations()
	{
		Animator animate = GetComponent<Animator> ();
		
		Vector3 curpos = transform.position;
		
		if (curpos != lastPos) {
			animate.SetBool ("isMoving", true);
		} else {
			animate.SetBool ("isMoving", false);
		}
		lastPos = curpos;
		
		if(!animate.GetCurrentAnimatorStateInfo(0).IsName ("SwingSword"))
		{
			animate.SetBool ("shouldSwing", false);
			swinging = false;
		}
		float doSwingSword = Input.GetAxisRaw ("Fire1");
		if (doSwingSword != 0.0f) {
			if(swinging != true)
			{
				AudioSource source = GetComponent<AudioSource>();
				source.PlayOneShot(swingSound);
				swinging = true; 
				animate.SetBool ("shouldSwing", true);
			}
		} 
		
		
	}
	

	void UpdateCamera()
	{
		var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
	}



}
