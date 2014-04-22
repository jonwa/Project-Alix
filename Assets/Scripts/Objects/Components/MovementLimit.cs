using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for limiting the movement on this object
 * Created by: Robert Datum: 08/04-14
 * Modified by:
 * 
 */

public class MovementLimit : ObjectComponent
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
		m_OriginalX = gameObject.transform.localPosition.x;
		m_OriginalY = gameObject.transform.localPosition.y;
		m_OriginalZ = gameObject.transform.localPosition.z;
		MaxX = m_OriginalX + m_PositiveX;
		MinX = m_OriginalX - m_NegativeX;
		MaxY = m_OriginalY + m_PositiveY;
		MinY = m_OriginalY - m_NegativeY;
		MaxZ = m_OriginalZ + m_PositiveZ;
		MinZ = m_OriginalZ - m_NegativeZ;
		Activate();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localPosition = CheckPosition (gameObject.transform.localPosition);
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