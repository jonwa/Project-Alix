using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Description: Deseralizes the Json object that gets sent from another class. Makes sure the right componets get their JSON-object
 * 
 * Created by: Jimmy 2014-04-24
 * 
 */

public class Deserializer : MonoBehaviour 
{
	private static  Dictionary<int, GameObject> m_GameObjects = new Dictionary<int, GameObject>();

	//Sends a part of the JSON object to its correct unity-component for deserializing
	public static void Deserialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = null; 
		JSONObject objects = jsonObject.GetField("Objects");

		//Object-loop
		for(int i=0; i< objects.list.Count; ++i)
		{
			int id = (int)objects.list[i].GetField("Id").n;
			GameObject obj = GetObjectWithId( id );
			List<string> keys = objects.list[i].keys;

			//Component-loop
			foreach(string key in keys)
			{
				//objects.list[i][key]	--	ex: Id, Transform, State
				switch(key)
				{
				case "Id":
					Debug.Log("ID Component.. NEXT PLEASE");
					continue;
					break;
				case "Transform":
					Debug.Log("Deserilizing Transform");
					JSONObject trans = objects.list[i][key];
					DeserializeTransform(ref trans, obj);
					break;
				default:
					Debug.Log("Deserializing: "+key);
					SerializableObject component =  obj.GetComponent(key) as SerializableObject;
					JSONObject jsonComponent = objects.list[i][key];
					if(component)
					{
						Debug.Log("Object got the component des.." + key);
						component.Deserialize(ref jsonComponent);
					}
					else
					{
						component.gameObject.AddComponent(key);
						component.Deserialize(ref jsonComponent);
						Debug.LogWarning("Added a non original Component to gameObject!", component.gameObject);
					}
					break;
				}
			}
		}
	}


	private static void DeserializeTransform(ref JSONObject jsonObject, GameObject obj)
	{
		obj.transform.localPosition = JSONTemplates.ToVector3(jsonObject.GetField("Position"));
		obj.transform.localRotation = JSONTemplates.ToQuaternion(jsonObject.GetField("Rotation"));
		obj.transform.localScale = JSONTemplates.ToVector3(jsonObject.GetField("Scale"));
	}

	//Gets the object with correct id
	private static GameObject GetObjectWithId(int id)
	{
		//if (m_GameObjects.ContainsKey(id))
		//{
		//	return m_GameObjects[id];
		//}


		GameObject ret = null;
		Id[] objId = Resources.FindObjectsOfTypeAll<Id>();
			
		foreach (Id obj in objId)
		{
			if (obj.ObjectId == id)
			{
				ret = obj.gameObject;
			}
			m_GameObjects[obj.ObjectId]=  obj.gameObject;
		}
		return ret;
	}

}
