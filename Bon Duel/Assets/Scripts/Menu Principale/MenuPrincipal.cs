using UnityEngine;
using System.Collections;

public class MenuPrincipal : SurvoleSouris 
{
	// Boutons disponibles
	public bool BoutonQuitter = false;
	public bool BoutonJouer = false;
	public bool BoutonInstructions = false;
	public bool BoutonCredits = false;
	public bool BoutonFacile = false;
	public bool BoutonMoyen = false;
	public bool BoutonDifficile = false;
	public bool BoutonRetour = false;

	public LevelDifficulty lvl;
	
	private bool menu = false;
	private bool menuNiveau = false;
	private bool menuInstruction = false;
	private bool menuCredit = false;

	// Use this for initialization
	void Start () 
	{
	}

	void afficherMenu(bool menuP, bool menuN, bool menuI, bool menuC)
	{
		menu = menuP;
		menuNiveau = menuN;
		menuInstruction = menuI;
		menuCredit = menuC;
		MenuPrincipal[] tabText = FindObjectsOfType<MenuPrincipal>() as MenuPrincipal[];
		foreach(MenuPrincipal txt in tabText)
		{
			txt.GetComponent<MeshRenderer>().enabled = !menuP;
		}
	}

	void OnMouseUp()
	{
		afficherMenu(true, false, false, false);
		if(menu)
		{
			if(BoutonQuitter)
				Application.Quit();

			if(BoutonJouer)
			{	
				afficherMenu(false, true, false, false);
				return;
			}
			
			if (BoutonInstructions)
			{
				afficherMenu(false, false, true, false);
				return;
			}
			
			if (BoutonCredits)
			{
				afficherMenu(false, false, false, true);
				return;
			}
		}

		else if(menuNiveau)
		{
			if(BoutonFacile)
			{	
				lvl.difficult = 0;
				Application.LoadLevel("Map1");
			}
			if(BoutonMoyen)
			{	
				lvl.difficult = 1;
				Application.LoadLevel("Map1");
			}
			if(BoutonDifficile)
			{	
				lvl.difficult = 2;
				Application.LoadLevel("Map1");
			}
			if(BoutonRetour)
			{
				afficherMenu(false, true, true, true);
				return;
			}
		}

		else if(menuInstruction)
		{
			if(BoutonRetour)
			{
				afficherMenu(false, true, true, true);
				return;
			}
		}

		else if(menuCredit)
		{
			if(BoutonRetour)
			{
				afficherMenu(false, true, true, true);
				return;
			}
		}
	}
}
