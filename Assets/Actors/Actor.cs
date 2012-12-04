using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	
	private SkillSheet sheet;
	private SkillPlan[] plans;
	
	void Awake () {
		sheet = new SkillSheet(null);
	}
	
	void Start () {
		SkillPlanTest spt = new SkillPlanTest(gameObject, sheet);
		spt.Use();
	}
	
	void Update () {
	}
}