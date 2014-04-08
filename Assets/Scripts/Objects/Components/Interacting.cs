using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for interactions between two specific objects
 * 
 * Created by: Robert Datum: 08/04-14
 * Modified by: 
 * 
 */
public class Interacting : ObjectComponent
{
	#region PublicMemberVariables
	public int		m_ValidId;
	public int[]	m_FaultyId;
	public string	m_Input;
	#endregion
	
	#region PrivateMemberVariables
	private bool		m_Collision;
	private bool 		m_Interact			= false;
	private bool		m_VaildInteract 	= false;
	private int			m_DeActivateCounter	= 0;
	private GameObject	m_CollidedObject 	= null;
	#endregion
	
	
	void Start()
	{

	}
	
	void Update()
	{
		if(!GetIsActive())
		{
			if(m_Collision){
				CheckCollision();
			}
		}
		else
		{
			m_DeActivateCounter++;
			if(m_DeActivateCounter > 10)
			{
				DeActivate();
			}
		}
	}
	
	public override void Interact ()
	{
		if(GetIsActive())
		{
			//m_CollidedObject.GetComponent<Interacting>().Should(m_VaildInteract);
			//Should(m_VaildInteract);
			Debug.Log("Interacting");
		}
		
		//Check if we should inspect the object or not.
		if(Input.GetButton(m_Input) && m_Interact)
		{
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}

	void CheckCollision(){

		int collisionId = m_CollidedObject.GetComponent<Id>().GetId();
		if (collisionId == m_ValidId) 
		{
			m_Interact = true;
			m_VaildInteract = true;
		} 
		else if(m_FaultyId.Length > 0){
			for(int i = 0;i < m_FaultyId.Length; i++)
			{
				if(collisionId == m_FaultyId[i]){
					m_Interact = true;
					m_VaildInteract = false;
					break;
				}
			}
		}
	}

	void OnCollisionEnter(Collision Hit)
	{
		//Debug.Log("Hit");
		m_CollidedObject = Hit.collider.gameObject;
		m_Collision = true;
	}
	
	public void OnCollisionExit()
	{
		//Debug.Log("Clear");
		m_CollidedObject = null;
		m_Collision = false;
		m_Interact = false;
		DeActivate ();
	}

}
