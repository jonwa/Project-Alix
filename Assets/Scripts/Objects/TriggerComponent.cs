using UnityEngine;
using System.Collections;

/* Discription: Base class for triggers on objects
 * 
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */

public class TriggerComponent :  MonoBehaviour
{
	public virtual string Name
	{ get{return"";}}

	// Use this for initialization
	void Start()
	{
		
	}
	
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	public virtual void Init()
	{
		
	}


	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
