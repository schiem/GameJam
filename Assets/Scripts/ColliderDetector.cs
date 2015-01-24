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
	
	void FixedUpdate()
	{
		renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Enemy") {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(10);
		}
	}
	void OnTriggerStay2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Enemy") {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(10);
		}
	}

	void knockBack(Vector2 direction)
	{
		renderer.material.color = Color.red;
		rigidbody2D.AddForce (direction);
	}

	void takeDamage(int amount)
	{
		health = health - amount;
		print(health);
		if (health <= 0) {
			Die ();
			}
		}

	void Die()
	{
		}

}
