using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Serializer : MonoBehaviour 
{
	public static void Serialize(ref JSONObject jsonObject)
	{
		Id[] objectIds = Object.FindObjectsOfType<Id>();

		JSONObject jArr = new JSONObject(JSONObject.Type.ARRAY);
		jsonObject.AddField("Objects", jArr);

		foreach(Id objId in objectIds)
		{
//JSONObject jComponentArr = new JSONObject(JSONObject.Type.ARRAY);
//jArr.AddField"Components", jComponentArr);
//jComponentArr.AddField("id", objId.ObjectId);
//
//ObjectComponent[] components = obj.gameObject.GetComponents<ObjectComponent>();
//foreach(ObjectComponent component in components)
//{
//	//component.Serialize();
//}
		}

	}

}
