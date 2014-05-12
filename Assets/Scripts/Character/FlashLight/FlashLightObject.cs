using UnityEngine;
using System.Collections;

public class FlashLightObject : ObjectComponent 
{
	public override void Interact()
	{
		GameObject.FindGameObjectWithTag("FlashLight").GetComponent<FlashLight>().Find();
		gameObject.SetActive (false);
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
