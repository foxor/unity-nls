using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class SkillSheet {
	
	private class Level {
		private const string LEVEL = "level";
		
		private XmlNode data;
		
		private Skill target;
		public Skill Target {
			get {
				return target;
			}
		}
		
		private int level;
		public int SkillLevel {
			get {
				return level;
			}
		}
		
		public Level(XmlNode data) {
			this.data = data;
			target = data.FindSkills().First();
			level = data.GetInt();
		}
		
		public static IEnumerable<Level> FindLevels(XmlNode xn) {
			return xn.Children(LEVEL).Map<Level>(x => new Level(x));
		}
	}
	
	private Dictionary<int, Level> sheetData;
	
	public SkillSheet(XmlNode data) {
		sheetData = new Dictionary<int, Level>();
		foreach (Level l in Level.FindLevels(data)) {
			sheetData[l.Target.Id] = l;
		}
	}
	
	public int this[int skillId] {
		get {
			return sheetData[skillId].SkillLevel;
		}
	}
	
	public void recordUse(int skillId, float xp) {
	}
}

public static class SkillSheetUtils {
	private const string SKILL_SHEET = "skillSheet";
	public static SkillSheet FindSkillSheet(this XmlNode xn) {
		return new SkillSheet(xn.Child(SKILL_SHEET));
	}
}