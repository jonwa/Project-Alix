using UnityEngine;
using System.Collections;

/* Discription: ParticleEffect trigger
 * Used for triggering particle effects
 * 
 * Created by: Sebastian Olsson 24-04-14
 * Modified by:
 */

public class ParticleEffect : TriggerComponent 
{
	#region PublicMemberVariables
	public ParticleSystem m_Particle;
	#endregion
	
	#region PrivateMemberVariables
	#endregion

	override public string Name
	{
		get{ return "EmitParticles"; }
	}

	void EmitParticles()
	{
		if (!m_Particle.isPlaying) 
		{
			m_Particle.Play();
		}
		else
		{
			m_Particle.Stop();
			m_Particle.Clear();
		}
	}

	void Start () 
	{
		m_Particle = Instantiate(m_Particle, this.transform.position, this.transform.rotation) as ParticleSystem;
	}

}
