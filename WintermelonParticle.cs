using UnityEngine;

public class WintermelonParticle : MonoBehaviour
{
	public ParticleSystem Ps;

	private void Start()
	{
		ParticleSystem.MainModule main = Ps.main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	private void OnParticleSystemStopped()
	{
		PoolManager.Instance.PushObj(GameManager.Instance.GameConf.WintermelonParticle, base.gameObject);
	}
}