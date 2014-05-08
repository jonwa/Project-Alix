using UnityEngine;
using System.Collections;

public class SingleBlock : MonoBehaviour 
{
	private bool m_Falling   = true;
	private bool m_Colliding = false;
	private bool m_HitLeft   = false;
	private bool m_HitRight  = false;

	// Use this for initialization
	void Start () 
	{
	
	}

	public bool GetHitLeft(){return m_HitLeft;}
	public void SetHitLeft(bool b){m_HitLeft = b;}
	public bool GetHitRight(){return m_HitRight;}
	public void SetHitRight(bool b){m_HitRight = b;}

	// Update is called once per frame
	void Update () 
	{
		if(m_Falling == true)	
		{
			CheckCollisionUnder();
			CheckCollisionLeft();
			CheckCollisionRight();
		}
	}

	private void CheckCollisionUnder()
	{
		//Check under
		RaycastHit[] hit;	
		Ray CollideRay = new Ray(transform.position, Vector3.down);	
		hit = Physics.RaycastAll(CollideRay, 0.3f);
		//Debug.DrawRay(transform.position, Vector3.down * 0.3f);
		m_Colliding = false;
		for(int i=0; i<hit.Length; i++)
		{
			if(hit[i].collider.tag == "Blocks")
			{
				if(hit[i].collider.gameObject.GetComponent<SingleBlock>().GetFalling() == false)
				{
					m_Colliding = true;
				}
				
			}
			else if(hit[i].collider.tag == "Floor")
			{
				m_Colliding = true;
			}
		}
	}
	private void CheckCollisionLeft()
	{
		//Check Left
		RaycastHit[] hit;	
		Ray CollideRay = new Ray(transform.position, Vector3.right);	
		hit = Physics.RaycastAll(CollideRay, 0.3f);
		//Debug.DrawRay(transform.position, Vector3.right * 0.3f);
		m_HitLeft = false;
		for(int i=0; i<hit.Length; i++)
		{
			if(hit[i].collider.tag == "Blocks")
			{
				if(hit[i].collider.gameObject.GetComponent<SingleBlock>().GetFalling() == false)
				{
					m_HitLeft = true;
				}
				
			}
			else if(hit[i].collider.tag == "Wall")
			{
				m_HitLeft = true;
			}
		}
	}
	private void CheckCollisionRight()
	{
		//Check Right
		RaycastHit[] hit;	
		Ray CollideRay = new Ray(transform.position, Vector3.left);	
		hit = Physics.RaycastAll(CollideRay, 0.3f);
		//Debug.DrawRay(transform.position, Vector3.down * 0.3f);
		m_HitRight = false;
		for(int i=0; i<hit.Length; i++)
		{
			if(hit[i].collider.tag == "Blocks")
			{
				if(hit[i].collider.gameObject.GetComponent<SingleBlock>().GetFalling() == false)
				{
					m_HitRight = true;
				}
				
			}
			else if(hit[i].collider.tag == "Wall")
			{
				m_HitRight = true;
			}
		}
	}

	public bool GetColliding()
	{
		return m_Colliding;
	}

	public bool GetFalling()
	{
		return m_Falling;
	}

	public void StopFalling()
	{
		m_Falling = false;
	}

	public void FallOneStep()
	{
		Vector3 nextMove = transform.position;
		nextMove.y -= gameObject.transform.collider.bounds.size.x;
		if(m_Falling == true)
		{
			transform.position = nextMove;
		}
	}

	public void FallSteps(int steps)
	{
		Vector3 nextMove = transform.position;
		nextMove.y -= gameObject.transform.collider.bounds.size.x * steps;
		transform.position = nextMove;
	}

	public void MoveLeft()
	{
		Vector3 nextMove = transform.position;
		nextMove.x += gameObject.transform.collider.bounds.size.x;
		if(m_Falling == true)
		{
			transform.position = nextMove;
		}
	}
	public void MoveRight()
	{
		Vector3 nextMove = transform.position;
		nextMove.x -= gameObject.transform.collider.bounds.size.x;
		if(m_Falling == true)
		{
			transform.position = nextMove;
		}
	}
}
