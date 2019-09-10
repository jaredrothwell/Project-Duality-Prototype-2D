using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		this.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Here with " + other.gameObject.tag);
		if(other.gameObject.tag == "Monster")
		{
			Destroy(other.gameObject);
		}
	}
}
