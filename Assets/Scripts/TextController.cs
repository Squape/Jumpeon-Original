using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
	public Animator transition;
    public TextMeshProUGUI sentence;
    public string[] sentences;
    int currentSentence = 0;
	public GameObject gameBrain;
	void Start()
	{
		sentence.text = sentences[0];
	}
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			if(currentSentence+ 1 < sentences.Length)
			{
				currentSentence++;
				sentence.text = sentences[currentSentence];
			} else
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
    }

}