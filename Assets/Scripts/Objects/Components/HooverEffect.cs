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
	#endregion


	public void Hoover()
	{
		Cursor.CrossHair = m_HooverEffect;
	}
}
