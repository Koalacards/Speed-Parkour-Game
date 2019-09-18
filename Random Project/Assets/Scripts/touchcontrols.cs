using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchcontrols : MonoBehaviour {

	private movementscript player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<movementscript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LeftArrow()
	{
		player.Move (-7);
	}

	public void RightArrow()
	{
		player.Move (7);
	}

	public void UnpressedArrow()
	{
		player.Move (0);
	}

	public void Jump()
	{
		player.Jump ();
	}
}
