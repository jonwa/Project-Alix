using UnityEngine;
using System.Collections;

/* Component used in order to change the cursor depending on which object
 * is hovered during collaboration. 
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class CollaborateHoverEffect : ObjectComponent 
{
	#region publicMemberVariables
	public Texture m_HoverEffect;
	public Texture m_ButtonDownHoverEffect = null;
	public string  m_Description  = null;
	#endregion

	public virtual string Name
	{
		get
		{
			return "CollaborateHoverEffect";
		}
	}

	public Texture HoverTexture
	{
		get { return m_HoverEffect; }
	}

	public Texture ButtonDownHoverTexture
	{
		get { return m_ButtonDownHoverEffect; }
	}
	
	public string Description
	{
		get { return m_Description; }
	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
