using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for limiting the movement on this object
 * Created by: Robert Datum: 08/04-14
 * Modified by:
 * 
 */

public class RotationLimit : ObjectComponent
{
	#region PublicMemberVariables
	public float m_PositiveX;
	public float m_NegativeX;
	public float m_PositiveY;
	public float m_NegativeY;
	public float m_PositiveZ;
	public float m_NegativeZ;
	#endregion
	
	#region PrivateMemberVariables
	private float m_RotationX = 0;
	private float m_RotationY = 0;
	private float m_RotationZ = 0;
	private float m_LastRotationX;
	private float m_LastRotationY;
	private float m_LastRotationZ;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		m_NegativeX *= -1;
		m_NegativeY *= -1;
		m_NegativeZ *= -1;
		Activate();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	public float CheckRotation(float angle, string axis)
	{

		axis.ToLower ();
		if (axis.Equals ("x")) 
		{
			float CheckX = m_RotationX;
			CheckX += angle;
			Debug.Log(angle);
			if(CheckX > m_PositiveX)
			{
				angle = m_PositiveX - m_RotationX; 
			}
			else if(CheckX < m_NegativeX)
			{
				angle = m_NegativeX + (m_RotationX * -1); 
			}
			m_RotationX +=angle;
		}
		else if (axis.Equals ("y")) 
		{
			float CheckY = m_RotationY;
			CheckY += angle;
			Debug.Log(angle);
			if(CheckY > m_PositiveY)
			{
				angle = m_PositiveY - m_RotationY; 
			}
			else if(CheckY < m_NegativeY)
			{
				angle = m_NegativeY + (m_RotationY * -1); 
			}
			m_RotationY +=angle;
		}
		else if (axis.Equals ("z")) 
		{
			float CheckX = m_RotationX;
			CheckX += angle;
			Debug.Log(angle);
			if(CheckX > m_PositiveX)
			{
				angle = m_PositiveX - m_RotationX; 
			}
			else if(CheckX < m_NegativeX)
			{
				angle = m_NegativeX + (m_RotationX * -1); 
			}
			m_RotationX +=angle;
		}
		return angle;
	}
}