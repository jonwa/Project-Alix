using UnityEngine;
using System.Collections;

/* Discription: Base class for object components
 * 
 * Created by: Robert and Sebastian Datum: 02/04-14
 * Modified by:
 * 	
 */

public class ObjectComponent : MonoBehaviour
{
    private bool m_isActive = false;
   

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

	public virtual void Should()
    {

    }

	public virtual void Interact()
    {

    }

    // If raycast hits object and leftmouse is pressed object is active
    public void Activate()
    {
    	m_isActive = true;
    }
}
