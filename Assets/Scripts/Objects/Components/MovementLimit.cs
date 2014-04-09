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
	private float m_CurrentX;
	private float m_CurrentY;
	private float m_CurrentZ;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_OriginalX = gameObject.transform.position.x;
		m_OriginalY = gameObject.transform.position.y;
		m_OriginalZ = gameObject.transform.position.z;
		Activate();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_CurrentX = gameObject.transform.position.x;
		m_CurrentY = gameObject.transform.position.y;
		m_CurrentZ = gameObject.transform.position.z;
	}

	public override void Interact ()
	{
		float MaxX = m_OriginalX + m_PositiveX;
		float MinX = m_OriginalX - m_NegativeX;
		float MaxY = m_OriginalY + m_PositiveY;
		float MinY = m_OriginalY - m_NegativeY;
		float MaxZ = m_OriginalZ + m_PositiveZ;
		float MinZ = m_OriginalY - m_NegativeY;

		if(m_CurrentX > MaxX){
			transform.position = new Vector3(MaxX,m_CurrentY,m_CurrentZ);
		}
		else if (m_CurrentX < MinX) {
			transform.position = new Vector3(MinX,m_CurrentY,m_CurrentZ);
		}
		if(m_CurrentY > MaxY){
			transform.position = new Vector3(m_CurrentX,MaxY,m_CurrentZ);
		}
		else if (m_CurrentY < MinY) {
			transform.position = new Vector3(m_CurrentX,MinY,m_CurrentZ);		
		}
		if(m_CurrentZ > MaxZ){
			transform.position = new Vector3(m_CurrentX,m_CurrentY,MaxZ);			
		}
		else if (m_CurrentZ < MinZ) {
			transform.position = new Vector3(m_CurrentX,m_CurrentY,MinZ);			
		}
	}
}
