using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public bool door_open = false;
	public Sprite open_door;
	public int level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!IsEnemy())
		{
			openDoor();
		}
	
	}
	
	bool IsEnemy()
	{
		foreach(GameObject enem in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			EnemyBehavior enem_behav = enem.GetComponent<EnemyBehavior>();
			if(enem_behav != null)
			{
				if(enem_behav.health > 0)
				{
					return true;
				}
			}
		}
		return false;
	}
	
	void openDoor()
	{
		door_open = true;
		GetComponent<SpriteRenderer>().sprite = open_door;
	}
}
