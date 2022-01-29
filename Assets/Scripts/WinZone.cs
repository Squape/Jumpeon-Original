using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
	public GameObject gameBrain;
	public Animator winMenu;
	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("A");
		if (collision.tag == "Player")
		{
			Win();
		}
	}
	/*void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("B");
		if (collision.gameObject.tag == "Player")
		{
			Win();
		}
	}*/

	public void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Win()
	{
		winMenu.SetTrigger("openMenu");
	}
}
