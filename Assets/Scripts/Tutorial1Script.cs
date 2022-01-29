using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1Script : MonoBehaviour
{
	public GameObject gameBrain;
	bool x = false;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && x == false)
		{
			x = true;
			gameBrain.GetComponent<GameBrain>().TutorialChange(1);
		}
	}
}
