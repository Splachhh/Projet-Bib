using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	private Vector3 m_origin;
	private List<Vector3> m_pointControl;
	private float m_timeMarche = 5f;
	private float m_timeLapseMarche = 5f;
	private int ind;

	private Animator anim;
	private HashIDs hashID;

	// Use this for initialization
	protected virtual void Start () 
	{
		int dif = GameObject.FindObjectOfType<EnnemyCreator>().getDificulty();
		if(m_difficulty > dif)
			gameObject.SetActive(false);

		agent = GetComponent<NavMeshAgent>() as NavMeshAgent;

		player = FindObjectOfType<PlayerController>() as PlayerController;

		//ajout des point de controls
		m_origin = transform.position;
		m_pointControl = new List<Vector3>();
		m_pointControl.Add(new Vector3(Random.Range(m_origin.x, m_origin.x + 20), m_origin.y, Random.Range(m_origin.z, m_origin.z + 20)));
		m_pointControl.Add(new Vector3(Random.Range(m_origin.x - 20, m_origin.x + 20), m_origin.y, Random.Range(m_origin.z - 20, m_origin.z + 20)));
		m_pointControl.Add(new Vector3(Random.Range(m_origin.x - 20, m_origin.x), m_origin.y, Random.Range(m_origin.z - 20, m_origin.z)));
		m_pointControl.Add(m_origin);

		anim = GetComponentInChildren<Animator>() as Animator;
		hashID = GetComponent<HashIDs>() as HashIDs;
		anim.SetLayerWeight(0,1f);
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
		//maj des timer
		m_timeLapseAttack += Time.deltaTime;
		m_timeLapseMarche += Time.deltaTime;

		//mouvement des ennemis
		Vector3 distance = player.transform.position - transform.position;
		if(distance.magnitude <= agent.stoppingDistance)
		{
			agent.Stop();
			transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));			                 			           
			if(m_timeLapseAttack >= m_timeAttack)
			{
				anim.SetBool(hashID.isHitting, true);
				Debug.Log("J'attaque");
				int degat = Random.Range(m_degat-1, m_degat+1);
				player.majHp(-degat);
				m_timeLapseAttack = 0f;
			}
			else
				anim.SetBool(hashID.isHitting, false);
		}
		else if(distance.magnitude <= m_viewDistance)
			agent.SetDestination(player.transform.position);
		else if(m_timeLapseMarche >= m_timeMarche)
		{
			int i;
			do
			{
				i = Random.Range(0, m_pointControl.Count);
			}
			while(i == ind);

			ind = i;

			agent.SetDestination(m_pointControl[ind]);

			m_timeLapseMarche = 0f;
		}
	
		if(agent.velocity!=Vector3.zero)
		{
			anim.SetBool(hashID.isWalking, true);
			Debug.Log ("Je marche");
		}
		else
		{
			anim.SetBool(hashID.isWalking, false);
			Debug.Log ("Je marche pas");
		}

		Debug.Log ("hp ennemis" + m_hp);
	}

	public void majHp(int hpChange)
	{
		m_hp += hpChange;
		if(m_hp < 0)
			gameObject.SetActive(false);
	}
}
