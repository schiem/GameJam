using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 100.0f;
	public Vector3 lastPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate(){
		//float y_val = Input.GetAxis ("Vertical") * speed;
		//float x_val = Input.GetAxis ("Horizontal") * speed;

		//transform.Translate (x_val, y_val, 0);
		Vector2 forcing = new Vector2 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed);
		rigidbody2D.AddForce (forcing);

		Animator animate = GetComponent<Animator>();

		Vector3 curpos = transform.position;

		if(curpos != lastPos) {
			animate.SetBool ("isMoving", true);
		} else {
			animate.SetBool ("isMoving", false);
		}
		lastPos = curpos;

		float doSwingSword = Input.GetAxisRaw ("Fire1");
		print (doSwingSword);
		if (doSwingSword != 0.0f) {
						animate.SetBool ("shouldSwing", true);
				} else {
						animate.SetBool ("shouldSwing", false);
				}


	}

}
