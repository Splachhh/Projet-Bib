using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	private Menu menu;

	enum Menu 
	{
		MainMenu,
		CreditsMenu
	}

	// Use this for initialization
	void Start () 
	{
		menu = Menu.MainMenu;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if (menu == Menu.MainMenu)
		{
			drawMainMenu();
		}
		else if (menu == Menu.CreditsMenu)
		{
			drawCredits();
		}
	}

	void drawMainMenu()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 50;
		style.alignment = TextAnchor.UpperCenter;
		
		GUI.Label(new Rect((Screen.width - 500f)/2f,
		                   (Screen.height * 0.33f - 40f)/2f,
		                   500f,
		                   40f),
		          "BON DUEL", style);


		float buttonWidth = 128f;
		float buttonHeight = 32f;
		
		int idButton = 0;

		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Jouer"))
		{
			Application.LoadLevel("Map1");
		}
		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Credits"))
		{
			menu = Menu.CreditsMenu;
		}
		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Quitter"))
		{
			Application.Quit();
		}
	}

	void drawCredits()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		style.alignment = TextAnchor.UpperCenter;

		GUI.Label(new Rect((Screen.width - 500f)/2f,
		                   (Screen.height * 0.33f - 40f)/2f,
		                   500f,
		                   40f),
		          "Credits ", style);


		float buttonWidth = 256f;
		float buttonHeight = 19f;
		
		int idButton = 0;

		GUILayout.BeginArea(new Rect((Screen.width - buttonWidth*1.3f)/2f,
				                    0.22f*Screen.height + buttonHeight * 1.33f * idButton++,
				                    buttonWidth*1.3f,
				                    buttonHeight*20));

		style = new GUIStyle();
		style.fontSize = 19;
		style.alignment = TextAnchor.UpperCenter;

		GUI.Label(new Rect(40,
		                   buttonHeight * 1.33f * idButton++,
		                   buttonWidth,
		                   buttonHeight*3),
		          "Realise par :\nMogeot Bastien\nGounon Gregory\nGrandclement Thibaut\nSeyer Romain\nValla Damien\n", style);
		idButton += 5;
		GUI.Label(new Rect(40,
		                   buttonHeight * 1.33f * idButton++,
		                   buttonWidth,
		                   buttonHeight*6),
		          "Musiques et sons de :\n", style);
		idButton += 3;
		GUI.Label(new Rect(40,
		                   buttonHeight * 1.33f * idButton++,
		                   buttonWidth,
		                   buttonHeight*6),
		          "Modeles de :\n", style);
		idButton += 2;

		if (GUI.Button(	new Rect((buttonWidth - 128)/2f +40,
		                         buttonHeight * 1.33f * idButton++,
		                         128,
		                         32),
		               "Retour"))
		{
			menu = Menu.MainMenu;
		}

		GUILayout.EndArea();
	}

}
