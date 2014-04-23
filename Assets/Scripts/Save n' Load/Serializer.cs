﻿using UnityEngine;
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

			SerializeTransform(ref jComponentArr, objId);
		}
	}

	private static void SerializeTransform(ref JSONObject jsonObject, Id objId)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField ("Transform", jObject);

		jObject.AddField ("Position X", objId.transform.localPosition.x);
		jObject.AddField ("Position Y", objId.transform.localPosition.y);
		jObject.AddField ("Position Z", objId.transform.localPosition.z);

		jObject.AddField ("Rotation X", objId.transform.localRotation.x);
		jObject.AddField ("Rotation Y", objId.transform.localRotation.y);
		jObject.AddField ("Rotation Z", objId.transform.localRotation.z);

		jObject.AddField ("Scale X",    objId.transform.localScale.x);
		jObject.AddField ("Scale Y",    objId.transform.localScale.y);
		jObject.AddField ("Scale Z",    objId.transform.localScale.z);
	}
}
