using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	
	private SkillSheet sheet;
	private SkillComposite[] composites;
	
	void Awake () {
		sheet = new SkillSheet(null);
		composites = new SkillComposite[1];
	}
	
	void Start () {
		composites[0] = new SkillComposite(SkillManager.GetSkill(0));
		composites[0].Use(gameObject, sheet);
	}
	
	void Update () {
	}
}