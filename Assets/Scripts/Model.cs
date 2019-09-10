using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
	public static int HP = 100;
	public static GroupState currentGrouping = GroupState.Individual;
	public static ControlLouise louise;
	public static ControlEdmond edmond;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		GroupState input = (GroupState)Input.GetAxisRaw("Group Up");
		if (input != 0)
		{
			currentGrouping = input;
		}
	}

	public static void takeDamage(int damage)
	{
		HP -= damage;
		Debug.Log(currentGrouping);
	}
}

public enum GroupState
{
	Individual = 1, Rotary = -1
}
