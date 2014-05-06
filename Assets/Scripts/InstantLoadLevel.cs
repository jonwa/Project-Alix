using UnityEngine;
using System.Collections;

public class InstantLoadLevel : MonoBehaviour 
{
	void Start()
	{
		Application.LoadLevel(1);
	}
}
