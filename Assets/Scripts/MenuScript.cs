using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject controlsMenu;
	bool whatMenu = false;
	public void Clicked()
	{
		// False = Main Menu
		whatMenu = !whatMenu;
		if(whatMenu == true)
		{
			mainMenu.SetActive(false);
			controlsMenu.SetActive(true);
		} else
		{
			mainMenu.SetActive(true);
			controlsMenu.SetActive(false);
		}
	}
}
