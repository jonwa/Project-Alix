using UnityEngine;
using System.Collections;

/* Any object that can be pocketed needs a name in order to 
 * connect the object to a sprite. This component is used to
 * solve that. 
 * 
 * Created By: Jon Wahlström 2014-04-11
 * Modified By: 
 */

public class Name : ObjectComponent 
{
	#region PublicMemberVariables
	public string m_Name; 
	#endregion

	public string ObjectName
	{
		get { return /*m_Name.ToLower();*/ null; }
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
