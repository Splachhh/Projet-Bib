using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour 
{
	
	private bool paused = false;
	
	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!paused) {
				Screen.lockCursor = false;
				Screen.showCursor = true;
				Time.timeScale = 0;
				paused = true;
			}
		}
	}

	
	void OnGUI() 
	{
		
		if (!paused)
			return;
		
		float buttonWidth = 128f;
		float buttonHeight = 32f;
		
		int idButton = 0;
		
		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Continuer"))
		{
			Time.timeScale = 1;
			paused = false;
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}
		else if (GUI.Button( new Rect((Screen.width - buttonWidth)/2f,
		                              0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                              buttonWidth,
		                              buttonHeight),
		                    "Recommencer"))
		{
			Time.timeScale = 1;
			paused = false;
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (GUI.Button( new Rect((Screen.width - buttonWidth)/2f,
		                              0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                              buttonWidth,
		                              buttonHeight),
		                    "Retourner au menu"))
		{
			Application.LoadLevel("Menu");
		}
		
	}
}
