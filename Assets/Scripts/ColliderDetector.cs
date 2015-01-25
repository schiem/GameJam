using UnityEngine;
using System.Collections;

public class ColliderDetector : Pausable {
	public int health = 100;
	public int attack = 10;
	public AudioClip die;
	
	// Use this for initialization
	public Hashtable scenes = new Hashtable();
	void Start () {
		scenes.Add (1, "scene1");
		scenes.Add (2, "scene2");
		scenes.Add (3, "scene3");
		scenes.Add (4, "scene4");
		scenes.Add (5, "scene5");
		scenes.Add (-1, "MainScreen");
		scenes.Add (6, "EndGame1");
		scenes.Add (7, "EndGame2");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate()
	{
		renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(!paused) {
			if (coll.gameObject.tag == "Enemy") {
				Vector2 otherpos = coll.gameObject.transform.position;
				var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
				Vector2 force = new Vector2 (dif.x * 00 * -1, dif.y * 00 * -1);
				knockBack (force);
				EnemyBehavior enemy = coll.gameObject.GetComponent<EnemyBehavior>();
				takeDamage(enemy.attack);
			}
			else if(coll.gameObject.tag == "Tesla")
			{
				Vector2 otherpos = coll.gameObject.transform.position;
				var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
				Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
				knockBack (force);
				takeDamage(500);
			}
			else if(coll.gameObject.tag == "Door")
			{
				OpenDoor door = coll.gameObject.GetComponent<OpenDoor>();
				if(door != null)
				{
					Application.LoadLevel((string)scenes[door.level + 1]);
				}
			}
		}
	}
	/**
	void OnTriggerStay2D(Collider2D coll) {
		if(!paused) {
			if (coll.gameObject.tag ==  "Enemy") {
				Vector2 otherpos = coll.gameObject.transform.position;
				var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
				Vector2 force = new Vector2 (dif.x * 00 * -1, dif.y * 00 * -1);
				knockBack (force);
				EnemyBehavior enemy = coll.gameObject.GetComponent<EnemyBehavior>();
				takeDamage(enemy.attack);
			}
			else if(coll.gameObject.tag == "Tesla")
			{
				Vector2 otherpos = coll.gameObject.transform.position;
				var dif = new Vector2(otherpos.x - transform.position.x, otherpos.y - transform.position.y);
				Vector2 force = new Vector2 (dif.x * 2000 * -1, dif.y * 2000 * -1);
				knockBack (force);
				takeDamage(500);
			}
		}
	}
	*/

	void knockBack(Vector2 direction){
		renderer.material.color = Color.red;
		rigidbody2D.AddForce (direction);
	}

	void takeDamage(int amount)
	{
		health = health - amount;
		print(health);
		if (health <= 0) {
			
			AudioSource source = GetComponent<AudioSource>();
			source.PlayOneShot(die, 10.0f);
			System.Threading.Thread.Sleep(1000);
			Die ();
			}
		}

	void Die()
	{
		Application.LoadLevel("MainScreen");
		}
		


}
