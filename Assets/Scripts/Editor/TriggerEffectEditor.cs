using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/*	Don't even ask...
 *
 * Created by: Jon Wahlström 2014-05-15
 */

public class TriggerEffectEditor : EditorWindow 
{
	[MenuItem("LOL/Trigger Effect Tool")]
	private static void showEditor ()
	{
		EditorWindow window = EditorWindow.GetWindow<TriggerEffectEditor> (false, "Tool");
		window.minSize = new Vector2 (250, 350);
	}

	#region Variables
	private Dictionary<GameObject, int> m_ObjectIDs = new Dictionary<GameObject, int>();

	private List<string> m_TriggerComponents = new List<string>();

	private int m_TriggerComponentIndex = 0; 

	private List<string> m_TriggerEffects = new List<string>();
	#endregion

	void OnGUI()
	{
		NGUIEditorTools.DrawHeader ("Input", false);
		{
			NGUIEditorTools.BeginContents();

			DrawObjectsWithId();

			NGUIEditorTools.EndContents();


			
		}
	}

	// Finds all scripts that deriveds from T
	public static List<System.Type> FindAllDerivedTypes<T>()
	{
		return FindAllDerivedTypes<T> (Assembly.GetAssembly (typeof(T)));
	}

	public static List<System.Type> FindAllDerivedTypes<T>(Assembly assembly)
	{
		var derivedType = typeof(T);
		return assembly.GetTypes ().Where (t => t != derivedType && derivedType.IsAssignableFrom (t)).ToList ();
	}
	
	void Update()
	{
		var output = FindAllDerivedTypes<TriggerComponent> ();

		foreach(var type in output)
		{
			if(!m_TriggerComponents.Contains(type.ToString()))
			{
				m_TriggerComponents.Add(type.ToString());
			}
		}

		m_ObjectIDs.Clear ();
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
	}

	void DrawObjectsWithId()
	{
		if(m_ObjectIDs.Count > 0)
		{
			GUILayout.Space (10f);
			
			foreach(KeyValuePair<GameObject, int> kvPair in m_ObjectIDs)
			{
				GUILayout.BeginHorizontal();
				
				int i = kvPair.Value;
				GameObject go = kvPair.Key; 

				GUILayout.BeginVertical();
				go = EditorGUILayout.ObjectField (go, typeof(GameObject), false) as GameObject;
				GUILayout.EndVertical(); 
				
				GUILayout.BeginVertical();
				i = EditorGUILayout.IntField(i);
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				m_TriggerComponentIndex = EditorGUILayout.Popup(m_TriggerComponentIndex, m_TriggerComponents.ToArray());
				GUILayout.EndVertical();
				
				GUILayout.EndHorizontal();
			}
		}
	}
}
