using UnityEngine;
using System.Collections;

public class FinDeNiveau : MonoBehaviour 
{
	public Texture m_text;

	public bool m_active;

	private int m_windowWidth;
	private int m_windowHeight;
	private float m_labelHeight = 0;
	private int m_itemSelected = 0;
	private string[] m_toolbarStrings;


	// Use this for initialization
	void Start () 
	{
		m_active = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			m_active = true;
	}

	void OnGUI()
	{
		if(m_active)
		{
			GUI.DrawTexture(new Rect(Screen.width/2-m_text.width/2, Screen.height/2-m_text.height/2, m_text.width, m_text.height), m_text);
			Time.timeScale = 0;
			float buttonWidth = 0.33f * m_windowWidth;
			float buttonHeight = 0.1f * m_windowHeight;
			if (GUI.Button(	new Rect((m_windowWidth-10)/2 - buttonWidth/2,
			                         m_windowHeight - 2*buttonHeight,
			                         buttonWidth,
			                         buttonHeight),
			               "Continuer"))
			{
				Application.LoadLevel("Map_2");
			}

		}
	}
}
