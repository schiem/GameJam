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

	void FaceCharacter()
	{
				var otherPos = playerPtr.transform.position;
				var pos = transform.position;
				var dir = otherPos - pos;
				var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward); 
		}

}
