using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float maxSpeed = 3.0f;
	public GameObject playerPtr;
	public int health = 100;
	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		Debug.Log (transform.childCount);
		var step = maxSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards (transform.position, playerPtr.transform.position, step);
		FaceCharacter ();

	}

	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "MainChar") {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(10);
		}
	}
	
	
	void FaceCharacter()
	{
				var otherPos = playerPtr.transform.position;
				var pos = transform.position;
				var dir = otherPos - pos;
				var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward); 
		}
		
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
