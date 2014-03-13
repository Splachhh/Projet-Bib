using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour 
{
	
	private bool paused = false;
	public AudioManager aManager;
	
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
			if (!paused) 
			{
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
		                    "Option"))
		{
			option();
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
	
	void option()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		style.alignment = TextAnchor.UpperCenter;
		style = new GUIStyle();
		style.fontSize = 19;
		style.alignment = TextAnchor.UpperCenter;

		float buttonWidth = 128f;
		float buttonHeight = 32f;

		int idButton = 0;

		if(GUI.Button(new Rect((Screen.width - buttonWidth) / 2f + 1f,
		                       0.3f * Screen.height + buttonHeight * 1.33f * idButton++,
		                       buttonWidth,
		                       buttonHeight), 
		              "Musique suivante"))
		{
			aManager.changeTrack();
		}
		if(aManager.getPlayState())
		{
			if(GUI.Button(new Rect((Screen.width - buttonWidth) / 2f + 1f, 
			                       0.3f * Screen.height + buttonHeight * 1.33f * idButton++,
			                       buttonWidth,
			                       buttonHeight),
						"Arreter la musique"))
			{
				aManager.changePlayState();
				aManager.pauseTrack();
			}
		}
		else if(GUI.Button(new Rect((Screen.width - buttonWidth) / 2f + 1f, 
		                            0.3f * Screen.height + buttonHeight * 1.33f * idButton++, 
		                            buttonWidth,
		                            buttonHeight),
		                   "Activer la musique"))
		{
			aManager.changePlayState();
			aManager.startTrack();
		}

		GUI.Label (new Rect((Screen.width - buttonWidth) / 2f + 1f, 
		                    0.3f * Screen.height + buttonHeight * 1.33f * idButton++, 
		                    buttonWidth,
		                    buttonHeight),
		           "Volume de la musique",
		           style);
		aManager.changeVolume (GUILayout.HorizontalSlider (aManager.getVolume(), 0, 1));

		GUILayout.EndArea();
	}
}
