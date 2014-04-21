using UnityEngine;
using System.Collections;

/* Component used in order to change the cursor depending on which object
 * is hoovered. 
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class HooverEffect : ObjectComponent 
{
	#region publicMemberVariables
	public Texture m_HooverEffect;
	public string  m_Description  = null;
	#endregion

	public Texture HooverTexture
	{
		get { return m_HooverEffect; }
	}

	public string Description
	{
		get { return m_Description; }
	}
}
