using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLouise : MonoBehaviour
{
	public float speedScalar = 10f;
	public GameObject swordHitbox;

	private Rigidbody2D rb;


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		bool swordActive = Input.GetButton("RFire1");
		swordHitbox.SetActive(swordActive);
		if (!Model.swordActive)
		{
			Vector3 moveInput = new Vector3(Input.GetAxisRaw("RHorizontal"), Input.GetAxisRaw("RVertical"), 0f);
			moveInput.Normalize();
			Vector3 moveVelocity = moveInput * speedScalar;
			rb.velocity = moveVelocity;
			Vector3 playerDirection = Vector3.left * Input.GetAxisRaw("RHorizontal") + Vector3.down * Input.GetAxisRaw("RVertical");
			if (playerDirection.sqrMagnitude > 0.0f)
			{
				transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.forward);
			}
		}
	}
}

