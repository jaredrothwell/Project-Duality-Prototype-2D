using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlEdmond : MonoBehaviour
{
	public float speedScalar = 10f;
	public Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		//moveSpeed = 15f;
		rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update()
	{
		if (Model.currentGrouping == GroupState.Individual)
		{
			Vector3 moveInput = new Vector3(Input.GetAxisRaw("LHorizontal"), Input.GetAxisRaw("LVertical"), 0f);
			moveInput.Normalize();
			Vector3 moveVelocity = moveInput * speedScalar;
			rb.velocity = moveVelocity;

			if (!Input.GetButton("LFire1"))
			{
				rotateAccordingToInput();
			}
		}
		else if (Model.currentGrouping == GroupState.Rotary)
		{
			rotateAccordingToInput();
			rb.position = Model.edmond.rb.position;
		}
	}

	private void rotateAccordingToInput()
	{
		Vector3 playerDirection = Vector3.left * Input.GetAxisRaw("LHorizontal") + Vector3.down * Input.GetAxisRaw("LVertical");
		if (playerDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.forward);
		}
	}
}
