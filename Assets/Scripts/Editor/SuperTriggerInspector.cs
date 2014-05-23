using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

/* Custom inspector field for the SuperTrigger.cs
 * 
 * Created By: Jon Wahlström 2014-05-23
 */

[CustomEditor(typeof(SuperTrigger))]
public class SuperTriggerInspector : Editor 
{
	bool _foldoutTriggerTypes = true; 
	bool _foldoutFirstList = true;
	bool _foldoutCounters = true; 
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		SuperTrigger st = (SuperTrigger)target; 

		GUI.color = Color.cyan;
		_foldoutTriggerTypes = EditorGUILayout.Foldout (_foldoutTriggerTypes, "Trigger Types");
		GUI.color = Color.white;

		if(_foldoutTriggerTypes)
		{
			NGUIEditorTools.BeginContents();
			DrawTriggerTypes(st);
			NGUIEditorTools.EndContents();
		}

		GUI.color = Color.cyan;
		_foldoutFirstList = EditorGUILayout.Foldout (_foldoutFirstList, "Always Execute");
		GUI.color = Color.white;

		if(_foldoutFirstList)
		{
			NGUIEditorTools.BeginContents();
			DrawFirstList(st);
			NGUIEditorTools.EndContents();
		}

		GUI.color = Color.cyan;
		_foldoutCounters = EditorGUILayout.Foldout (_foldoutCounters, "Execute At Count");
		GUI.color = Color.white;

		if(_foldoutCounters)
		{
			NGUIEditorTools.BeginContents();
			DrawCounters(st);
			NGUIEditorTools.EndContents();
		}

		if(GUI.changed)
		{
			EditorUtility.SetDirty(st);
		}
	}

	bool _foldoutCollaborateIDs = true;
	int _size_collaborateIDs = 0;
	bool _foldoutMultipleIDs = true;
	int _size_multipleIDs = 0;
	bool _foldoutTriggerIDs = true; 
	int _size_triggerIDs = 0;
	private void DrawTriggerTypes(SuperTrigger st)
	{
		GUI.color = Color.yellow;
		GUILayout.Label ("Triggers to add on this GameObject:");
		GUI.color = Color.white;

		st.m_CollaborateSelf = EditorGUILayout.ToggleLeft ("Collaborate", st.m_CollaborateSelf);
		if(st.m_CollaborateSelf)
		{
			st.m_CollaborateInput = EditorGUILayout.TextField ("Input", st.m_CollaborateInput);

			GUILayout.BeginHorizontal ();
			GUILayout.Space (20);
			_foldoutCollaborateIDs = EditorGUILayout.Foldout (_foldoutCollaborateIDs, "Collaborate IDs");
			GUILayout.EndHorizontal ();
			if(_foldoutCollaborateIDs)
			{
				_size_collaborateIDs = EditorGUILayout.IntField ("\t\tsize", st.m_IDsCollaborate.Capacity);
				if(_size_collaborateIDs < 0)
					_size_collaborateIDs = 0;

				if(_size_collaborateIDs != st.m_IDsCollaborate.Capacity)
				{
					st.m_IDsCollaborate.Clear();
					st.m_IDsCollaborate.TrimExcess();
					st.m_IDsCollaborate.Capacity = _size_collaborateIDs;

					for(int i = 0; i < _size_collaborateIDs; ++i)
					{
						st.m_IDsCollaborate.Add(0);
					}
				}
			
				for(int i = 0; i < _size_collaborateIDs; ++i)
				{
					st.m_IDsCollaborate[i] = EditorGUILayout.IntField("\t\t\tId", st.m_IDsCollaborate[i]);
				}
			}
		}

		st.m_TriggerSelf = EditorGUILayout.ToggleLeft("Triggering", st.m_TriggerSelf);
		if(st.m_TriggerSelf)
		{
			GUILayout.BeginHorizontal ();
			GUILayout.Space (20);
			_foldoutTriggerIDs = EditorGUILayout.Foldout (_foldoutTriggerIDs, "Trigger IDs");
			GUILayout.EndHorizontal ();
			if(_foldoutTriggerIDs)
			{
				_size_triggerIDs = EditorGUILayout.IntField ("\t\t\tsize", st.m_IDsTrigger.Capacity);
				if(_size_triggerIDs < 0)
					_size_triggerIDs = 0;

				if(_size_triggerIDs != st.m_IDsTrigger.Capacity)
				{
					st.m_IDsTrigger.Clear();
					st.m_IDsTrigger.TrimExcess();
					st.m_IDsTrigger.Capacity = _size_triggerIDs;

					for(int i = 0; i < _size_triggerIDs; ++i)
					{
						st.m_IDsTrigger.Add(0);
					}
				}

				for(int i = 0; i < _size_triggerIDs; ++i)
				{
					st.m_IDsTrigger[i] = EditorGUILayout.IntField("\t\t\t\tId", st.m_IDsTrigger[i]);
				}
			}
		}

		st.m_Time = EditorGUILayout.ToggleLeft("Time", st.m_Time, GUILayout.Width(80));
		if(st.m_Time)
		{
			st.m_TimeDelay = EditorGUILayout.IntField("\tTime Delay", st.m_TimeDelay);
			if(st.m_TimeDelay < 0)
				st.m_TimeDelay = 0;
		}
		st.m_Collision = EditorGUILayout.ToggleLeft("Collision", st.m_Collision);
		st.m_Multiple = EditorGUILayout.ToggleLeft("Multiple Collaboration", st.m_Multiple);
		if(st.m_Multiple)
		{
			GUILayout.BeginHorizontal ();
			GUILayout.Space (20);
			_foldoutMultipleIDs = EditorGUILayout.Foldout (_foldoutMultipleIDs, "Multiple IDs");
			GUILayout.EndHorizontal ();
			if(_foldoutMultipleIDs)
			{
				_size_multipleIDs = EditorGUILayout.IntField ("\t\t\tsize", st.m_IDsMulti.Capacity);
				if(_size_multipleIDs < 0)
					_size_multipleIDs = 0;

				if(_size_multipleIDs != st.m_IDsMulti.Capacity)
				{
					st.m_IDsMulti.Clear();
					st.m_IDsMulti.TrimExcess();
					st.m_IDsMulti.Capacity = _size_multipleIDs;

					for(int i = 0; i < _size_multipleIDs; ++i)
					{
						st.m_IDsMulti.Add(0);
					}
				}

				for(int i = 0; i < _size_multipleIDs; ++i)
				{
					st.m_IDsMulti[i] = EditorGUILayout.IntField("\t\t\t\tId", st.m_IDsMulti[i]);
				}
			}
		}
		st.m_Button = EditorGUILayout.ToggleLeft("Button", st.m_Button);
		st.m_Padlock = EditorGUILayout.ToggleLeft("Padlock", st.m_Padlock);

		GUILayout.Space (10);

		GUI.color = Color.yellow;
		GUILayout.Label ("Effects set to other GameObject:");
		GUI.color = Color.white;

		st.m_TriggerGet = EditorGUILayout.ToggleLeft("Getting Triggered", st.m_TriggerGet);
		st.m_CollaborateGet = EditorGUILayout.ToggleLeft ("Getting Collaborated", st.m_CollaborateGet);
	}

	bool _foldoutMessageAlways = true; 
	int _size_MessageAlways = 0;
	private void DrawFirstList(SuperTrigger st)
	{
		st.m_AlwaysRunning = EditorGUILayout.ToggleLeft("Always Running", st.m_AlwaysRunning);
		if(st.m_AlwaysRunning)
		{
			EditorGUI.indentLevel++;
			_foldoutMessageAlways = EditorGUILayout.Foldout (_foldoutMessageAlways, "Message Always");
			if(_foldoutMessageAlways)
			{
				_size_MessageAlways = EditorGUILayout.IntField ("\tsize", st.m_MessageAlways.Capacity);
				if(_size_MessageAlways < 0)
					_size_MessageAlways = 0;

				if(_size_MessageAlways > 0)
				{
					GUILayout.BeginHorizontal();
					GUILayout.Label("\t\t\tMessage");
					GUILayout.Label("\t\t\tTrigger Once");
					GUILayout.EndHorizontal();
				}

				if(_size_MessageAlways != st.m_MessageAlways.Capacity)
				{
					st.m_MessageAlways.Clear();
					st.m_MessageAlways.TrimExcess();
					st.m_MessageAlways.Capacity = _size_MessageAlways;
					st.m_TriggerOnce.Clear();
					st.m_TriggerOnce.TrimExcess();
					st.m_TriggerOnce.Capacity = _size_MessageAlways;

					for(int i = 0; i < _size_MessageAlways; ++i)
					{
						st.m_MessageAlways.Add("");
						st.m_TriggerOnce.Add(false);
					}
				}
			
				EditorGUI.indentLevel++;
				EditorGUI.indentLevel++;
				for(int i = 0; i < _size_MessageAlways; ++i)
				{
					GUILayout.BeginHorizontal();
					st.m_MessageAlways[i] = EditorGUILayout.TextField(st.m_MessageAlways[i]);
					st.m_TriggerOnce[i] = EditorGUILayout.Toggle(st.m_TriggerOnce[i]);
					GUILayout.EndHorizontal();
				}
				EditorGUI.indentLevel--;
				EditorGUI.indentLevel--;
			}
			EditorGUI.indentLevel--;
		}
	}

	bool _foldoutMessageCount = true; 
	int _size_MessageCount = 0; 
	private void DrawCounters(SuperTrigger st)
	{
		st.m_CounterOnly = EditorGUILayout.ToggleLeft("Counter Only", st.m_CounterOnly);

		if(st.m_CounterOnly)
		{
			EditorGUI.indentLevel++;

			_foldoutMessageCount = EditorGUILayout.Foldout (_foldoutMessageCount, "Message Count");

			if(_foldoutMessageCount)
			{
				_size_MessageCount = EditorGUILayout.IntField ("\tsize", st.m_MessageCount.Capacity);
				if(_size_MessageCount < 0)
					_size_MessageCount = 0;

				if(_size_MessageCount > 0)
				{
					GUILayout.BeginHorizontal();
					GUILayout.Label("\t\t\tMessage");
					GUILayout.Label("\t\t\tCounter Value");
					GUILayout.EndHorizontal();
				}

				if(_size_MessageCount != st.m_MessageCount.Capacity)
				{
					st.m_MessageCount.Clear();
					st.m_MessageCount.TrimExcess();
					st.m_MessageCount.Capacity = _size_MessageCount;
					st.m_CounterValue.Clear();
					st.m_CounterValue.TrimExcess();
					st.m_CounterValue.Capacity = _size_MessageCount;

					for(int i = 0; i < _size_MessageCount; ++i)
					{
						st.m_MessageCount.Add("");
						st.m_CounterValue.Add(0);
					}
				}

				EditorGUI.indentLevel++;
				EditorGUI.indentLevel++;
				for(int i = 0; i < _size_MessageCount; ++i)
				{
					GUILayout.BeginHorizontal();
					st.m_MessageCount[i] = EditorGUILayout.TextField(st.m_MessageCount[i]);
					st.m_CounterValue[i] = EditorGUILayout.IntField(st.m_CounterValue[i]);
					GUILayout.EndHorizontal();
				}
				EditorGUI.indentLevel--;
				EditorGUI.indentLevel--;
			}
			EditorGUI.indentLevel--;
		}
	}
}
