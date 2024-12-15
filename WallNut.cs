using FTRuntime;
using UnityEngine;

public class WallNut : PlantBase
{
	public Sprite State2;

	public Sprite State3;

	private int state1;

	private int state2;

	private float lastHp;

	public override float MaxHp => 4000f;

	protected override PlantType plantType => PlantType.WallNut;

	protected override void HpUpdateEvents(ZombieBase zombie, bool isFlat)
	{
		if (base.Hp < lastHp)
		{
			PoolManager.Instance.GetObj(GameManager.Instance.GameConf.NutParticle).transform.position = base.transform.position;
		}
		if (base.Hp <= (float)state1 && base.Hp >= (float)state2)
		{
			clipController.clip.NewSprite = State2;
		}
		else if (base.Hp <= (float)state2)
		{
			clipController.clip.NewSprite = State3;
		}
		else
		{
			clipController.clip.NewSprite = null;
		}
		lastHp = base.Hp;
		if (base.Hp <= 0f && zombie != null)
		{
			AudioManager.Instance.PlayEFAudio(GameManager.Instance.AudioConf.gulp, base.transform.position);
		}
	}

	protected override void OnInitForPlace()
	{
		state1 = (int)MaxHp / 3 * 2;
		state2 = (int)MaxHp / 3;
		lastHp = base.Hp;
	}

	protected override void FrameChangeEvent(SwfClip swfClip)
	{
		if (swfClip.currentFrame == closeEyeFrame)
		{
			StartCloseEyes();
		}
	}

	protected override void OnInitForAll()
	{
		clipController.clip.NewSprite = null;
	}
}