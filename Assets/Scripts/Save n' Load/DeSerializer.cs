using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deserializer : MonoBehaviour 
{
	private static  Dictionary<int, GameObject> m_GameObjects = new Dictionary<int, GameObject>();

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
//			Debug.Log("Got keys: ", keys);
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
				JSONObject obji = objects.list[i];


//				List<string> keys = objects.list[i].list[j].keys;


//				jObject = objects.list[i].list[j];


//				Debug.Log("comp str: " + jObject.f);
				//ObjectComponent comp = ob.GetComponent(jObject[0].str) as ObjectComponent;
				//comp.Deserialize(ref jObject);
		
			}

		}
		return;
	}


	private static void DeserializeTransform(ref JSONObject jsonObject, GameObject obj)
	{

	}



	private static GameObject GetObjectWithId(int id)
	{
		if (m_GameObjects.ContainsKey(id))
		{
			return m_GameObjects[id];
		}


		GameObject ret = null;
		Id[] objId = GameObject.FindObjectsOfType<Id>();
		foreach (Id obj in objId)
		{
			if (obj.ObjectId == id)
			{
				ret = obj.gameObject;
			}
			m_GameObjects.Add(obj.ObjectId, obj.gameObject);
		}
		return ret;
	}

}
