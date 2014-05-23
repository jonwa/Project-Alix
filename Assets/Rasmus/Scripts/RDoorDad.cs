using UnityEngine;
using System.Collections;

public class RDoorDad : ObjectComponent
{
	private float m_LastRotation = 0;
	private float m_Difference 	 = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void DadRotation1()
	{
		float movement = Input.GetAxis("Mouse Y") * 5;
		if(Mathf.Abs(movement) > 50)
		{
			movement = 50;
		}
		if(m_Difference < 90 && m_Difference > -90)
		{
			transform.Rotate(0, movement, 0);
			CheckRotation();
		}
		else if(Input.GetAxis("Mouse Y") < 0 && m_Difference > -90)
		{
			transform.Rotate(0, movement, 0);
			CheckRotation();
		}
		else if(Input.GetAxis("Mouse Y") > 0 && m_Difference < 90)
		{
			transform.Rotate(0, movement, 0);
			CheckRotation();
		}
	}
	public void DadRotation2()
	{
		float movement = Input.GetAxis("Mouse Y") * -5;
		if(Mathf.Abs(movement) > 50)
		{
			movement = 50;
		}

		if(m_Difference < 90 && m_Difference > -90)
		{
			transform.Rotate(0, movement, 0);
			CheckRotation();
		}
		else if(Input.GetAxis("Mouse Y") > 0 && m_Difference > -90)
		{
			transform.Rotate(0, movement, 0);
			CheckRotation();
		}
		else if(Input.GetAxis("Mouse Y") < 0 && m_Difference < 90)
		{
			transform.Rotate(0, movement, 0);
			CheckRotation();
		}
	}

	private void CheckRotation()
	{
		//Debug.Log (m_Difference);
		if(m_LastRotation + 0.01 > transform.localRotation.eulerAngles.y && m_LastRotation - 0.01 < transform.localRotation.eulerAngles.y)
		{
			//Skillnad i float
		}
		else if(m_LastRotation + 50 > transform.localRotation.eulerAngles.y && m_LastRotation - 50 < transform.localRotation.eulerAngles.y)
		{
			m_Difference   += transform.localRotation.eulerAngles.y - m_LastRotation;
			m_LastRotation = transform.localRotation.eulerAngles.y;
		}
		else
		{
			m_LastRotation = transform.localRotation.eulerAngles.y;
		}
	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
