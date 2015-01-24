using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float maxSpeed = 3.0f;
	public KeyboardController key_control;
	public GameObject playerPtr;
	public int health;
	public int attack;
	public Sprite dead_sprite;
	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		//Debug.Log (transform.childCount);
		renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		var step = maxSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards (transform.position, playerPtr.transform.position, step);
		FaceCharacter ();

	}

	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Sword" && key_control.swinging) {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(attack);
		}
	}
	
	void OnTriggerStay2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Sword" && key_control.swinging) {
			Vector2 otherpos = coll.gameObject.transform.position;
			var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
			Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
			knockBack (force);
			takeDamage(attack);
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
		renderer.material.color = Color.red;
		rigidbody2D.AddForce (direction);
	}
	
	void takeDamage(int amount)
	{
		health = health - amount;
		if (health <= 0) {			
			Die ();
		}
	}
	
	void Die()
	{
		renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		collider2D.enabled = false;
		GameObject.Destroy(rigidbody2D);
		GetComponent<SpriteRenderer>().sprite = dead_sprite;
		//collider2.enabled = false;
		GameObject.Destroy(this);
	}
	

}
