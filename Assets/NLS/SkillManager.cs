using UnityEngine;
using System.Collections;
using System.Linq;

public class SkillManager : MonoBehaviour {
	
	private static SkillManager singleton;
	
	public string resourceName;
	
	private Skill[] skills;
	
	void Awake () {
		singleton = this;
		TextAsset ta = Resources.Load(resourceName, typeof(TextAsset)) as TextAsset;
		if (ta != null) {
			skills = ta.GetXml().FindSkills().ToArray();
		}
		else {
			skills = new Skill[0];
			Debug.Log("Skills list not found");
		}
	}
	
	public static Skill GetSkill(int skillId) {
		return singleton.skills[skillId];
	}
}