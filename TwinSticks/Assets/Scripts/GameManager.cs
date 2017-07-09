using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float fixedDeltaTime;
    private bool isPaused = false;
	// Use this for initialization
	void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
        fixedDeltaTime = Time.fixedDeltaTime;

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
        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            ResumeGame();
            isPaused = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            PauseGame();
            isPaused = true;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    }
}
