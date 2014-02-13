using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	CharacterController control;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float m_gravity = 10000f;
	private float m_speed = 10f;
	private float m_rotationFactor = 2f;

	private int m_hp = 100;
	private int m_degat = 20;

	private float m_distanceAttack = 4.5f;
	private float m_angleAttack = 45f;

	private Animator anim;
	private HashIDs hashID;


	// Use this for initialization
	void Start () 
	{
		control = GetComponent<CharacterController>() as CharacterController;
		anim = GetComponentInChildren<Animator>() as Animator;
		hashID = GetComponent<HashIDs>() as HashIDs;
		anim.SetLayerWeight(0,1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= m_speed;
		moveDirection.y -= m_gravity * Time.deltaTime;
		control.Move(moveDirection * Time.deltaTime);
		if(moveDirection.x != 0 || moveDirection.z != 0)
			anim.SetBool(hashID.isWalking, true);
		else
			anim.SetBool(hashID.isWalking, false);

		// Rotation
		rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
		rotation *= m_rotationFactor * Time.timeScale;
		transform.Rotate(rotation);

		Debug.Log("hp Player" + m_hp);

		mouseHandler();
	}

	void mouseHandler()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			EnnemyController[] tabEnnemies = FindObjectsOfType<EnnemyController>() as EnnemyController[];
			foreach(EnnemyController ennemi in tabEnnemies)
			{
				Vector3 distance = transform.position - ennemi.transform.position;
				if(distance.magnitude <= m_distanceAttack)
				{
					Vector3 vecDir = ennemi.transform.position - transform.position;
					float angle = Vector3.Angle(distance, transform.forward);
					Debug.Log("angle" + angle);
					if(angle <= m_angleAttack && angle >= -m_angleAttack)
					{
						Debug.Log("a que coucou");
						int degat = Random.Range(m_degat-1, m_degat+1);
						ennemi.majHp(-degat);
					}
				}
			}
			anim.SetBool(hashID.isHitting, true);
		}
		else
			anim.SetBool(hashID.isHitting, false);
	}

	public void majHp(int hpChange)
	{
		m_hp += hpChange;
		if(m_hp < 0)
			Debug.Log("Game Over");
	}
}
