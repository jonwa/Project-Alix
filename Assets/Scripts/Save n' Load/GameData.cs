using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameData : MonoBehaviour 
{

	void Update()
	{
		if(Input.GetButton("Fire1"))
		{
			Save("filnamnLOL");
		}
	}
	public static void Save(string fileName)
	{
		fileName = fileName.ToLower();
		JSONObject jNode = new JSONObject(JSONObject.Type.OBJECT);
		Serializer.Serialize(ref jNode);

		string s = jNode.Print(true);
		Debug.Log(s);
	}

	public static void Load(string fileName)
	{
		fileName = fileName.ToLower();
	}

	public static List<string> FileNames
	{
		get 
		{
			return null;
		}
		set
		{

		}
	}
}
