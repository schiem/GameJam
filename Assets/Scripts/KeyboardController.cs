using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 10.0f;
	public Vector3 lastPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate(){
				float y_val = Input.GetAxis ("Vertical") * speed;
				float x_val = Input.GetAxis ("Horizontal") * speed;

				transform.Translate (x_val, y_val, 0);

				Animator animate = GetComponent<Animator> ();

				Vector3 curpos = transform.position;

				if (curpos != lastPos) {
						animate.SetBool ("isMoving", true);
				} else {
						animate.SetBool ("isMoving", false);
				}				
				lastPos = curpos;

				//animate.animation ["SwingSword"].wrapMode = WrapMode.Once;
				if (Input.GetButtonDown ("Fire1")) {
						print ("Mutha...");
						animate.SetBool("shouldSwing", true);
				} else {
						animate.SetBool ("shouldSwing", false);
				}




	}

}
