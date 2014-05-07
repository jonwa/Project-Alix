using UnityEngine;
using System.Collections;

public class UpdatedTv : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		renderer.material.SetFloat("_Random", Random.Range(0f, 1f));
	}
}
