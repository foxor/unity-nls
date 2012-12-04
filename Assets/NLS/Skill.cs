using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class Skill {
	private const string ID = "id";
	private const string NAME = "name";
	private const string PROJECTILE = "projectile";
	
	private XmlNode data;
	
	public Skill(XmlNode data) {
		this.data = data;
		name = data.Child(NAME).GetString();
		id = data.Child(ID).GetInt();
		projectile = data.Child(PROJECTILE).GetBool();
	}
	
	private string name;
	public string Name {
		get {
			return name;
		}
	}
	
	private int id;
	public int Id {
		get {
			return id;
		}
	}
	
	private bool projectile;
	public bool Projectile {
		get {
			return projectile;
		}
	}
}

public static class SkillHelpers {
	private const string SKILL = "skill";
	private const string SKILL_ID = "skillId";
	
	private static Skill processNode(XmlNode xn) {
		if (xn.Attributes[SKILL_ID] != null) {
			return SkillManager.GetSkill(int.Parse(xn.GetAttribute(SKILL_ID)));
		}
		return new Skill(xn);
	}
	
	public static IEnumerable<Skill> FindSkills(this XmlNode xn) {
		return xn.Children(SKILL).Map<Skill>(processNode);
	}
}