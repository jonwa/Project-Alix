using UnityEngine;
using System.Collections;

/* Description: Put on a object with BoxCollider (set to trigger) and triggers save function in GameData
 * 
 * Created by: jimmy 2014-04-29
 */

[RequireComponent(typeof(BoxCollider))]
public class CheckPointSaver : MonoBehaviour 
{
	void Start()
	{
		GetComponent<BoxCollider>().isTrigger = true;
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			GameData.Save("",true);
		}
	}
}
