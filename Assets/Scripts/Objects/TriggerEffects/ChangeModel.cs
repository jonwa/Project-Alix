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
		if (m_Counter < m_MeshStages.Length) {
			gameObject.GetComponent<MeshFilter> ().mesh = m_MeshStages [m_Counter];
			renderer.material.mainTexture = m_TextureStages [m_Counter];
			m_Counter++;
		}
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
		gameObject.GetComponent<MeshFilter> ().mesh = m_MeshStages [m_Counter];
		renderer.material.mainTexture = m_TextureStages [m_Counter];
	}
}
