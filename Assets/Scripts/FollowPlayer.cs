using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject mainChar;
	public Vector3 playerOffset = GameObject.FindGameObjectsWithTag("Sword")[0].transform.position - GameObject.FindGameObjectsWithTag("MainChar")[0].transform.position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		Vector3 mcPos = mainChar.transform.position;
		float new_x = mcPos.x + playerOffset.x;
		float new_y = mcPos.y + playerOffset.y;
		Vector3 newPos = new Vector3(new_x,new_y,transform.position.z);
		transform.position = newPos;
		}
}
