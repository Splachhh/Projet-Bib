using UnityEngine;
using System.Collections;

public class RatController : EnnemyController 
{
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_viewDistance = 30;
		m_hp = 40;
		m_degat = 6;
		m_timeAttack = 1.5f;
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
	}
}