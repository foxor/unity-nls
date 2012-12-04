using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

public class SkillPlan {
	
	private const string DIFFICULTY = "difficulty";
	
	private Actor actor;
	private XmlNode data;
	private Skill main;
	
	public SkillPlan(Actor actor, XmlNode data) {
		this.actor = actor;
		this.data = data;
		main = data.FindSkills().First();
	}
	
	private int difficulty {
		get {
			return data.Child(DIFFICULTY).GetInt();
		}
	}
	
	private void apply() {
		if (main.Projectile) {
			GameObject projectile = GameObject.Instantiate(Resources.Load(main.Name)) as GameObject;
			projectile.transform.position += projectile.GetSkillMouseDelta();
		}
	}
	
	public void Use() {
		float skill = actor.sheet[main.Id];
		float chanceSucceed = ((float)skill) / ((float)(skill + difficulty));
		float useQuality = (chanceSucceed - Random.Range(0f, 1f)) * ((float)difficulty);
		if (useQuality <= 0f) {
			return;
		}
		
		actor.sheet.recordUse(main.Id, useQuality * chanceSucceed / skill);
		apply();
	}
}

public static class SkillPlanUtils {
	private const string SKILL_PLAN = "skillPlan";
	
	public static IEnumerable<SkillPlan> FindSkillPlans(this XmlNode xn, Actor actor) {
		return xn.Children(SKILL_PLAN).Map<SkillPlan>(x => new SkillPlan(actor, x));
	}
}