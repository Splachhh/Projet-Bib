using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneriqueDebut : MonoBehaviour 
{

	private bool m_isActive = false;

	//Fenetre d'affichage des instructions
	private Rect m_instructionsWindowRect;

	// Choix d'afficher les instructions ou l'histoire
	private int m_itemSelected = 0;
	// Nom des boutons
	private string[] m_toolbarStrings;

	private List<string> m_instructions;
	private List<string> m_histoire;
	
	// variable de tailles (en %)
	private float m_coefWidth = 0.4f;
	private float m_coefHeight = 0.66f;
	
	// Déterminés automatiquement
	private int m_windowWidth;
	private int m_windowHeight;
	private float m_labelHeight = 0;

	// Use this for initialization
	void Start () 
	{
		m_toolbarStrings = new string[2];
		m_toolbarStrings[0] = "Instructions";
		m_toolbarStrings[1] = "Histoire";

		initHistoireList ();
		initInstructionsList ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnGUI()
	{
		if (!m_isActive)
			return;

		// Détermine les dimensions de la fenetre à afficher
		m_windowWidth = (int)(Screen.width*m_coefWidth);
		m_windowHeight = (int)(Screen.height*m_coefHeight);

		// Fenetre à afficher
		m_instructionsWindowRect = new Rect(Screen.width/2 - m_windowWidth/2,
		                             Screen.height/2 - m_windowHeight/2,
		                             m_windowWidth,
		                             m_windowHeight);
		m_instructionsWindowRect = GUI.Window(0, m_instructionsWindowRect, instructionsWindowOpen, "Instructions");
	}

	void instructionsWindowOpen(int windowId)
	{
		// Zone de dessin + scroll bars
		GUILayout.BeginArea(new Rect(10, 20, m_windowWidth, m_windowHeight));
		
		// Bouton sélectionné
		m_itemSelected = GUI.Toolbar(new Rect(0, 0, 180, 30), m_itemSelected, m_toolbarStrings);

		// Affichage selon l'onglet sélectionné
		if (m_itemSelected == 0) 
		{
			// Texte à afficher
			string textDisplay = textToDisplay(m_instructions);
			GUIContent content = new GUIContent(textDisplay);
			// Largeur des instructions
			float labelWidth = m_windowWidth-60;
			GUIStyle myStyle = new GUIStyle();
			// Détermine la hauteur des  instructions pour la largeur précédente
			float labelHeight = myStyle.CalcHeight( content, labelWidth);
			m_labelHeight = labelHeight + countNewLine(m_instructions)*10 + 20;
			
			// Affiche le texte
			GUI.Label(new Rect(10, 50, labelWidth, m_labelHeight), textDisplay);
		} 
		else 
		{
			// Texte à afficher
			string textDisplay = textToDisplay(m_histoire);

			GUIContent content = new GUIContent(textDisplay);
			// Largeur des instructions
			float labelWidth = m_windowWidth-60;
			GUIStyle myStyle = new GUIStyle();
			// Détermine la hauteur des  instructions pour la largeur précédente
			float labelHeight = myStyle.CalcHeight( content, labelWidth)*2;

			m_labelHeight = labelHeight + countNewLine(m_histoire)*10 + 20;

			// Affiche le texte
			GUI.Label(new Rect(10, 50, labelWidth, m_labelHeight), textDisplay);
		}

		// Bouton suivant
		float buttonWidth = 0.33f * m_windowWidth;
		float buttonHeight = 0.1f * m_windowHeight;
		if (GUI.Button(	new Rect((m_windowWidth-10)/2 - buttonWidth/2,
		                         m_windowHeight - 2*buttonHeight,
		                         buttonWidth,
		                         buttonHeight),
		               	"Suivant"))
		{
			m_itemSelected++;
			if (m_itemSelected >= m_toolbarStrings.Length)
				Application.LoadLevel("Map1");
		}

		GUILayout.EndArea ();
	}

	public void setActive(bool state)
	{
		m_isActive = state;
	}

	public bool getActive()
	{
		return m_isActive;
	}

	void initInstructionsList()
	{
		// Liste des textes à afficher dans les instructions
		// Affichés dans l'ordre ci-dessous
		// (mettre \n pour saut d'une ligne)
		m_instructions = new List<string>();

		m_instructions.Add ("Z : déplacement avant");
		m_instructions.Add ("\n");
		m_instructions.Add ("Q : déplacement arrière");
		m_instructions.Add ("\n");
		m_instructions.Add ("S : déplacement gauche");
		m_instructions.Add ("\n");
		m_instructions.Add ("D : déplacement droit");
		m_instructions.Add ("\n");
		m_instructions.Add ("Clic gauche : attaque");
		m_instructions.Add ("\n");
		m_instructions.Add ("Molette : zoom");
		m_instructions.Add ("\n");
		m_instructions.Add ("Echap : pause");
		m_instructions.Add ("\n");
		m_instructions.Add ("Tabulation : changement de personnage");
	}

	void initHistoireList()
	{
		// Liste des textes à afficher dans l'histoire
		// Affichés dans l'ordre ci-dessous
		// (mettre \n pour saut d'une ligne)
		m_histoire = new List<string>();
		
		m_histoire.Add ("Le professeur Chêne est le dernier arbre de son espèce, suite aux premières expériences humaines avec les OGM qui décima tous les siens. Une fois les expériences terminées, le processus testé sur les arbres était enfin fonctionnel. Les humains modifièrent donc les animaux et les légumes pour leur donner conscience et vie. Mais les animaux causèrent la perte de la race humaine.");
		m_histoire.Add ("\n");
		m_histoire.Add ("\n");
		m_histoire.Add ("Dans ce monde ravagé par les pesticides et autres OGM,  les légumes sont devenus de redoutables guerriers. Les animaux qui depuis des siècles se nourrissent de ces inoffensifs êtres vivants ne sont plus de taille à les vaincre. Une guerre sans merci voit le jour.");
		m_histoire.Add ("\n");
		m_histoire.Add ("\n");
		m_histoire.Add ("Le professeur organisa la résistance contre les animaux. Il choisit 5 légumes sous son aile, et les forma au combat. A chaque légumes sa technique ! Puis le professeur disparut dans de mystérieuses circonstances.");
		m_histoire.Add ("\n");
		m_histoire.Add ("\n");
		m_histoire.Add ("Les cinq légumes décidèrent alors de se séparer et de partirent à la recherche de leur mentor. La carotte de retour à son village, découvre le ravage causé par l’attaque surprise du général lapin, prend conscience de la nécessité de devoir reformer l’équipe pour affronter l’ennemi, et mettre fin à la guerre.");
	}

	string textToDisplay(List<string> listText)
	{
		string textToDisplay = "";
		
		for (int i = 0 ; i < listText.Count ; i++)
		{
			if (listText[i] == "\n")
				textToDisplay += System.Environment.NewLine;
			else
				textToDisplay += listText[i];
		}
		
		return textToDisplay;
	}

	int countNewLine(List<string> listText)
	{
		int nbNewLine = 0;
		for (int i = 0 ; i < listText.Count ; i++)
		{
			if (listText[i] == "\n")
				nbNewLine++;
		}
		return nbNewLine;
	}
}
