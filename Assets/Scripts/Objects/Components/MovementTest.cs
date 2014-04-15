using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for limiting the movement on this object
 * Created by: Robert Datum: 08/04-14
 * Modified by:
 * 
 */

public class MovementTest : ObjectComponent
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
	private float m_OriginalX;
	private float m_OriginalY;
	private float m_OriginalZ;
	private float m_CurrentX;
	private float m_CurrentY;
	private float m_CurrentZ;
	private float MaxX;
	private float MinX;
	private float MaxY;
	private float MinY;
	private float MaxZ;
	private float MinZ;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		m_OriginalX = gameObject.transform.position.x;
		m_OriginalY = gameObject.transform.position.y;
		m_OriginalZ = gameObject.transform.position.z;
		MaxX = m_OriginalX + m_PositiveX;
		MinX = m_OriginalX - m_NegativeX;
		MaxY = m_OriginalY + m_PositiveY;
		MinY = m_OriginalY - m_NegativeY;
		MaxZ = m_OriginalZ + m_PositiveZ;
		MinZ = m_OriginalZ - m_NegativeZ;
		Debug.Log (MaxX+", "+MinX);
		Debug.Log (MaxY+", "+MinY);
		Debug.Log (MaxZ+", "+MinZ);
		Activate();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_CurrentX = gameObject.transform.position.x;
		m_CurrentY = gameObject.transform.position.y;
		m_CurrentZ = gameObject.transform.position.z;
	}
	public Vector3 CheckMovement(Vector3 Offset)
	{
		float x = Offset.x;
		float y = Offset.y;
		float z = Offset.z;
		
		if(m_CurrentX+x > MaxX || m_CurrentX+x < MinX){
			Offset.x = 0;
		}
		if(m_CurrentX+y > MaxY || m_CurrentX+y < MinY){
			Offset.y = 0;
		}
		if(m_CurrentX+z > MaxZ || m_CurrentX+z < MinZ){
			Offset.z = 0;
		}
		Debug.Log (Offset.z);
		return Offset;
	}

	public Vector3 CheckPosition(Vector3 TargetPosition)
	{
		float x = TargetPosition.x;
		float y = TargetPosition.y;
		float z = TargetPosition.z;
		if(x > MaxX){
			TargetPosition.x = MaxX;
		}
		else if (x < MinX) {
			TargetPosition.x = MinX;
		}
		if(y > MaxY){
			TargetPosition.y = MaxY;
		}
		else if (y < MinY) {
			TargetPosition.y = MinY;		
		}
		if(z > MaxZ){
			TargetPosition.z = MaxZ;			
		}
		else if (z < MinZ) {
			TargetPosition.z = MinZ;		
		}
		return TargetPosition;
	}
}
