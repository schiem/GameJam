using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collision2D coll) {
				print ("GAAAAH!");
				if (coll.gameObject.tag == "Enemy") {
						Vector2 force = new Vector2 (coll.gameObject.transform.position.x * 200 * -1, coll.gameObject.transform.position.y * 200 * -1);
						knockBack (force);
						//takeDamage(10);
				}
		}

	
	void knockBack(Vector2 direction)
	{
		rigidbody2D.AddForce (direction);
	}
}
