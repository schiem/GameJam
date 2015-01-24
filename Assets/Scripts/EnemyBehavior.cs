using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float maxSpeed = 3.0f;
	public GameObject playerPtr;
	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		Debug.Log (transform.childCount);
		var step = maxSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards (transform.position, playerPtr.transform.position, step);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
