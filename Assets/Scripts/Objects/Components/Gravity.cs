using UnityEngine;
using System.Collections;

/* Discription: Class for setting gravity on/off for an object
 * 
 * Made by: Rasmus 09/04
 */

[RequireComponent(typeof(Rigidbody))]
public class Gravity : ObjectComponent 
{
	#region PublicMemberVariables
	public bool m_Gravity	= true;
	#endregion
	
	#region PrivateMemberVariables
	#endregion

	// Use this for initialization
	void Start () 
	{
		if(m_Gravity == true)
		{
			rigidbody.useGravity = true;
		}
		else
		{
			rigidbody.useGravity = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_Gravity == true)
		{
			rigidbody.useGravity = true;
		}
		else
		{
			rigidbody.useGravity = false;
		}
	}

	public void SetGravity(bool bo)
	{
		m_Gravity = bo;
	}
}
