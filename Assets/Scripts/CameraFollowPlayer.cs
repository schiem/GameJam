using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject mainChar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		Vector3 mcPos = mainChar.transform.position;
		float new_x = mcPos.x;
		float new_y = mcPos.y;
		Vector3 newPos = new Vector3(new_x,new_y,transform.position.z);
		transform.position = newPos;
	}
}
