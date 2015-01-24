using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject mainChar;
	public Vector3 offset = new Vector3(.156f, -.019f, 0.0f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		Vector3 mcPos = mainChar.transform.position;
		float new_x = mcPos.x + offset.x;
		float new_y = mcPos.y + offset.y;
		Vector3 newPos = new Vector3(new_x,new_y,transform.position.z);
		transform.position = newPos;
		
		transform.rotation = mainChar.transform.rotation;
		}
}
