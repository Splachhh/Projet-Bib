using UnityEngine;
using System.Collections;

public class EnnemyController : MonoBehaviour 
{
	private NavMeshAgent agent;

	private PlayerController player;
	public float viewDistance;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>() as NavMeshAgent;

		player = FindObjectOfType<PlayerController>() as PlayerController;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 distance = player.transform.position - transform.position;
		if(distance.magnitude <= viewDistance)
			agent.SetDestination(player.transform.position);
	}
}
