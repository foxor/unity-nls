using UnityEngine;
using System.Collections;
using System.Linq;

public class SkillManager : MonoBehaviour {
	
	public string resourceName;
	
	private Skill[] skills;
	
	void Start () {
		TextAsset ta = Resources.Load(resourceName, typeof(TextAsset)) as TextAsset;
		if (ta != null) {
			skills = ta.GetXml().FindSkills().ToArray();
		}
		else {
			skills = new Skill[0];
			Debug.Log("Skills list not found");
		}
	}
}