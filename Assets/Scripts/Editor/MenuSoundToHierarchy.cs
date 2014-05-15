using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;

/* Allow us to add a sound effect to each child button in the menu
 * Can also remove the effect 
 * Created By: Jon Wahlström, Sebastian Olsson 2014-05-13
 */

public class MenuSoundToHierarchy : EditorWindow 
{
	private FMODAsset m_Asset;
	private List<Transform> m_Buttons = new List<Transform>();

	private List<GameObject> m_Roots = new List<GameObject>();
	private string[] m_RootNames = new string[10];
	private int m_Index = 0;

	[MenuItem("LOL/Button Sound")]
	private static void showEditor ()
	{
		EditorWindow window = EditorWindow.GetWindow<MenuSoundToHierarchy> (false, "Tool");
		window.minSize = new Vector2 (250, 350);
	}
	
	void OnGUI()
	{

		bool applyToAll = false; 
		bool apply = false; 
		bool remove = false;
		bool removeAll = false;

		NGUIEditorTools.DrawHeader("Text field", true);
		{
			NGUIEditorTools.BeginContents();

			if(m_Roots.Count > 0)
			{
				m_RootNames[0] = "None";
				int i = 1;
				foreach(GameObject go in m_Roots)
				{
					m_RootNames[i] = go.name;
				}

				m_Index = EditorGUILayout.Popup("Roots", m_Index, m_RootNames);
			}

			EditorGUILayout.BeginHorizontal ();
			m_Asset = EditorGUILayout.ObjectField ("Sound Effect", m_Asset, typeof(FMODAsset), false) as FMODAsset;
			EditorGUILayout.EndHorizontal ();
			NGUIEditorTools.EndContents();
		}

		EditorGUILayout.HelpBox ("\"Apply To All:\" Select the Root object, will apply the sound to all buttons within the hierarchy!\n" +
								 "\"Apply:\" Select any of the parent to a button group to apply the sound to specific button groups!\n" +
								 "\"Remove:\" Select any of the parent to a button group to remove the sound to specific button groups!\n", 
		                         MessageType.Info);
		GUILayout.Space (10f);

		GUILayout.BeginHorizontal ();

		EditorGUI.BeginDisabledGroup (m_Asset == null);
		GUI.color = Color.green;
		applyToAll = GUILayout.Button ("Apply To All", GUILayout.Width(200));
		GUI.color = Color.white;
		EditorGUI.EndDisabledGroup ();

		EditorGUI.BeginDisabledGroup (m_Asset == null);
		GUI.color = Color.green;
		apply = GUILayout.Button ("Apply", GUILayout.Width(200));
		GUI.color = Color.white;
		EditorGUI.EndDisabledGroup ();
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		EditorGUI.BeginDisabledGroup (m_Asset != null);
		GUI.color = Color.red;
		removeAll = GUILayout.Button ("Remove All", GUILayout.Width(200));
		GUI.color = Color.white;
		EditorGUI.EndDisabledGroup ();

		EditorGUI.BeginDisabledGroup (m_Asset != null);
		GUI.color = Color.red;
		remove = GUILayout.Button ("Remove", GUILayout.Width(200));
		GUI.color = Color.white;
		EditorGUI.EndDisabledGroup ();

		GUILayout.EndHorizontal ();
	
		if(applyToAll)
		{
			ApplyToAll();
		}

		if(apply)
		{
			Apply();
		}

		if(removeAll)
		{
			RemoveAll();
		}

		if(remove)
		{
			Remove();
		}

		if(m_Buttons.Count > 0)
		{
			DrawButtonsNames();
		}
	}


	void Apply()
	{
		foreach(Transform child in Selection.activeTransform)
		{
			if(child.gameObject.GetComponent<UIButton>() && child.gameObject.GetComponent<MenuSound>())
				child.gameObject.GetComponent<MenuSound>().m_Asset = m_Asset;
			else if(child.gameObject.GetComponent<UIButton>())
				child.gameObject.AddComponent<MenuSound>().m_Asset = m_Asset;
		}
	}

	void ApplyToAll()
	{
		foreach(Transform child in m_Buttons)
		{
			if(child.gameObject.GetComponent<UIButton>() && child.gameObject.GetComponent<MenuSound>())
				child.gameObject.GetComponent<MenuSound>().m_Asset = m_Asset;
			else if(child.gameObject.GetComponent<UIButton>())
				child.gameObject.AddComponent<MenuSound>().m_Asset = m_Asset;
		}
	}

	void Remove()
	{
		foreach(Transform child in Selection.activeTransform)
		{
			if(child.gameObject.GetComponent<MenuSound>())
				DestroyImmediate(child.gameObject.GetComponent<MenuSound>());			
		}
	}

	void RemoveAll()
	{
		foreach(Transform child in m_Buttons)
		{
			if(child.gameObject.GetComponent<MenuSound>())
				DestroyImmediate(child.gameObject.GetComponent<MenuSound>());
		}
	}

	void DrawButtonsNames ()
	{ 
		GUILayout.Space (20f);
		GUILayout.BeginHorizontal();
		GUILayout.Label("Button name");
		GUILayout.Label("Sound Effect");
		GUILayout.EndHorizontal ();
		
		foreach(Transform go in m_Buttons)
		{
			GUILayout.BeginHorizontal();
			if(go.GetComponent<MenuSound>())
			{
				GUI.color = Color.cyan;
				GUILayout.BeginVertical();
				GUILayout.TextField(go.name, GUILayout.Width(200f));
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				string str;
				GUILayout.TextField(str = (go.GetComponent<MenuSound>().m_Asset == null) ? "" : go.GetComponent<MenuSound>().m_Asset.ToString(), GUILayout.Width(200f));
				GUILayout.EndVertical();
				GUI.color = Color.white;
			}
			else
			{	
				GUILayout.BeginVertical();
				GUILayout.TextField(go.name, GUILayout.Width(200f));
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.TextField("", GUILayout.Width(200f));
				GUILayout.EndVertical();
			}		
			GUILayout.EndHorizontal();
		}
	}

	void Update()
	{
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
		{
			if(obj.GetComponent<UIRoot>())
			{
				m_Roots.Add(obj);
			}
		}

		if(m_Roots != null && m_Index != 0)
		{
			if(m_Roots[m_Index] != null)
			{
				foreach(Transform child in m_Roots[m_Index].transform)
				{
					UpdateRecursivly(child);
				}
			}
		}
		else
		{
			m_Buttons.Clear();
		}

		/*if(Selection.activeTransform != null)
		{
			foreach(Transform child in Selection.activeTransform)
			{
				UpdateRecursivly(child);
			}
		}
		else
		{
			m_Buttons.Clear();
		}*/
	}

	void UpdateRecursivly(Transform trans)
	{
		int i = 0; 
		if(trans.childCount > 0)
		{
			foreach(Transform child in trans)
			{
				if(m_Buttons.Contains(child))
					continue;
				if(i == trans.childCount)
					break;

				else if(child.GetComponent<UIButton>())
				{
					m_Buttons.Add (child);
				}
				UpdateRecursivly(child);
				++i;
			}
		}
	}
}
