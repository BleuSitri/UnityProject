﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
	}

    void Update()
	{
		if(Input.GetMouseButton(0))
		{
			SceneManager.LoadScene("PlayScene");
		}
	}
}
