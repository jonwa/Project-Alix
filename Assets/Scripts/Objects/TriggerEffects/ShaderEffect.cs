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

	public void Shader0()
	{
		Camera.main.GetComponent<CameraFilter>().UseEffect(0);
	}

	public void Shader1()
	{
		Camera.main.GetComponent<CameraFilter>().UseEffect(1);
	}
	public void Shader2()
	{
		Camera.main.GetComponent<CameraFilter>().UseEffect(2);
	}
	public void Shader3()
	{
		Camera.main.GetComponent<CameraFilter>().UseEffect(3);
	}
	public void Shader4()
	{
		Camera.main.GetComponent<CameraFilter>().UseEffect(4);
	}

	void Start () 
	{

	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
	
}
