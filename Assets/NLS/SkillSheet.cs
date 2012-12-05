using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class SkillSheet {
	
	private const string SAVE = "save";
	
	private class Level {
		private const string LEVEL = "level";
		private const string XP = "xp";
		
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
			set {
				data.SetString(value.ToString());
				level = value;
			}
		}
		
		private float xp;
		public float Xp {
			get {
				return xp;
			}
			set {
				XmlNode xpNode = data.Child(XP);
				xpNode.SetString(value.ToString());
				xp = value;
			}
		}
		
		public Level(XmlNode data) {
			this.data = data;
			target = data.FindSkills().First();
			level = data.GetInt();
			xp = data.Child(XP).GetFloat();
		}
		
		public static IEnumerable<Level> FindLevels(XmlNode xn) {
			return xn.Children(LEVEL).Map<Level>(x => new Level(x));
		}
	}
	
	private Dictionary<int, Level> sheetData;
	private bool toSave;
	private XmlNode data;
	
	public SkillSheet(XmlNode data) {
		this.data = data;
		toSave = data.Child(SAVE).GetBool();
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
		if (!toSave) {
			return;
		}
		Level l = sheetData[skillId];
		l.Xp += xp;
		float threshold;
		while (l.Xp >= (threshold = LevelThreshold.xpThreshold(l.SkillLevel))) {
			l.Xp -= threshold;
			l.SkillLevel += 1;
		}
		UserProperty.SetPropNode(data.ParentNode, data);
	}
}

public static class SkillSheetUtils {
	private const string SKILL_SHEET = "skillSheet";
	public static SkillSheet FindSkillSheet(this XmlNode xn) {
		return new SkillSheet(xn.Child(SKILL_SHEET));
	}
}