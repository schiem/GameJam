using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 100.0f;
	public Vector3 lastPos;
	public bool swinging;
	public int health = 100;
	public MonoBehaviour textBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate(){

		Vector2 forcing = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		float current_magnitude = forcing.magnitude;
		if (current_magnitude > 1) {
			float ratio = (1 / current_magnitude);
			forcing.Scale(new Vector2(ratio, ratio));
		}

		forcing *= speed;

		rigidbody2D.AddForce (forcing);

		GetKeys ();
		UpdateCamera();
		UpdateAnimations ();


	}

	void GetKeys() {
		if (Input.GetKeyDown ("escape")) {
			Object[] objects = FindObjectsOfType(typeof(GameObject));
			foreach (GameObject go in objects) {
				go.SendMessage("onPause", SendMessageOptions.DontRequireReceiver);
			}
			foreach
			Debug.Log ("escape pressed.");
			((DescriptionBoxController) textBox).isAnimating = true;
			((DescriptionBoxController) textBox).popUpStartTime = Time.time;
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
		
				float doSwingSword = Input.GetAxisRaw ("Fire1");
				print (doSwingSword);
				if (doSwingSword != 0.0f) {
					swinging = true; 
						animate.SetBool ("shouldSwing", true);
		} else {
						swinging = false;
						animate.SetBool ("shouldSwing", false);

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
