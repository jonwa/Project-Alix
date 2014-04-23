using UnityEngine;
using System.Collections;

public class PR : MonoBehaviour 
{
	//public int m_TargetID;
	public GameObject m_Target;
	float mFloat;

	// Use this for initialization
	void Start () 
	{
		mFloat = m_Target.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnCollisionEnter(Collision col)
	{
		col.gameObject.transform.position = new Vector3((m_Target.transform.position.x + m_Target.transform.forward.x*3), col.gameObject.transform.position.y, (m_Target.transform.position.z + m_Target.transform.forward.z*3) ); 	
		//col.gameObject.transform.position.Set(m_Target.transform.position.x, 0, m_Target.transform.localPosition.z);// = m_Target.transform.position;// + (m_Target.transform.up);
		//Quaternion temp=col.gameObject.transform.rotation.eulerAngles;
		//temp.y+= mFloat;
		//transform.rotation.e
		//Transform temp= col.gameObject.transform;

		//temp.rotation.eulerAngles.Set(temp.rotation.eulerAngles.x, temp.rotation.eulerAngles.y + 90, temp.rotation.eulerAngles.z);
		//temp.rotation.eulerAngles += new Vector3(0, mFloat, 0);
		Debug.Log(mFloat);
		col.gameObject.transform.Rotate(0, 0+mFloat, 0);
	}
}
