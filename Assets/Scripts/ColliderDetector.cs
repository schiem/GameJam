using UnityEngine;
using System.Collections;

public class ColliderDetector : MonoBehaviour {
	public int health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D coll) {
		KeyboardController controller = GetComponent<KeyboardController>();
		
		if (coll.gameObject.tag == "Enemy" && !controller.swinging) {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(10);
		}
	}
	
	/*
	void OnTriggerStay2D(Collider2D coll){
		KeyboardController controller = GetComponent<KeyboardController>();
		
		if (coll.gameObject.tag == "Enemy" && !controller.swinging) {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(10);
		}
	}

	*/
	
	void knockBack(Vector2 direction)
	{
		rigidbody2D.AddForce (direction);
	}

	void takeDamage(int amount)
	{
		health = health - amount;
		if (health <= 0) {
			print ("Here!");

			Die ();
			}
		}

	void Die()
	{
		}

}
