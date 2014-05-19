using UnityEngine;
using System.Collections;

/* Discription: Trigger component for changling the mesh and texture on the said object
 * 
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */

public class ChangeModel :  TriggerComponent
{
	#region PublicMemberVariables
	public	Mesh[]		m_MeshStages;
	public	Texture[]	m_TextureStages;
	#endregion

	#region PrivateMemberVariables
	private int m_Counter = 0;
	#endregion

	// Update is called once per frame
	public void ModelChange()
	{
		if (m_Counter < m_MeshStages.Length) 
		{
			if(m_MeshStages[m_Counter] != null)
			{
				gameObject.GetComponent<MeshFilter> ().mesh = m_MeshStages [m_Counter];
			}
		}
		if (m_Counter < m_TextureStages.Length)
		{
			if(m_TextureStages[m_Counter] != null)
			{
				renderer.material.mainTexture = m_TextureStages [m_Counter];
			}
		}
		m_Counter++;	
	}

	override public string Name
	{ get{return"ChangeModel";}}
	
	public override void Serialize(ref JSONObject jsonObject)
	{

		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_Counter",m_Counter);
	}
	public override void Deserialize(ref JSONObject jsonObject)
	{
		m_Counter = (int)jsonObject.GetField("m_Counter").n;
		m_Counter--;
		if(m_MeshStages.Length > 0 && m_Counter > m_MeshStages.Length)
			gameObject.GetComponent<MeshFilter> ().mesh = m_MeshStages [m_MeshStages.Length-1];
		else
			gameObject.GetComponent<MeshFilter> ().mesh = m_MeshStages[m_Counter];
			
		if(m_TextureStages.Length > 0 && m_Counter > m_TextureStages.Length)
			renderer.material.mainTexture = m_TextureStages [m_TextureStages.Length-1];
		else
			renderer.material.mainTexture = m_TextureStages [m_Counter];
	}
}
