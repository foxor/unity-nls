using UnityEngine;
using System.Collections;

public class SkillComposite {
	private Skill node;
	private SkillComposite[] children;
	
	public SkillComposite(Skill terminal) {
		node = terminal;
		children = new SkillComposite[0];
	}
	
	public void Use(GameObject g, SkillSheet sheet) {
		SkillEffect se = g.AddComponent<SkillEffect>();
	}
}