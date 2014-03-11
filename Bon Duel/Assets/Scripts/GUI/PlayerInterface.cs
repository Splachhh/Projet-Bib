using UnityEngine;
using System.Collections;

public class PlayerInterface : MonoBehaviour 
{
	//SCRIPTS
	private PlayerController playerScript;

	//TEXTURES
	public Texture2D[] m_tabIconPerso;
	public Texture2D m_cercleIcon;
	public Texture2D m_lifeBorder;
	public Texture2D m_lifeInside;

	//DONNEES NUMERIQUES
	private float m_iconWidth = 100;
	private float m_iconHeigh = 100;
	
	private float m_lifeWidth = 250;
	private float m_lifeHeigh = 30;

	private int m_switchNumber = 1;



	//BOOLEEN
	public bool isPlayingCarrot;
	public bool isPlayingTomato;
	public bool isPlayingPotato;
	public bool isPlayingPoireau;
	public bool isPlayingCourge;

	//PERSONNAGES
	private int m_currentCharacter, m_secondCharacter, m_thirdCharacter, m_forthCharacter, m_fifthCharacter;
	private int m_currentCharacterLife, m_secondCharacterLife, m_thirdCharacterLife, m_forthCharacterLife, m_fifthCharacterLife;
	private int[] m_vegetablesLife;
	public GameObject[] tabPlayer;


	private string m_sceneName;
	private int m_sceneId;
	

	// Use this for initialization
	void Start () 
	{
		//Reconnaissance  de la map
		m_sceneName = Application.loadedLevelName;
		string[] split = m_sceneName.Split ('_');
		m_sceneId = int.Parse (split [1]);

		//Récupération du script
		playerScript = GameObject.Find("Players").GetComponentInChildren<PlayerController>();

		//Récupéarion des vies
		m_vegetablesLife = new int[5];
		GetVegetablesLife();

		//Initialisation des éléments
		ActualiseCurrentCharacter(true,false,false,false,false);
		SetPlayer ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Activation du switch à la map 2
		if(m_sceneId >= 2)
		{
			//m_availibleCharacters = m_sceneId;
			//Changement du personnage courant a l'aide de la touche Tab
			if(Input.GetKeyDown(KeyCode.Tab))
			{
				m_switchNumber ++;
				
				if(m_switchNumber > m_sceneId+1)	
				{
					m_switchNumber = 1;
				}
				
				SetPlayer();
				Debug.Log("switch : " + m_switchNumber.ToString());
			}
		}

		//Actualisation de la vie
		m_currentCharacterLife = playerScript.getHp();
		if(m_currentCharacterLife < 0)
		{
			m_currentCharacterLife = 0;
		}
	}

	void OnGUI()
	{
		if (m_sceneId >= 1) 
		{
			//Barre de vie de la Carotte
			GUI.DrawTexture(new Rect(175, 50, (m_currentCharacterLife*(m_lifeWidth-5)/playerScript.getHpMax()), m_lifeHeigh), m_lifeInside);
			GUI.DrawTexture(new Rect(175, 50, m_lifeWidth, m_lifeHeigh), m_lifeBorder);
			
			//Cercle et Tete de la Carotte
			GUI.DrawTexture(new Rect(80,10, m_iconWidth, m_iconHeigh), m_cercleIcon);
			GUI.DrawTexture(new Rect(80,10, m_iconWidth, m_iconHeigh), m_tabIconPerso[m_currentCharacter]);

			if (m_sceneId >= 2) 
			{
				//Barre de vie de la Tomate
				GUI.DrawTexture(new Rect(105,70 + m_lifeHeigh*2, (m_secondCharacterLife*(m_lifeWidth-53)/100), m_lifeHeigh-5), m_lifeInside);
				GUI.DrawTexture(new Rect(105,70 + m_lifeHeigh*2, m_lifeWidth-50, m_lifeHeigh-5), m_lifeBorder);
				
				//Cercle et Tete de la Tomate
				GUI.DrawTexture(new Rect(30,10+m_iconHeigh - 15,m_iconWidth-20,m_iconHeigh-20), m_cercleIcon);
				GUI.DrawTexture(new Rect(30,10+m_iconHeigh - 15,m_iconWidth-20,m_iconHeigh-20), m_tabIconPerso[m_secondCharacter]);
				
				//Barre de vie de la Courge
				GUI.DrawTexture(new Rect(80,90 + m_lifeHeigh*4, (m_thirdCharacterLife*(m_lifeWidth-105)/100), m_lifeHeigh-10), m_lifeInside);
				GUI.DrawTexture(new Rect(80,90 + m_lifeHeigh*4, m_lifeWidth-100, m_lifeHeigh-10), m_lifeBorder);
					
				//Cercle et Tete de la Courge
				GUI.DrawTexture(new Rect(15,10+m_iconHeigh*2 - 30,m_iconWidth-30,m_iconHeigh-30), m_cercleIcon);
				GUI.DrawTexture(new Rect(15,10+m_iconHeigh*2 - 30,m_iconWidth-30,m_iconHeigh-30), m_tabIconPerso[m_thirdCharacter]);

				if (m_sceneId >= 3) 
				{
					//Barre de vie de la Patate
					GUI.DrawTexture(new Rect(65,100 + m_lifeHeigh*6, (m_forthCharacterLife*(m_lifeWidth-152)/100), m_lifeHeigh-13), m_lifeInside);
					GUI.DrawTexture(new Rect(65,100 + m_lifeHeigh*6, m_lifeWidth-152, m_lifeHeigh-13), m_lifeBorder);
					
					//Cercle et Tete de la Patate
					GUI.DrawTexture(new Rect(10,m_iconHeigh*3 - 45,m_iconWidth-40,m_iconHeigh-40), m_cercleIcon);
					GUI.DrawTexture(new Rect(10,m_iconHeigh*3 - 45,m_iconWidth-40,m_iconHeigh-40), m_tabIconPerso[m_forthCharacter]);

					//Barre de vie du Poireau
					GUI.DrawTexture(new Rect(65,150 + m_lifeHeigh*6, (m_fifthCharacterLife*(m_lifeWidth-152)/100), m_lifeHeigh-13), m_lifeInside);
					GUI.DrawTexture(new Rect(65,150 + m_lifeHeigh*6, m_lifeWidth-152, m_lifeHeigh-13), m_lifeBorder);
						
					//Cercle et Tete ddu Poireau
					GUI.DrawTexture(new Rect(10,m_iconHeigh*3+60 - 45,m_iconWidth-40,m_iconHeigh-40), m_cercleIcon);
					GUI.DrawTexture(new Rect(10,m_iconHeigh*3+60 - 45,m_iconWidth-40,m_iconHeigh-40), m_tabIconPerso[m_fifthCharacter]);
				}
			}
		}
	}

	//Change l'icone des personnages
	void ChangeCharacterIcon(int a, int b, int c, int d, int e)
	{
		m_currentCharacter = a;
		m_secondCharacter = b;
		m_thirdCharacter = c;
		m_forthCharacter = d;
		m_fifthCharacter = e;
	}

	//Change la vie du personnage
	void ChangeLifeIcon(int a, int b, int c, int d, int e)
	{
		GetVegetablesLife();
		m_currentCharacterLife = m_vegetablesLife[a];
		m_secondCharacterLife = m_vegetablesLife[b];
		m_thirdCharacterLife = m_vegetablesLife[c];
		m_forthCharacterLife = m_vegetablesLife[d];
		m_fifthCharacterLife = m_vegetablesLife[e];
	}

	//Définie le personnage jouer
	void ActualiseCurrentCharacter(bool a, bool b, bool c, bool d, bool e)
	{
		isPlayingCarrot = a;
		isPlayingTomato = b;
		isPlayingCourge = c;
		isPlayingPotato = d;
		isPlayingPoireau = e;
	}

	void GetVegetablesLife()
	{
		m_vegetablesLife[0] = playerScript.getHp();
		/*m_vegetablesLife[1] = playerScript.m_tomatoLife;
		m_vegetablesLife[2] = playerScript.m_courgeLife;
		m_vegetablesLife[3] = playerScript.m_potatoLife;
		m_vegetablesLife[4] = playerScript.m_poireuLife;*/
	}

	void SetPlayer()			//A REFAIRE !!!
	{
		switch (m_switchNumber) 
		{
		//carrote
		case 1 :
			ActualiseCurrentCharacter(true,false,false,false,false);
			ChangeCharacterIcon(0, 1, 2, 3, 4);
			ChangeLifeIcon(0, 1, 2, 3, 4);
			for(int i=0; i<tabPlayer.Length; i++)
			{
				if(i+1 != 1)
					tabPlayer[i].SetActive(false);
				else
					tabPlayer[i].SetActive(true);
			}
			break;

		//tomate
		case 2 :
			ActualiseCurrentCharacter(false,true,false,false,false);
			
			if (m_sceneId == 2)
			{
				ChangeCharacterIcon(1, 2, 0, 3, 4);
				ChangeLifeIcon(1, 2, 0, 3, 4);
				for(int i=0; i<tabPlayer.Length; i++)
				{
					if(i+1 != 2)
						tabPlayer[i].SetActive(false);
					else
						tabPlayer[i].SetActive(true);
				}
			}
			
			if (m_sceneId == 3){
				ChangeCharacterIcon(1, 2, 3, 4, 0);
				ChangeLifeIcon(1, 2, 3, 4, 0);
				for(int i=0; i<tabPlayer.Length; i++)
				{
					if(i+1 != 2)
						tabPlayer[i].SetActive(false);
					else
						tabPlayer[i].SetActive(true);
				}}
			
			break;
		
		//Courge
		case 3 :
			ActualiseCurrentCharacter(false,false,true,false,false);

			if (m_sceneId >= 2){
				ChangeCharacterIcon(2, 3, 0, 1, 4);
				ChangeLifeIcon(2, 3, 0, 1, 4);
				for(int i=0; i<tabPlayer.Length; i++)
				{
					if(i+1 != 3)
						tabPlayer[i].SetActive(false);
					else
						tabPlayer[i].SetActive(true);
				}}
			
			if (m_sceneId >= 3){
				ChangeCharacterIcon(2, 3, 4, 0, 1);
				ChangeLifeIcon(2, 3, 4, 0, 1);
				for(int i=0; i<tabPlayer.Length; i++)
				{
					if(i+1 != 3)
						tabPlayer[i].SetActive(false);
					else
						tabPlayer[i].SetActive(true);
				}}
			
			break;
			
		case 4 :
			ActualiseCurrentCharacter(false,false,false,true,false);
			if (m_sceneId >= 4){
				ChangeCharacterIcon(3, 0, 1, 2, 4);
				ChangeLifeIcon(3, 0, 1, 2, 4);
				for(int i=0; i<tabPlayer.Length; i++)
				{
					if(i+1 != 4)
						tabPlayer[i].SetActive(false);
					else
						tabPlayer[i].SetActive(true);
				}}
			
			if (m_sceneId >= 5){
				ChangeCharacterIcon(3, 4, 0, 1, 2);
				ChangeLifeIcon(3, 4, 0, 1, 2);
				for(int i=0; i<tabPlayer.Length; i++)
				{
					if(i+1 != 4)
						tabPlayer[i].SetActive(false);
					else
						tabPlayer[i].SetActive(true);
				}}
			
			break;
			
		case 5 :
			ActualiseCurrentCharacter(false,false,false,false,true);
			ChangeCharacterIcon(4, 0, 1, 2, 3);
			ChangeLifeIcon(4, 0, 1, 2, 3);
			for(int i=0; i<tabPlayer.Length; i++)
			{
				if(i+1 != 5)
					tabPlayer[i].SetActive(false);
				else
					tabPlayer[i].SetActive(true);
			}
			break;
		}
	}

}
