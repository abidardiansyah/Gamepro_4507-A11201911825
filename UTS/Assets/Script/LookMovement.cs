using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMovement : MonoBehaviour
{
	public Transform mulai, finish;
	private bool collision = false;
	
	void Update () {
       
		collision = Physics2D.Linecast (mulai.position, finish.position, 1 << LayerMask.NameToLayer ("Solid"));
		Debug.DrawLine (mulai.position, finish.position, Color.green);
		if(collision) 
			this.transform.localScale = new Vector3((transform.localScale.x == 1) ? -1 : 1, 1, 1);
	}
}
