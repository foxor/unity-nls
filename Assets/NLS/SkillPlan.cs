using UnityEngine;
using System.Collections;

public abstract class SkillPlan {
	protected GameObject actor;
	
	protected SkillSheet sheet;
	
	public SkillPlan(GameObject actor, SkillSheet sheet) {
		this.actor = actor;
		this.sheet = sheet;
	}
	
	protected abstract int difficulty {
		get;
	}
	
	protected abstract void apply();
	
	protected int skillId;
	
	public void Use() {
		float skill = sheet[skillId];
		float chanceSucceed = ((float)skill) / ((float)(skill + difficulty));
		float useQuality = (chanceSucceed - Random.Range(0f, 1f)) * ((float)difficulty);
		if (useQuality <= 0f) {
			return;
		}
		
		sheet.recordUse(skillId, useQuality * chanceSucceed / skill);
		apply();
	}
}

public class SkillPlanTest : SkillPlan {
	
	public SkillPlanTest(GameObject actor, SkillSheet sheet) : base(actor, sheet) {}
	
	protected override void apply ()
	{
		GameObject projectile = GameObject.Instantiate(Resources.Load("arrow")) as GameObject;
		projectile.transform.position += projectile.GetSkillMouseDelta();
	}
	protected override int difficulty {
		get {
			return 1;
		}
	}
}