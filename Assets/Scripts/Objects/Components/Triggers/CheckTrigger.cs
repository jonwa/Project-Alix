using UnityEngine;
using System.Collections;
using System.Linq;

public class CheckTrigger : MonoBehaviour 
{
	public int[] m_TargetIds;

	void Trigger()
	{
		Id[] objs = Object.FindObjectsOfType<Id>();
		foreach(Id i in objs)
		{
			if(m_TargetIds.Contains(i.ObjectId))
			{
				int id = GetComponent<Id>().ObjectId;
				i.gameObject.GetComponent<MultipleCollaborationTrigger>().AddToTriggeredList(id);
			}
		}
	}
}
