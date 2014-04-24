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
	private bool m_IsActive = true; 
	private int counter = 0;
	#endregion

	// Update is called once per frame
	void Update()
	{
		
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
	{ get{return"ChangeModel";}}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
