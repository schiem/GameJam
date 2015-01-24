using UnityEngine;
using System.Collections;

public class FontFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "UI";
		this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
