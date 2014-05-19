using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMOD.Studio;

/* Search through the hierarchy, finds all object with the ID component
 * Ensures us not having multiple objects with the same id
 * 
 * Created By: Jon Wahlström, Sebastian Olsson 2014-05-13
 */

public class FindObjectsWithId : EditorWindow 
{
	[MenuItem("LOL/Id Tool")]
	private static void showEditor ()
	{
		EditorWindow window = EditorWindow.GetWindow<FindObjectsWithId> (false, "Tool");
		window.minSize = new Vector2 (250, 350);
	}

	Dictionary<GameObject, int> m_ObjectIDs = new Dictionary<GameObject, int>();

	void OnGUI()
	{
		NGUIEditorTools.DrawHeader ("Output", false);
		{
			NGUIEditorTools.BeginContents();

			DrawObjectsWithId();
			
			NGUIEditorTools.EndContents();
			
		}
	}

	private List<int> values = new List<int>();
	void Update()
	{
		m_ObjectIDs.Clear ();
		values.Clear ();
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
		{
			if(obj.GetComponent<Id>())
			{
				if(!m_ObjectIDs.ContainsKey(obj))
				{
					m_ObjectIDs.Add(obj, obj.GetComponent<Id>().m_Id);
				}
			}
		}

		var duplicateValues = m_ObjectIDs.ToLookup(x => x.Value).Where(x => x.Count() > 1);
		

		foreach(var item in duplicateValues)  
		{
			if(!values.Contains(item.Key))
				values.Add(item.Key);
		}
	}

	void DrawObjectsWithId()
	{
		if(m_ObjectIDs.Count > 0)
		{
			GUILayout.Space (10f);
			GUILayout.BeginHorizontal();
			GUILayout.Label("Game Object");
			GUILayout.Label("Id");
			GUILayout.EndHorizontal ();

			foreach(KeyValuePair<GameObject, int> kvPair in m_ObjectIDs)
			{
				GUILayout.BeginHorizontal();

				int i = kvPair.Value;

				GUILayout.BeginVertical();
				if(values.Contains(i))
				{
					GUI.color = Color.cyan;
					GameObject go = kvPair.Key; 
					go = EditorGUILayout.ObjectField (go, typeof(GameObject), false) as GameObject;
					GUI.color = Color.white;
				}
				else
				{
					GameObject go = kvPair.Key; 
					go = EditorGUILayout.ObjectField (go, typeof(GameObject), false) as GameObject;
				}
				GUILayout.EndVertical(); 

				GUILayout.BeginVertical();
				if(values.Contains(i))
				{
					GUI.color = Color.cyan;
					i = EditorGUILayout.IntField(i);
					GUI.color = Color.white;
				}
				else
				{
					i = EditorGUILayout.IntField(i);

				}
				GUILayout.EndVertical();

				GUILayout.EndHorizontal();

			}
		}
	}
}
