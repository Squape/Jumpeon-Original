using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameBrain : MonoBehaviour
{
	[Header("Main")]
	public GameObject[] playersToChange;
	public Color unusedPlayerColor;
	int currentPlayer = 0;
	[Header("Tutorial Stuff")]
	public TextMeshProUGUI tutorialText;
	public bool isFirstLevel = false;

	bool checkforq = false;


	void Start()
	{

		if (isFirstLevel)
		{
			tutorialText.text = "Go on the yellow square";
		}

		for (int i = 0; i < playersToChange.Length; i++)
		{
			DisableMovement(playersToChange[i]);
		}
		EnableMovement(playersToChange[currentPlayer]);

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && currentPlayer != playersToChange.Length - 1)
		{
			if (checkforq == true)
			{
				checkforq = false;
				TutorialChange(2);
			}
			currentPlayer++;
			DisableMovement(playersToChange[currentPlayer - 1]);
			EnableMovement(playersToChange[currentPlayer]);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void DisableMovement(GameObject gameobject)
	{
		gameobject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//gameobject.GetComponent<Rigidbody2D>().velocity.y);
		gameobject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
		//gameobject.GetComponent<SpriteRenderer>().color = new Color(82, 82, 82);
		gameobject.GetComponent<SpriteRenderer>().color = unusedPlayerColor;
		gameobject.GetComponent<PlayerController>().canMove = false;
	}
	void EnableMovement(GameObject gameobject)
	{
		gameobject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		gameobject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
		gameobject.GetComponent<PlayerController>().canMove = true;
	}

	public void TutorialChange(int whatchange)
	{
		if (isFirstLevel)
		{
			switch (whatchange)
			{
				case 1:
					TutorialText("Press Q");
					checkforq = true;
					break;
				case 2:
					TutorialText("Now jump on your brother head to finish the level, cool isn't it?");
					break;
			}
		}

	}
	void TutorialText(string text)
	{
		tutorialText.text = text;
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
