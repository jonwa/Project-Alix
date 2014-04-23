using UnityEngine;
using System.Collections;

/* Discription: Base class for triggers on objects
 * 
 * Created by: 
 * Modified by: 
 * 
 */

public class ChangeModel :  TriggerEffect
{
	#region PublicMemberVariables
	public	Mesh[]		m_MeshStages;
	public	Texture[]	m_TextureStages;
	public	string		m_Input = "Pocket";
	#endregion

	#region PrivateMemberVariables
	private bool m_IsActive = true; 
	private int counter = 0;
	#endregion

	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown(m_Input)){
			ModelChange();
		}
	}

	public void ModelChange()
	{
		if (counter < m_MeshStages.Length) {
			gameObject.GetComponent<MeshFilter> ().mesh = m_MeshStages [counter];
			renderer.material.mainTexture = m_TextureStages [counter];
			counter++;
		}
	}
	
	override public string Name
	{ get{return"TriggerEffect";}}
	
	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
