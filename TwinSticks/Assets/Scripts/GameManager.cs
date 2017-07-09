﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
	// Use this for initialization
	void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
    }
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }
	}
}
