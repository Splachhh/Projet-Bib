using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	public int isWalking;
	public int isHitting;

	// Construtor
	void Start()
	{
		isWalking = Animator.StringToHash("isWalking");
		isHitting = Animator.StringToHash("isHitting");
	}
}
