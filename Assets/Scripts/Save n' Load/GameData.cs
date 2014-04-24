using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/*
 * Description: Used for saving and loading data about the game to/from JSON-files
 * 
 * Created by: Jimmy 2014-04-23
 * 
 */

public class GameData : MonoBehaviour 
{

	//void Update()
	//{
	//	if(Input.GetButton("Fire1"))
	//	{
	//		Save("filnamnLOL");
	//	}
	//	else if(Input.GetButtonDown("Fire2"))
	//	{
	//		Load("filnamnLOL");
	//	}
	//}

	//Gets all information about all objects in scene and saves it to the a file.
	public static void Save(string fileName)
	{
		fileName = fileName.ToLower();
		JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
		Serializer.Serialize(ref jsonObject);

		string s = jsonObject.Print(true);
		Debug.Log(s);
		WriteToFile(fileName, jsonObject.Print());
	}
	
	//Loads json string from file and loads data to all objects in scene
	public static void Load(string fileName)
	{
		fileName = fileName.ToLower();
		string fileContent = LoadFromFile(fileName);
		JSONObject jsonObject = new JSONObject(fileContent);

		Deserializer.Deserialize(ref jsonObject);

		string s = jsonObject.Print(true);
		Debug.Log(s);
	}

	//list with filenames for all saved data
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

	//Writes a string to specified file name.
	static void WriteToFile(string fileName, string content)
	{
		System.IO.FileInfo file = new System.IO.FileInfo("SaveData/"+fileName);
		file.Directory.Create(); // If the directory already exists, this method does nothing.
		System.IO.File.WriteAllText(file.FullName, content);
		
		Debug.Log("SaveData has been written to: SaveData/"+fileName);
	}

	//Loads content from a file as a string.
	static string LoadFromFile(string fileName)
	{
		string ret = "";
		try
		{
			System.IO.FileInfo file = new System.IO.FileInfo("SaveData/"+fileName);
			ret = System.IO.File.ReadAllText(file.FullName);
			return ret;
		}
		catch
		{
			return "";
		}
	}




}
