using UnityEngine;
using System.Collections;

public class SurvoleSouris : MonoBehaviour 
{
	// Use this for initialization
	protected virtual void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnMouseEnter() 
	{
		if (renderer != null)
			renderer.material.color = Color.green;
	}
	
	void OnMouseExit() 
	{
		if (renderer != null)
			renderer.material.color = Color.white;
	}
}
