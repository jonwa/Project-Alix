using UnityEngine;
using UnityEditor;
using System.Collections;

//[CustomEditor (typeof(SuperTrigger))]
public class SuperTriggerEditor : Editor
{
	/*//public void OnInspectorGUI1()
	public override void OnInspectorGUI()
    {
		SuperTrigger ST = (SuperTrigger)target;
		EditorGUILayout.LabelField ("Type of trigger:");
		EditorGUI.indentLevel++;

		CollaborateSelfLayout (ST);
		CollaborateGetLayout (ST);
		TriggerSelfLayout (ST);
		TriggerGetLayout (ST);
		TimeLayout (ST);
		CollisionLayout (ST);
		ButtonLayout (ST);
		PadlockLayout (ST);
		MultipleLayout (ST);
		EditorGUI.indentLevel--;

		EditorGUILayout.LabelField ("TriggerEffects:");
		EditorGUI.indentLevel++;

		WithoutCounterLayout (ST);
		WithCounterLayout (ST);
	}

	void WithoutCounterLayout(SuperTrigger ST)
	{
		ST.m_AlwaysRunning = EditorGUILayout.Toggle ("Always going to run: ", ST.m_AlwaysRunning, GUILayout.Height (15));
		if(ST.m_AlwaysRunning)
		{
			EditorGUI.indentLevel++;
			int capacity = EditorGUILayout.IntField("Number of Effects",ST.m_MessageAlways.Capacity, GUILayout.Height (20),GUILayout.Width (170));
			
			ST.m_MessageAlways.Clear();
			ST.m_TriggerOnce.Clear();
			ST.m_MessageAlways.TrimExcess();
			ST.m_TriggerOnce.TrimExcess();
			ST.m_MessageAlways.Capacity = capacity;
			ST.m_TriggerOnce.Capacity = capacity;
			for(int i = 0; i < ST.m_MessageAlways.Capacity; i++)
			{				
				ST.m_TriggerOnce.Add(false);
				ST.m_MessageAlways.Add("");
			}
			if(ST.m_MessageAlways.Capacity > 0){
				EditorGUI.indentLevel++;
				GUILayout.BeginHorizontal(GUILayout.Height(15));
				EditorGUILayout.LabelField ("Effects",GUILayout.Height(15), GUILayout.Width(130));
				EditorGUILayout.LabelField ("Trigger once");
				GUILayout.EndHorizontal();
				for(int i = 0; i < ST.m_MessageAlways.Count; i ++)
				{
					GUILayout.BeginHorizontal(GUILayout.Height(15));
					ST.m_MessageAlways[i] = EditorGUILayout.TextField(ST.m_MessageAlways[i], GUILayout.Height(15), GUILayout.Width(150));
					ST.m_TriggerOnce[i] = EditorGUILayout.Toggle(ST.m_TriggerOnce[i], GUILayout.Height(15), GUILayout.Width(170));
					GUILayout.EndHorizontal();
				}
				EditorGUI.indentLevel--;
			}
			EditorGUI.indentLevel--;
		}
	}

	void WithCounterLayout(SuperTrigger ST)
	{
		ST.m_CounterOnly = EditorGUILayout.Toggle ("Run at counit: ", ST.m_CounterOnly, GUILayout.Height (15));
		if(ST.m_CounterOnly)
		{
			EditorGUI.indentLevel++;
			int capacity = EditorGUILayout.IntField("Number of Effects",ST.m_MessageCount.Capacity, GUILayout.Height (20),GUILayout.Width (170));
			
			ST.m_MessageCount.Clear();
			ST.m_CounterValue.Clear();
			ST.m_MessageCount.TrimExcess();
			ST.m_CounterValue.TrimExcess();
			ST.m_MessageCount.Capacity = capacity;
			ST.m_CounterValue.Capacity = capacity;
			for(int i = 0; i < ST.m_MessageCount.Capacity; i++)
			{				
				ST.m_CounterValue.Add(0);
				ST.m_MessageCount.Add("");
			}
			if(ST.m_MessageCount.Capacity > 0){
				EditorGUI.indentLevel++;
				GUILayout.BeginHorizontal(GUILayout.Height(15));
				EditorGUILayout.LabelField ("Effects",GUILayout.Height(15), GUILayout.Width(130));
				EditorGUILayout.LabelField ("Counter Value");
				GUILayout.EndHorizontal();
				for(int i = 0; i < ST.m_MessageCount.Count; i ++)
				{
					GUILayout.BeginHorizontal(GUILayout.Height(15));
					ST.m_MessageCount[i] = EditorGUILayout.TextField(ST.m_MessageCount[i], GUILayout.Height(15), GUILayout.Width(150));
					ST.m_CounterValue[i] = EditorGUILayout.IntField(ST.m_CounterValue[i], GUILayout.Height(15), GUILayout.Width(80));
					GUILayout.EndHorizontal();
				}
				EditorGUI.indentLevel--;
			}
			EditorGUI.indentLevel--;
		}
	}
	
	void CollaborateSelfLayout(SuperTrigger ST)
	{
		ST.m_CollaborateSelf = EditorGUILayout.Toggle ("CollaborateSelf: ", ST.m_CollaborateSelf, GUILayout.Height (15));
		if(ST.m_CollaborateSelf)
		{
			EditorGUI.indentLevel++;
			int capacity = EditorGUILayout.IntField("Number of IDs",ST.m_IDsCollaborate.Capacity, GUILayout.Height (20),GUILayout.Width (170));
			ST.m_IDsCollaborate.Clear();
			ST.m_IDsCollaborate.TrimExcess();
			ST.m_IDsCollaborate.Capacity = capacity;
			for(int i = 0; i < ST.m_IDsCollaborate.Capacity; i++)
			{				
				ST.m_IDsCollaborate.Add(0);
			}
			
			EditorGUI.indentLevel++;
			for(int i = 0; i < ST.m_IDsCollaborate.Count; i ++)
			{
				ST.m_IDsCollaborate[i] = EditorGUILayout.IntField("TriggerID: " + (i+1),ST.m_IDsCollaborate[i], GUILayout.Height(15), GUILayout.Width(170));
			}
			EditorGUI.indentLevel--;
			
			ST.m_CollaborateInput = EditorGUILayout.TextField("Input",ST.m_CollaborateInput,GUILayout.Height (15),GUILayout.Width (180));
			EditorGUI.indentLevel--;
		}
	}

	void TriggerSelfLayout(SuperTrigger ST)
	{
		ST.m_TriggerSelf = EditorGUILayout.Toggle ("TriggerSelf: ", ST.m_TriggerSelf, GUILayout.Height (15));
		if(ST.m_TriggerSelf)
		{
			EditorGUI.indentLevel++;
			int capacity = EditorGUILayout.IntField("Number of IDs",ST.m_IDsTrigger.Capacity, GUILayout.Height (15),GUILayout.Width (170));
			ST.m_IDsTrigger.Clear();
			ST.m_IDsTrigger.TrimExcess();
			ST.m_IDsTrigger.Capacity = capacity;
			for(int i = 0; i < ST.m_IDsTrigger.Capacity; i++)
			{		
				ST.m_IDsTrigger.Add(0);
			}
			
			EditorGUI.indentLevel++;
			for(int i = 0; i < ST.m_IDsTrigger.Count; i ++)
			{
				ST.m_IDsTrigger[i] = EditorGUILayout.IntField("TriggerID: " + (i+1),ST.m_IDsTrigger[i], GUILayout.Height(15), GUILayout.Width(170));
			}
			EditorGUI.indentLevel--;
			EditorGUI.indentLevel--;
		}
	}

	void MultipleLayout(SuperTrigger ST)
	{
		ST.m_Multiple = EditorGUILayout.Toggle ("Multiple: ", ST.m_Multiple, GUILayout.Height (15));
		if(ST.m_Multiple)
		{
			EditorGUI.indentLevel++;
			int capacity = EditorGUILayout.IntField("Number of IDs",ST.m_IDsMulti.Capacity, GUILayout.Height (15),GUILayout.Width (170));
			ST.m_IDsMulti.Clear();
			ST.m_IDsMulti.TrimExcess();
			ST.m_IDsMulti.Capacity = capacity;
			for(int i = 0; i < ST.m_IDsMulti.Capacity; i++)
			{		
				ST.m_IDsMulti.Add(0);
			}
			
			EditorGUI.indentLevel++;
			for(int i = 0; i < ST.m_IDsMulti.Count; i ++)
			{
				ST.m_IDsMulti[i] = EditorGUILayout.IntField("Must Trigger ID: " + (i+1),ST.m_IDsMulti[i], GUILayout.Height(15), GUILayout.Width(170));
			}
			EditorGUI.indentLevel--;
			EditorGUI.indentLevel--;
		}
	}

	void TimeLayout(SuperTrigger ST)
	{
		ST.m_Time = EditorGUILayout.Toggle ("Time: ", ST.m_Time, GUILayout.Height (15));
		if(ST.m_Time)
		{
			EditorGUI.indentLevel++;

			ST.m_TimeDelay = EditorGUILayout.IntField("Delay: ",ST.m_TimeDelay, GUILayout.Height (15), GUILayout.Width(170));

			EditorGUI.indentLevel--;
		}
	}

	void ButtonLayout(SuperTrigger ST)
	{
		ST.m_Button = EditorGUILayout.Toggle ("Button: ", ST.m_Button, GUILayout.Height (15));
	}
	
	void PadlockLayout(SuperTrigger ST)
	{
		ST.m_Padlock = EditorGUILayout.Toggle ("Padlock: ", ST.m_Padlock, GUILayout.Height (15));
	}

	void CollaborateGetLayout(SuperTrigger ST)
	{
		ST.m_CollaborateGet = EditorGUILayout.Toggle ("CollaborateGet: ", ST.m_CollaborateGet, GUILayout.Height (15));
	}

	void TriggerGetLayout(SuperTrigger ST)
	{
		ST.m_TriggerGet = EditorGUILayout.Toggle ("TriggerGet: ", ST.m_TriggerGet, GUILayout.Height (15));
	}

	void CollisionLayout(SuperTrigger ST)
	{
		ST.m_Collision = EditorGUILayout.Toggle ("Collision: ", ST.m_Collision, GUILayout.Height (15));
	}*/
}