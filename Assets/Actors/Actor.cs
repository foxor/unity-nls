using UnityEngine;
using System.Collections;
using System.Linq;
using System.Xml;

public abstract class Actor : MonoBehaviour { 
	
	private XmlNode data;
	
	public SkillSheet sheet;
	public SkillPlan[] plans;
	
	void Start () {
		data = datasource;
		sheet = data.FindSkillSheet();
		plans = data.FindSkillPlans(this).ToArray();
	}
	
	void Update () {
	}
	
	protected abstract XmlNode datasource {
		get;
	}
	
	public void ActivateSkill(int index) {
		plans[index].Use();
	}
}