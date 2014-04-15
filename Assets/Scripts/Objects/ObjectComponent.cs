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


	//// Should-type flags
	//protected class Unlock_t {};
	//static protected Unlock_t Unlock = new Unlock_t();
	//
	////protected class DestructSelf_t {};
	////static protected DestructSelf_t DestructSelf = new DestructSelf_t();
	////
	////protected class Hook_t {};
	////static protected Hook_t Hook = new Hook_t();
	//
	//
	//protected bool Should(Hook_t whenhitting, GameObject other)
	//{
	//	if (other == GetComponent<SpellData>().Caster)
	//	{
	//		return false;
	//	}
	//	
	//	if (other.GetComponent<SuperSolid> ())
	//	{
	//		return true;
	//	}
	//	
	//	if (other.GetComponent<SpellData> ())
	//	{
	//		return false;
	//	}
	//	
	//	if (other.GetComponent<NonSolid> ())
	//	{
	//		return false;
	//	}
	//	
	//	return true;
	//	
	//	
	//}

    public virtual void Interact()
    {

    }

    // If raycast hits object and left mouse button is pressed object is active
    public virtual void Activate()
    {
		m_IsActive = true;
    }

	//When left mouse button is released the object goes unactive
	public virtual void DeActivate()
	{
		m_IsActive = false;
	}
}
