using UnityEngine;
using System.Collections;

/* Description: Makes the object able to pass through portals
 * 
 * Created by: Jimmy  Date: 2014-04-07
 * Modified by:
 */

public class PortableObject : ObjectComponent 
{
	#region PublicMemberVariables
	#endregion
	#region PrivateMemberVariables
	private Transform m_Duplicate		= null;
	private Transform m_CurrentPortal	= null;
	private Transform m_TargetPortal	= null;
	private bool	  m_ShouldUpdate	= false;
	private Vector3	  m_InitialPosition	= new Vector3();
	#endregion

	//Updates the duplicate
	IEnumerator UpdateDuplicate()
	{
		m_ShouldUpdate = true;
		
		while(m_Duplicate != null && m_ShouldUpdate) 
		{
			if(!m_ShouldUpdate)
			{
				break;
			}
			ForceUpdateDuplicate();
			yield return null;
		}
	}

	void ForceUpdateDuplicate()
	{
		Vector3 rot = Quaternion.LookRotation(m_TargetPortal.forward).eulerAngles;
		Vector3 pos = m_CurrentPortal.position - transform.position;

		rot 	   += transform.localEulerAngles;
		m_Duplicate.localEulerAngles = rot;

		pos = Vector3.Reflect(pos, m_CurrentPortal.forward);
		pos = m_TargetPortal.TransformDirection(pos);
		pos += m_TargetPortal.position;

		m_Duplicate.position = pos;
	}

	//Create a duplicate with correct position and rotation.
	//We also remove the collider on the duplicate. Start a corutine that we update until we leave the portals.
	void CreateDuplicate()
	{
		m_Duplicate = Instantiate(transform, transform.position, transform.rotation) as Transform;
		Destroy(m_Duplicate.GetComponent<PortableObject>());
		Destroy(m_Duplicate.collider);
		StartCoroutine(UpdateDuplicate());
	}

	//Destroys the duplicate and sets the portals to null
	void DestroyDuplicate()
	{
		Destroy(m_Duplicate.gameObject);

		m_Duplicate		= null;
		m_CurrentPortal = null;
		m_TargetPortal  = null;
	}

	//When we collide with the portal we create a duplicate and finds the target portal
	void OnTriggerEnter(Collider collider)
	{
		if(m_Duplicate != null || m_ShouldUpdate) 
		{ 
			return; 
		}

		if(collider.CompareTag("PortalA"))
		{
			m_TargetPortal = GameObject.FindGameObjectWithTag("PortalB").transform;
		}
		else if(collider.CompareTag("PortalB"))
		{
			m_TargetPortal = GameObject.FindGameObjectWithTag("PortalA").transform;
		}

		m_CurrentPortal = collider.transform;
		m_InitialPosition = transform.position;

		CreateDuplicate();
	}

	//When we exit the portal we destroy the duplicate and make sure our new rotation and velocity and so on is corerect
	void OnTriggerExit(Collider collider)
	{
		if(m_CurrentPortal != null && collider == m_CurrentPortal.collider)
		{
			m_ShouldUpdate = false;

			if((m_CurrentPortal.position - transform.position).magnitude < (m_InitialPosition- transform.position).magnitude )
			{
				ForceUpdateDuplicate();
				transform.position = m_Duplicate.position;
				transform.rotation = m_Duplicate.rotation;

				Vector3 velocity = rigidbody.velocity;
				velocity = Vector3.Reflect(velocity, m_CurrentPortal.forward);
				velocity = m_CurrentPortal.InverseTransformDirection(velocity);
				velocity = m_TargetPortal.TransformDirection(velocity);
				rigidbody.velocity = velocity;

				DestroyDuplicate();
			}
		}
	}

}
