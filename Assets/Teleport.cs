using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate(){
	/**
		if(Random.Range(0, 1000) == 5)
		{
			GameObject background = GameObject.FindGameObjectWithTag("Background");
			var size = background.renderer.bounds.size;
			float new_x = Random.Range (background.transform.position.x, size.x + background.transform.position.x);
			float new_y = Random.Range (background.transform.position.y, size.y + background.transform.position.y);
			Vector3 rand_tele = new Vector3(new_x, new_y, 0);
			transform.position = rand_tele;
		}
		*/
		EnemyBehavior enem = GetComponent<EnemyBehavior>();
		
		float speed_gain = (float)500/(enem.health + 200);
		enem.maxSpeed = speed_gain * 5;
	}
}
