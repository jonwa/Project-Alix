using UnityEngine;
using System.Collections;

/* Discription: ShaderEffect trigger
 * Used starting a shaderfilter on the camera
 * 
 * Created by: Rasmus 06/05
 * Modified by:
 */

public class ShaderEffect : TriggerComponent 
{
	
	override public string Name
	{
		get{ return "ShaderEffect"; }
	}

	public void RandomShader()
	{
		Camera.main.GetComponent<CameraFilter>().UseEffect(Random.Range(0, 9));
	}

	public void BloodShader()
	{

	}

	void Start () 
	{

	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
	
}
