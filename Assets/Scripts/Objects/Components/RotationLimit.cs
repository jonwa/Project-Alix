using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for limiting the rotation on this object
 * Created by: Robert Datum: 08/04-14
 * Modified by:
 * 
 */

public class Rotation : ObjectComponent
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
		m_OriginalX = gameObject.transform.rotation.x;
		m_OriginalY = gameObject.transform.rotation.y;
		m_OriginalZ = gameObject.transform.rotation.z;
		Activate();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_CurrentX = gameObject.transform.rotation.x;
		m_CurrentY = gameObject.transform.rotation.y;
		m_CurrentZ = gameObject.transform.rotation.z;
	}
	
	public override void Interact ()
	{
		int MaxX = m_OriginalX + m_PositiveX;
		int MinX = m_OriginalX - m_NegativeX;
		int MaxY = m_OriginalY + m_PositiveY;
		int MinY = m_OriginalY - m_NegativeY;
		int MaxZ = m_OriginalZ + m_PositiveZ;
		int MinZ = m_OriginalY - m_NegativeY;

		if(m_CurrentX > MaxX){
			transform.Rotate(MaxX - m_CurrentX,0,0,Space.Self);
		}
		else if (m_CurrentX < MinX) {
			transform.Rotate(MinX + m_CurrentX,0,0,Space.Self);
		}
		if(m_CurrentY > MaxY){
			transform.Rotate(0,MaxY - m_CurrentY,0,Space.Self);
		}
		else if (m_CurrentY < MinY) {
			transform.Rotate(0,MinY + m_CurrentY,0,Space.Self);
		}
		if(m_CurrentZ > MaxZ){
			transform.Rotate(0,0,MaxZ - m_CurrentZ,Space.Self);
		}
		else if (m_CurrentY < MinZ) {
			transform.Rotate(0,0,MinZ + m_CurrentZ,Space.Self);
		}
	}
}
