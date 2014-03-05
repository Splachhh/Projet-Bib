using UnityEngine;
using System.Collections;

public class TaupeController : EnnemyController 
{
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_viewDistance = 15;
		m_hp = 20;
		m_degat = 12;
		m_timeAttack = 1.5f;
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
	}
}