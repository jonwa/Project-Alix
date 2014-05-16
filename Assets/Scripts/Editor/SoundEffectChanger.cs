using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;

/* Search through the hierarchy, finds all object with the specific sound component. 
 * Makes it easier to change sound to multiple Objects.
 * 
 * Created By: Jon Wahlström, Sebastian Olsson 2014-05-13
 */

public class SoundEffectChanger : EditorWindow 
{
	[MenuItem("LOL/Sound Toooool")]
	private static void showEditor ()
	{
		EditorWindow window = EditorWindow.GetWindow<SoundEffectChanger> (false, "Tool");
		window.minSize = new Vector2 (250, 350);
	}

	private string[] m_SoundComponents = new string[12]{"None", "DoorSound", "DrawerSound", "MovieAudio", 
													   "PhoneConversation", "PhoneSound", "VCRSound", "WalkSound",
													   "SoundEffect", "MusicManager", "MenuSound", "ObjectSound"};
	private int m_SoundComponentIndex = 0;
	private int m_SoundComponentPreviousIndex = 0; 

	//private List<GameObject> m_ObjectsWithComponent = new List<GameObject>();
	//private List<FMODAsset>  m_AssetList			= new List<FMODAsset>();

	private Dictionary<GameObject, FMODAsset> m_ObjectsWithComponent = new Dictionary<GameObject, FMODAsset>();
	Dictionary<GameObject, FMODAsset> 		  m_Assets = new Dictionary<GameObject, FMODAsset>();

	void OnGUI()
	{
		bool apply = false; 

		NGUIEditorTools.DrawHeader ("Input", false);
		{
			NGUIEditorTools.BeginContents();

			GUILayout.Space(10f);

			// Draw a popup list of sound components
			GUILayout.BeginHorizontal ();
			m_SoundComponentIndex = EditorGUILayout.Popup ("Sound Component", m_SoundComponentIndex, m_SoundComponents);	
			if(m_SoundComponentPreviousIndex != m_SoundComponentIndex)
			{
				m_Assets.Clear();
				m_SoundComponentPreviousIndex = m_SoundComponentIndex;
			}

			GUILayout.EndHorizontal ();

			NGUIEditorTools.EndContents();
		}

		NGUIEditorTools.DrawHeader ("Output", false);
		{
			NGUIEditorTools.BeginContents();
			
			// Draw a FMOD asset field
			DrawObjectsWithComponent();

			NGUIEditorTools.EndContents();

		}

		GUILayout.Space (10f);

		GUILayout.BeginHorizontal ();
		GUI.color = Color.green;
		apply = GUILayout.Button ("Apply", GUILayout.Width(200));
		GUI.color = Color.white;
		GUILayout.EndHorizontal ();

		if(apply)
		{
			ApplyChanges();
		}
	}

	void Update()
	{
		m_ObjectsWithComponent.Clear ();
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
		{
			if(obj.GetComponent(m_SoundComponents[m_SoundComponentIndex]))
			{
				if(!m_ObjectsWithComponent.ContainsKey(obj))
				{
					m_ObjectsWithComponent.Add(obj, GetComponent (obj, m_SoundComponents[m_SoundComponentIndex].ToString()));
				}
			}
		}
		foreach(KeyValuePair<GameObject, FMODAsset> kvPair in m_ObjectsWithComponent)
		{
			if(!m_Assets.ContainsKey(kvPair.Key))
				m_Assets.Add(kvPair.Key, kvPair.Value);
		}
	}

	private void DrawObjectsWithComponent()
	{
		if(m_ObjectsWithComponent.Count > 0)
		{
			foreach(KeyValuePair<GameObject, FMODAsset> kvPair in m_ObjectsWithComponent)
			{
				GUILayout.BeginHorizontal();
				
				GUILayout.BeginVertical();
				GameObject go = kvPair.Key; 
				go = EditorGUILayout.ObjectField (go, typeof(GameObject), false) as GameObject;
				GUILayout.EndVertical(); 
				
				GUILayout.BeginVertical();
				if(m_Assets.Count > 0)
					m_Assets[go] = EditorGUILayout.ObjectField (m_Assets[go], typeof(FMODAsset), false) as FMODAsset;
				GUILayout.EndVertical();

				GUILayout.EndHorizontal();
			}
		}
	}

	private FMODAsset GetComponent(GameObject go, string str)
	{
		switch(str)
		{
		case "None":
			return null;
			break;
		case "DoorSound":
			return go.GetComponent<DoorSound>().m_Asset;
			break;
		case "DrawerSound":
			return go.GetComponent<DrawerSound>().m_Asset;
			break;
		case "MovieAudio":
			return go.GetComponent<MovieAudio>().m_Asset;
			break;
		case "PhoneConversation":
			return go.GetComponent<PhoneConversation>().m_Asset;
			break;
		case "PhoneSound":
			return go.GetComponent<PhoneSound>().m_Asset;
			break;
		case "VCRSound":
			return go.GetComponent<VCRSound>().m_Asset;
			break;
		case "WalkSound":
			return go.GetComponent<WalkSound>().m_Asset;
			break;
		case "SoundEffect":
			return go.GetComponent<SoundEffect>().m_Asset;
			break;
		case "MusicManager":
			return go.GetComponent<MusicManager>().m_Asset;
			break;
		case "MenuSound":
			return go.GetComponent<MenuSound>().m_Asset;
			break;
		case "ObjectSound":
			return go.GetComponent<ObjectSound>().m_Asset;
			break;
		default:
			return null;
			break;
		}
	}

	private void SetComponent(string str)
	{
		foreach(KeyValuePair<GameObject, FMODAsset> kvPair in m_ObjectsWithComponent)
		{
			GameObject go = kvPair.Key;
			FMODAsset asset = m_Assets[go];
			switch(str)
			{
			case "None":
				break;
			case "DoorSound":
				go.GetComponent<DoorSound>().m_Asset = asset;
				break;
			case "DrawerSound":
				go.GetComponent<DrawerSound>().m_Asset = asset;
				break;
			case "MovieAudio":
				go.GetComponent<MovieAudio>().m_Asset = asset;
				break;
			case "PhoneConversation":
				go.GetComponent<PhoneConversation>().m_Asset = asset;
				break;
			case "PhoneSound":
				go.GetComponent<PhoneSound>().m_Asset = asset;
				break;
			case "VCRSound":
				go.GetComponent<VCRSound>().m_Asset = asset;
				break;
			case "WalkSound":
				go.GetComponent<WalkSound>().m_Asset = asset;
				break;
			case "SoundEffect":
				go.GetComponent<SoundEffect>().m_Asset = asset;
				break;
			case "MusicManager":
				go.GetComponent<MusicManager>().m_Asset = asset;
				break;
			case "MenuSound":
				go.GetComponent<MenuSound>().m_Asset = asset;
				break;
			case "ObjectSound":
				go.GetComponent<ObjectSound>().m_Asset = asset;
				break;
			}
		}
	}

	private void ApplyChanges()
	{
		SetComponent(m_SoundComponents[m_SoundComponentIndex]);
	}
}
