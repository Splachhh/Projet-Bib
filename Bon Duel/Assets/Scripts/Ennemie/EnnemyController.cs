using UnityEngine;
using System.Collections;

public abstract class EnnemyController : MonoBehaviour 
{
	protected NavMeshAgent agent;

	protected PlayerController player;
	protected float m_viewDistance;

	public int m_difficulty;

	protected int m_hp;
	protected int m_degat;

	protected float m_timeAttack;
	private float m_timeLapseAttack = 0f;

	// Use this for initialization
	protected virtual void Start () 
	{
		int dif = GameObject.FindObjectOfType<EnnemyCreator>().getDificulty();
		if(m_difficulty > dif)
			gameObject.SetActive(false);

		agent = GetComponent<NavMeshAgent>() as NavMeshAgent;

		player = FindObjectOfType<PlayerController>() as PlayerController;
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
		m_timeLapseAttack += Time.deltaTime;
		Vector3 distance = player.transform.position - transform.position;
		if(distance.magnitude <= agent.stoppingDistance)
		{
			agent.Stop();
			transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));			                 			           
			if(m_timeLapseAttack > m_timeAttack)
			{
				int degat = Random.Range(m_degat-1, m_degat+1);
				player.majHp(-degat);
				m_timeLapseAttack = 0f;
			}
		}
		else if(distance.magnitude <= m_viewDistance)
			agent.SetDestination(player.transform.position);
		Debug.Log ("hp ennemis" + m_hp);
	}

	public void majHp(int hpChange)
	{
		m_hp += hpChange;
		if(m_hp < 0)
			gameObject.SetActive(false);
	}
}
