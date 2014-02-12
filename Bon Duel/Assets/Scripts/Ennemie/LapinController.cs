using UnityEngine;
using System.Collections;

public class LapinController : EnnemyController 
{
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_viewDistance = 20;
		m_hp = 60;
		m_degat = 10;
		m_timeAttack = 1.5f;
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
	}
}
