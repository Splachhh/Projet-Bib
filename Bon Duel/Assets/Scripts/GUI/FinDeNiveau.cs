using UnityEngine;
using System.Collections;

public class FinDeNiveau : MonoBehaviour 
{
	public Texture m_text;

	public bool m_active;

	private int m_windowWidth;
	private int m_windowHeight;


	// Use this for initialization
	void Start () 
	{
		m_active = false;
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			m_active = true;
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
	}

	void OnGUI()
	{
		if(m_active)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2f - m_text.width / 2f,
			                         Screen.height / 2f - m_text.height / 2f, 
			                         m_text.width, 
			                         m_text.height), 
			                m_text);

			Time.timeScale = 0;
			float buttonWidth = 128f;
			float buttonHeight = 32f;
			
			if (GUI.Button(	new Rect((Screen.width - buttonWidth) / 2f,
			                         2f * Screen.height / 2.2f,
			                         buttonWidth,
			                         buttonHeight),
			               "Continuer"))
			{
				m_active = false;
				Application.LoadLevel("Map_2");
			}

		}
	}
}
