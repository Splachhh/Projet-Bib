using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	CharacterController control;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float gravity = 1;
	public float speed = 0.5f;
	public float rotationFactor = 0.5f;

	// Use this for initialization
	void Start () 
	{
		control = GetComponent<CharacterController>() as CharacterController;
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		moveDirection.y -= gravity * Time.deltaTime;
		control.Move(moveDirection * Time.deltaTime);

		// Rotation
		rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
		rotation *= rotationFactor * Time.timeScale;
		transform.Rotate(rotation);
	}
}
