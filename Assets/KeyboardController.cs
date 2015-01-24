using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 10.0f;

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
	
	}

}
