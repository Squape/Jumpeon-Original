using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	static DontDestroy instance;
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		} else
		{
			Destroy(gameObject);
		}
	}

}
