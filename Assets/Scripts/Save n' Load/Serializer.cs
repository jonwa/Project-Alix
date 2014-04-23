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
			JSONObject jComponentArr = new JSONObject(JSONObject.Type.ARRAY);
			jArr.AddField("Object", jComponentArr);
			jComponentArr.AddField("Id", objId.ObjectId);

			ObjectComponent[] components = objId.gameObject.GetComponents<ObjectComponent>();
			foreach(ObjectComponent component in components)
			{
				component.Serialize(ref jComponentArr);
			}
		}
	}

}
