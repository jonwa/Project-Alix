using UnityEngine;
using System.Collections;

/* Discription: FloorMaterial
 * Works with the WalkSound script and gives the floor a material
 * So the Event get the right parameter
 * 
 * Created by: Sebastian Olsson 21/05-14
 * Modified by:
 */

public class FloorMaterial : MonoBehaviour 
{
	#region PublicMemberVariables
	public string	m_Material;
	#endregion

	public string FloorType
	{
		get{return m_Material;}
	}
}
