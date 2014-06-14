using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Description: Finds all object in the scene that is serializeable, and calls all components serialize function writes to JSON-object
 * 
 *  Created by: Jimmy 2014-04-24
 */

public class Serializer : MonoBehaviour 
{
	//Calls Serialize function on all components that derives from SerializableObject
	public static void Serialize(ref JSONObject jsonObject)
	{
		Id[] objectIds = Resources.FindObjectsOfTypeAll<Id>();

		JSONObject jArr = new JSONObject(JSONObject.Type.ARRAY);
		jsonObject.AddField("Objects", jArr);

		foreach(Id objId in objectIds)
		{
			JSONObject jComponentArr = new JSONObject(JSONObject.Type.ARRAY);
			jArr.AddField("Object", jComponentArr);
			jComponentArr.AddField("Id", objId.ObjectId);

			SerializableObject[] components = objId.gameObject.GetComponents<SerializableObject>();
			foreach(SerializableObject component in components)
			{
				component.Serialize(ref jComponentArr);
			}

			SerializeTransform(ref jComponentArr, objId);
		}
	}

	//Special serialization for unitys transform
	private static void SerializeTransform(ref JSONObject jsonObject, Id objId)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField ("Transform", jObject);

		jObject.AddField ("Position", JSONTemplates.FromVector3(objId.transform.localPosition));
		jObject.AddField ("Rotation", JSONTemplates.FromQuaternion(objId.transform.localRotation));
		jObject.AddField ("Scale", JSONTemplates.FromVector3(objId.transform.localScale));
	}
}
