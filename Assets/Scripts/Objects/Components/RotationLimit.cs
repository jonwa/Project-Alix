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
	public float m_LockedLimit = 1.5f;
	#endregion
	
	#region PrivateMemberVariables
	public Vector3 m_Rotation;
	private Vector3 m_LastRotation;
	private Vector3 m_Difference;
	private Vector3 m_Offset;
	private Vector3 m_OriginalRotation;
	private bool 	m_IsLocked;
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.GetComponent<Locked>())
		{
			m_IsLocked = gameObject.GetComponent<Locked> ().GetLocked ();
		}
	}

	public void ResetRotation(string axis)
	{
		if(axis.Equals("x"))
		{
			m_Rotation.x = 0;
		}
		else if(axis.Equals("y"))
		{
			m_Rotation.y = 0;
		}
		else if(axis.Equals("z"))
		{
			m_Rotation.z = 0;
		}
	}

	public float CheckRotation(float angle, string axis)
	{

		axis.ToLower ();
		if (axis.Equals ("x")) 
		{
			float CheckX = m_Rotation.x;
			CheckX += angle;
			if(m_IsLocked){
				if(CheckX > m_LockedLimit)
				{
					angle = m_LockedLimit - m_Rotation.x;
				}
				else if(CheckX < (m_LockedLimit * -1))
				{
					angle = (m_LockedLimit * -1) + (m_Rotation.x * -1); 
				}
			}
			else
			{
				if(CheckX > m_PositiveX)
				{
					angle = m_PositiveX - m_Rotation.x; 
				}
				else if(CheckX < m_NegativeX)
				{
					angle = m_NegativeX + (m_Rotation.x * -1); 
				}
			}
			
			m_Rotation.x +=angle;
		}
		else if (axis.Equals ("y")) 
		{
			float CheckY = m_Rotation.y;
			CheckY += angle;
			if(m_IsLocked)
			{
				if(CheckY > m_LockedLimit)
				{
					angle = m_LockedLimit - m_Rotation.y;
				}
				else if(CheckY < (m_LockedLimit * -1))
				{
					angle = (m_LockedLimit * -1) + (m_Rotation.y * -1); 
				}
			}
			else
			{
				if(CheckY > m_PositiveY)
				{
					angle = m_PositiveY - m_Rotation.y; 
				}
				else if(CheckY < m_NegativeY)
				{
					angle = m_NegativeY + (m_Rotation.y * -1); 
				}
			}
			m_Rotation.y +=angle;
		}
		else if (axis.Equals ("z")) 
		{
			float CheckZ = m_Rotation.z;
			CheckZ += angle;
			if(m_IsLocked){
				if(CheckZ > m_LockedLimit)
				{
					angle = m_LockedLimit - m_Rotation.z;
				}
				else if(CheckZ < (m_LockedLimit * -1))
				{
					angle = (m_LockedLimit * -1) + (m_Rotation.z * -1); 
				}
			}
			else
			{
				if(CheckZ > m_PositiveX)
				{
					angle = m_PositiveX - m_Rotation.z; 
				}
				else if(CheckZ < m_NegativeX)
				{
					angle = m_NegativeX + (m_Rotation.z * -1); 
				}
			}
			m_Rotation.z +=angle;
		}
		return angle;
	}



	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}