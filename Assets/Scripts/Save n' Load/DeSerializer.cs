using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeSerializer : MonoBehaviour 
{
	private static  Dictionary<int, GameObject> m_GameObjects = new Dictionary<int, GameObject>();

	public static void Deserialize(ref JSONObject jsonObject)
	{
		JSONObject objects = jsonObject.GetField("Objects");
		//Object-loop
		for(int i=0; i< objects.list.Count; ++i)
		{
			//Component-loop
			for(int j=0; j<objects.list[i].Count;++j)
			{
				GameObject ob = GetObjectWithId( ((int)objects.list[i].GetField("Id").n) );
				//Loopa igenom componenter på gameObjectet..
				//Eller något sånt...

			}

		}

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
