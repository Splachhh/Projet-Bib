using UnityEngine;
using System.Collections;

public class EnnemyController : MonoBehaviour 
{
	private NavMeshAgent agent;

	private PlayerController player;
	public float viewDistance;

	public int difficulty;

	// Use this for initialization
	void Start () 
	{
		int dif = GameObject.FindObjectOfType<EnnemyCreator>().getDificulty();
		if(difficulty > dif)
			gameObject.SetActive(false);

		agent = GetComponent<NavMeshAgent>() as NavMeshAgent;

		player = FindObjectOfType<PlayerController>() as PlayerController;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 distance = player.transform.position - transform.position;
		if(distance.magnitude <= viewDistance)
			agent.SetDestination(player.transform.position);
		if(distance.magnitude <= agent.stoppingDistance)
			transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));			                 			           
	}
}
