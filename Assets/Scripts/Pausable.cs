using UnityEngine;
using System.Collections;

public abstract class Pausable : MonoBehaviour {
	abstract public void onPause();
	abstract public void onResume();
}
