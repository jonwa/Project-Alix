using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//[CanEditMultipleObjects]
//[CustomEditor(typeof(PortalPairHandler))]
//public class PortalPairHandlerEditor : Editor 
//{
//	private SerializedObject m_Object;
//	private SerializedProperty m_PortalId;
//	private SerializedProperty m_TargetPortals;
//
//	public void OnEnable()
//	{
//		m_Object = new SerializedObject(target);
//		m_PortalId = m_Object.FindProperty("m_PortalPairId");
//		m_TargetPortals = m_Object.FindProperty("m_TargetPortalsId");
//	}
//
//	public override void OnInspectorGUI()
//	{
//		m_Object.Update();
//		PortalPairHandler myTarget = target as PortalPairHandler;
//
//		EditorGUILayout.PropertyField(m_PortalId);
//
//		//m_PortalId = EditorGUILayout.IntField("Portal id", myTarget.m_PortalId);
//
//		m_TargetPortals.arraySize = PortalManager.NumberOfStages;
//		EditorGUILayout.Separator();
//		EditorGUILayout.LabelField("Target Portals");
//		for(int i=0; i< m_TargetPortals.arraySize; i++)
//		{
//			int value = m_TargetPortals.GetArrayElementAtIndex(i).intValue;
//
//			m_TargetPortals.GetArrayElementAtIndex(i).intValue = EditorGUILayout.IntField("id "+i, value) ;
//		}
//
//		m_Object.ApplyModifiedProperties();
//	}
//}
