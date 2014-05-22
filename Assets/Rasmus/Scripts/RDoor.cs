using UnityEngine;
using System.Collections;

public class RDoor : ObjectComponent
{
	private Vector3 m_Start;
	private bool 	m_Positive;
	private bool 	m_UseX;
	private float   m_Counter;
	private bool 	m_Active;
	// Use this for initialization
	void Start () 
	{
		DecideBools();
	}

	private void DecideBools()
	{
		m_Start = transform.position;
		if(transform.forward.x > 0.5)
		{
			m_Positive = false;
			m_UseX = true;
		}
		if(transform.forward.x < -0.5)
		{
			m_Positive = true;
			m_UseX = true;
		}
		if(transform.forward.z > 0.5)
		{
			m_Positive = true;
			m_UseX = false;
		}
		if(transform.forward.z < -0.5)
		{
			m_Positive = false;
			m_UseX = false;
		}
	}

	void Update () 
	{
		if(m_Active == true)
		{
			if(m_Counter > 0)
			{
				m_Counter-= Time.deltaTime;
			}
			else
			{
				m_Active = false;
				Camera.main.GetComponent<Raycasting>().Release();
				Camera.main.GetComponent<FirstPersonCamera>().UnLockCamera();
			}
		}
	}

	public override void Interact()
	{

		if(GetComponent<Locked>().GetLocked() == false)
		{
			if(m_Active == false)
			{
				DecideBools();
			}
			m_Active = true;
			CheckPositive();
			m_Counter = 0.3f;
			Camera.main.GetComponent<FirstPersonCamera>().LockCamera();
		}
		else
		{
			Debug.Log("Låst dörr");
			Camera.main.GetComponent<Raycasting>().Release();
		}
	}

	private void CheckPositive()
	{
		float mFloat;
		if(m_UseX == false)
		{
			mFloat = m_Start.x - Camera.main.transform.position.x;
		}
		else
		{
			mFloat = m_Start.z - Camera.main.transform.position.z;
		}

		if(m_Positive == true)
		{
			if(mFloat > 0)
			{
				transform.parent.GetComponent<RDoorDad>().DadRotation2();
			}
			else
			{
				transform.parent.GetComponent<RDoorDad>().DadRotation1();
			}
		}
		else
		{
			if(mFloat > 0)
			{
				transform.parent.GetComponent<RDoorDad>().DadRotation1();
			}
			else
			{
				transform.parent.GetComponent<RDoorDad>().DadRotation2();
			}
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
