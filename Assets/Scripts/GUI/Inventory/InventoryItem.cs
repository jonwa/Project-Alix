using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlstöm 2014-04-08
 * Modified By: 
 */

public class InventoryItem : MonoBehaviour 
{
	public UISprite	 m_Icon; 
	public UILabel   m_Label; 
	public bool 	 m_Occupied = false;
	private int 	 m_Id;

	public int Id
	{
		get { return m_Id;  }
		set { m_Id = value; }
	}

	void Start()
	{
		Replace(null);
	}

	void Replace(string sprite)
	{
		if(sprite == null) 
		{
			GetComponentInChildren<UISprite>().spriteName = "Default";
			GetComponent<UIButton>().normalSprite = "Default";
		}
		else
		{
			GetComponentInChildren<UISprite>().spriteName = sprite;
			GetComponent<UIButton>().normalSprite = sprite;
		}
	}

	void OnClick()
	{
		Replace (null);
		UpdateCursor();
	}

	void OnDrag(Vector2 delta)
	{
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
		Replace(null);
		UpdateCursor();
	}

	void OnDrop(GameObject go)
	{
		//Replace (go.GetComponentInChildren<UISprite>().spriteName);
	}

	void UpdateCursor()
	{
		UICursor.Set(GetComponentInChildren<UISprite>().atlas, GetComponentInChildren<UISprite>().spriteName);
	}
}
