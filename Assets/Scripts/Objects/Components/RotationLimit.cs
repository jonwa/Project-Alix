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
	private Vector3 m_Rotation;
	private Vector3 m_LastRotation;
	private Vector3 m_Difference;
	private Vector3 m_Offset;
	private Vector3 m_OriginalRotation;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		m_OriginalRotation = transform.localRotation.eulerAngles;
		m_LastRotation = m_OriginalRotation;
		m_Offset = m_OriginalRotation - new Vector3(180,180,180);
		Activate();
		if(m_PositiveX > 180)
		{
			m_PositiveX = 180;
		}
		if(m_PositiveY > 180)
		{
			m_PositiveY = 180;
		}
		if(m_PositiveZ > 180)
		{
			m_PositiveZ = 180;
		}
		if(m_NegativeX > 180)
		{
			m_NegativeX = 180;
		}
		if(m_NegativeY > 180)
		{
			m_NegativeY = 180;
		}
		if(m_NegativeZ > 180)
		{
			m_NegativeZ = 180;
		}
		m_NegativeX *= -1;
		m_NegativeY *= -1;
		m_NegativeZ *= -1;
		m_Offset *= -1;
		Debug.Log (m_Offset);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if ((m_LastRotation.x + 5 > transform.localRotation.eulerAngles.x && m_LastRotation.x - 5 < transform.localRotation.eulerAngles.x)
		//{
		//	m_Difference = transform.localRotation.eulerAngles -(m_LastRotation);
		//	Vector3 Rotate;
		//	Rotate.x = CheckRotation (m_Difference.x, "x");
		//	Rotate.y = CheckRotation (m_Difference.y, "y");
		//	Rotate.z = CheckRotation (m_Difference.z, "z");
		//	transform.Rotate (Rotate,Space.Self);
		//	Debug.Log (m_Difference);
		//	m_Difference *= 0;
		//}
		//m_LastRotation = transform.localRotation.eulerAngles;
		//Debug.Log (m_LastRotation);
		RotationHandler ();
		m_LastRotation = transform.localRotation.eulerAngles;
	}
	
	public float CheckRotation(float angle, string axis)
	{

		axis.ToLower ();
		if (axis.Equals ("x")) 
		{
			float CheckX = m_Rotation.x;
			CheckX += angle;
			if(CheckX > m_PositiveX)
			{
				angle = m_PositiveX - m_Rotation.x; 
			}
			else if(CheckX < m_NegativeX)
			{
				angle = m_NegativeX + (m_Rotation.x * -1); 
			}
			m_Rotation.x +=angle;
		}
		else if (axis.Equals ("y")) 
		{
			float CheckY = m_Rotation.y;
			CheckY += angle;
			if(CheckY > m_PositiveY)
			{
				angle = m_PositiveY - m_Rotation.y; 
			}
			else if(CheckY < m_NegativeY)
			{
				angle = m_NegativeY + (m_Rotation.y * -1); 
			}
			m_Rotation.y +=angle;
		}
		else if (axis.Equals ("z")) 
		{
			float CheckZ = m_Rotation.z;
			CheckZ += angle;
			if(CheckZ > m_PositiveX)
			{
				angle = m_PositiveX - m_Rotation.z; 
			}
			else if(CheckZ < m_NegativeX)
			{
				angle = m_NegativeX + (m_Rotation.z * -1); 
			}
			m_Rotation.z +=angle;
		}
		return angle;
	}
	void RotationHandler()
	{
		float angle;
		Vector3 current = transform.localRotation.eulerAngles + m_Offset;
		Vector3 max;
		max.x = m_OriginalRotation.x + m_Offset.x + m_PositiveX;
		max.y = m_OriginalRotation.y + m_Offset.y + m_PositiveY;
		max.z = m_OriginalRotation.z + m_Offset.z + m_PositiveZ;
		Vector3 min;
		min.x = m_OriginalRotation.x + m_Offset.x + m_NegativeX;
		min.y = m_OriginalRotation.y + m_Offset.y + m_NegativeY;
		min.z = m_OriginalRotation.z + m_Offset.z + m_NegativeZ;

		if((current.x) > (max.x)){
			angle = max.x - current.x;
			angle = CheckRotation(angle, "x");
			transform.Rotate(angle,0,0,Space.Self);
		}
		else if((current.x) < (min.x)){
			angle = min.x + (current.x * -1);
			angle = CheckRotation(angle, "x");
			transform.Rotate(angle,0,0,Space.Self);
		}
		if((current.y) > (max.y)){
			angle = max.y - current.y;
			angle = CheckRotation(angle, "y");
			transform.Rotate(0,angle,0,Space.Self);
			Debug.Log(angle);
		}
		else if((current.y) < (min.y)){
			angle = min.y + (current.y * -1);
			angle = CheckRotation(angle, "y");
			transform.Rotate(0,angle,0,Space.Self);
		}
		if((current.z) > (max.z)){
			angle = max.z - current.z;
			angle = CheckRotation(angle, "z");
			transform.Rotate(0,0,angle,Space.Self);
		}
		else if((current.z) < (min.z)){
			angle = min.z + (current.z * -1);
			angle = CheckRotation(angle, "z");
			transform.Rotate(0,0,angle,Space.Self);
		}
	}

	void OnCollisionEnter()
	{

	}
	void OnCollisionExit()
	{

	}
}