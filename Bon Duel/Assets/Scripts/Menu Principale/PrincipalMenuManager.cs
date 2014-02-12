using UnityEngine;
using System.Collections;

public class PrincipalMenuManager : SurvoleSouris 
{
	//Menus Disponibles
	private bool menu = false;
	private bool menuNiveau = false;
	private bool menuInstruction = false;
	private bool menuCredit = false;

	//Menu principale
	private GameObject Jouer, Instruc, Credit, Quitter;
	private Collider ColJouer, ColInstruc, ColCredit, ColQuitter;

	//Instructions

	//Menu Niveaux
	private GameObject Facile, Moyen, Difficile;
	private Collider ColFacile, ColMoyen, ColDifficile;

	//Retour
	private GameObject Retour;
	private Collider ColRetour;

	//Définition du niveau
	private LevelDifficulty lvl;

	// Use this for initialization
	void Start () 
	{
		SetMenu (true, false, false, false);

		//Acces au script de définition du niveau
		lvl = GameObject.Find ("Level").GetComponent<LevelDifficulty> ();

		//Menu Principale
		Jouer = GameObject.Find ("BoutonJouer");
		Instruc = GameObject.Find ("BoutonInstruction");
		Credit = GameObject.Find ("BoutonCredit");
		Quitter = GameObject.Find ("BoutonQuitter");

		ColJouer = Jouer.GetComponent<Collider> ();
		ColInstruc = Instruc.GetComponent<Collider> ();
		ColCredit = Credit.GetComponent<Collider> ();
		ColQuitter = Quitter.GetComponent<Collider> ();

		//Menu Niveaux
		Facile = GameObject.Find ("BoutonFacile");
		Moyen = GameObject.Find ("BoutonMoyen");
		Difficile = GameObject.Find ("BoutonDifficile");

		ColFacile = Facile.GetComponent<Collider>();
		ColMoyen = Moyen.GetComponent<Collider>();
		ColDifficile = Difficile.GetComponent<Collider>();

		//Retour
		Retour = GameObject.Find ("BoutonRetour");
		ColRetour = Retour.GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		if (transform.name == "BoutonJouer") 
		{
			Debug.Log("Jouer");
			SetMenu (false,true,false,false);
			SetVisibleMenu();
		}

		if (transform.name == "BoutonInstruction") 
		{
			Debug.Log("Instructions");
			SetMenu(false,false,true,false);
			SetVisibleMenu();
		}

		if (transform.name == "BoutonCredit") 
		{
			Debug.Log("Credit");
			SetMenu(false,false,false,true);
			SetVisibleMenu();
		}
		
		if (transform.name == "BoutonQuitter") 
		{
			Debug.Log("Quitter");
			Application.Quit();
		}

		if (transform.name == "BoutonRetour") 
		{
			Debug.Log("Retour en arrière");
			SetMenu(true,false,false,false);
			SetVisibleMenu();
		}

		if (transform.name == "BoutonFacile") 
		{
			Debug.Log("Choix Facile");
			lvl.SetLevel(0);
			Application.LoadLevel("Map1");
		}

		if (transform.name == "BoutonMoyen") 
		{
			Debug.Log("Choix Moyen");
			lvl.SetLevel(1);
			Application.LoadLevel("Map1");
		}

		if (transform.name == "BoutonDifficile") 
		{
			Debug.Log("Choix Difficile");
			lvl.SetLevel(2);
			Application.LoadLevel("Map1");
		}

	}

	void SetMenu(bool menuP, bool menuN, bool menuI, bool menuC)
	{
		menu = menuP;
		menuNiveau = menuN;
		menuInstruction = menuI;
		menuCredit = menuC;
	}

	void SetVisibleMenu()
	{
		if (menu) 
		{
			//Effacement
			Facile.renderer.enabled = false;
			Moyen.renderer.enabled = false;
			Difficile.renderer.enabled = false;
			Retour.renderer.enabled = false;

			//Desactivement Collider
			ColFacile.enabled = false;
			ColMoyen.enabled = false;
			ColDifficile.enabled = false;
			ColRetour.enabled = false;

			//Affichage Menu Principale
			Jouer.renderer.enabled = true;
			Instruc.renderer.enabled = true;
			Credit.renderer.enabled = true;
			Quitter.renderer.enabled = true;

			//Activation des Collider du Menu Principale
			ColJouer.enabled = true;
			ColInstruc.enabled = true;
			ColCredit.enabled = true;
			ColQuitter.enabled = true;
		}

		if (menuNiveau) 
		{
			//Effacement
			Jouer.renderer.enabled = false;
			Instruc.renderer.enabled = false;
			Credit.renderer.enabled = false;
			Quitter.renderer.enabled = false;
			
			//Desactivement Collider
			ColJouer.enabled = false;
			ColInstruc.enabled = false;
			ColCredit.enabled = false;
			ColQuitter.enabled = false;

			//Affichage du choix de niveau
			Facile.renderer.enabled = true;
			Moyen.renderer.enabled = true;
			Difficile.renderer.enabled = true;
			Retour.renderer.enabled = true;
			
			//Activation des collider du choix de niveaux
			ColFacile.enabled = true;
			ColMoyen.enabled = true;
			ColDifficile.enabled = true;
			ColRetour.enabled = true;

		}

		if (menuInstruction) 
		{
			//Effacement
			Jouer.renderer.enabled = false;
			Instruc.renderer.enabled = false;
			Credit.renderer.enabled = false;
			Quitter.renderer.enabled = false;

			//Desactivement Collider
			ColJouer.enabled = false;
			ColInstruc.enabled = false;
			ColCredit.enabled = false;
			ColQuitter.enabled = false;

			//Affichage des instructions
			Retour.renderer.enabled = true;

			//Activation des collider
			ColRetour.enabled = true;
		}

		if (menuCredit) 
		{
			//Effacement
			Jouer.renderer.enabled = false;
			Instruc.renderer.enabled = false;
			Credit.renderer.enabled = false;
			Quitter.renderer.enabled = false;
			
			//Desactivement Collider
			ColJouer.enabled = false;
			ColInstruc.enabled = false;
			ColCredit.enabled = false;
			ColQuitter.enabled = false;

			//Affichage des crédits
			Retour.renderer.enabled = true;
			
			//Activation des collider
			ColRetour.enabled = true;
		}
	}
}
