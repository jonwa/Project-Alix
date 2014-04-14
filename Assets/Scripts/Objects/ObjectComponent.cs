using UnityEngine;
using System.Collections;

/* Discription: Base class for object components
 * 
 * Created by: Robert and Sebastian Datum: 2014-04-02
 * Modified by: Jon Wahlström 2014-04-11
 * 
 */

public class ObjectComponent :  MonoBehaviour
{
    private bool m_IsActive = false;
   

	public bool IsActive
	{
		get { return m_IsActive; }
		set { m_IsActive = value;}
	}

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

    // If raycast hits object and left mouse button is pressed object is active
    public void Activate()
    {
		m_IsActive = true;
    }

	//When left mouse button is released the object goes unactive
	public void DeActivate()
	{
		m_IsActive = false;
	}
}
