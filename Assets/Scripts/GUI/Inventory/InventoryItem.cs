using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlstöm 2014-04-08
 * Modified By: 
 */

public class InventoryItem : MonoBehaviour 
{
	#region PrivateMemberVariables
	private string m_spritename = null; 
	private string m_DefaultSpriteName = "Slot01";
	#endregion

	public int 	Slot 	{ get; set; }
	public bool Occupied{ get; set; }

	void Start()
	{
		Occupied = false;
		GetComponentInChildren<UILabel>().enabled = false;
	}

	public void Replace(string item)
	{
		if(item == null)
		{
			GetComponent<UISprite>().spriteName = m_DefaultSpriteName;
			GetComponent<UIButton>().normalSprite = m_DefaultSpriteName;
			m_spritename 								  = null; 
		}
		else
		{
			m_spritename = item;
			ChangeTexture();
		}
	}

	public void DelayedReplace(string item)
	{
		m_spritename = item;
	}

	public void ChangeTexture()
	{
		if(m_spritename != null) 
		{
			GetComponent<UISprite>().spriteName = m_spritename;
			GetComponent<UIButton>().normalSprite = m_spritename;
		}
	}

	void OnClick()
	{
		if(Occupied)
		{
			Occupied = false;
			Replace(null);
			InventoryData.RemoveItem(Slot);
		}
		else
		{
			Camera.main.GetComponent<Raycasting>().Activate(Camera.main.GetComponent<Raycasting>().InteractingWith);
		}
	}
}
