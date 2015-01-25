using UnityEngine;
using System.Collections;

public abstract class Pausable : MonoBehaviour {

	protected Vector2 savedVelocity;
	protected float savedAngularVelocity;
	public bool paused;

	public void onPause() {
		//if(rigidbody2D != null) {
		savedVelocity = rigidbody2D.velocity;
		savedAngularVelocity = rigidbody2D.angularVelocity;
		rigidbody2D.isKinematic = true;
		paused = true;
	}

	public void onResume() {
		//if(rigidbody2D != null) {
		rigidbody2D.velocity = new Vector2(0, 0);
		rigidbody2D.angularVelocity = 0;
		rigidbody2D.isKinematic = false;
		rigidbody2D.AddForce (savedVelocity, ForceMode2D.Impulse);
		rigidbody2D.AddTorque (savedAngularVelocity, ForceMode2D.Impulse);
		//}
		paused = false;
	}
}
