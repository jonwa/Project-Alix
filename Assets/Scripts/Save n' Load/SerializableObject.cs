using UnityEngine;
using System.Collections;

public abstract class SerializableObject : MonoBehaviour
{
	//public virtual string Name{get;set;}

	public abstract void  Serialize(ref JSONObject jsonObject);
	public abstract void  Deserialize(ref JSONObject jsonObject);
}
