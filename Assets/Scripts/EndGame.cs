using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!IsEnemy ())
		{
			Application.LoadLevel("EndGame1");
		}
		else if(!isPlayer())
		{
			Application.LoadLevel ("EndGame2");
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
	
	bool isPlayer()
	{
		GameObject player = GameObject.FindGameObjectWithTag("MainChar");
		ColliderDetector coll = player.GetComponent<ColliderDetector>();
		if(coll != null)
		{
			if(coll.health <=0)
			{
				return false;
			}
			else
			{
				return true;
			}
		} 
		else{
			return false;
			}
	}
}
