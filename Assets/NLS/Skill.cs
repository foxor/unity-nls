using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class Skill {
	private XmlNode data;
	
	public Skill(XmlNode data) {
		this.data = data;
	}
}

public static class SkillHelpers {
	private const string SKILL = "skill";
	
	public static IEnumerable<Skill> FindSkills(this XmlNode xn) {
		return xn.Children(SKILL).Map<Skill>(x => new Skill(x));
	}
}