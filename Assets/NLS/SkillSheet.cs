using UnityEngine;
using System.Collections;
using System.Xml;

public class SkillSheet {
	private XmlNode data;
	
	public SkillSheet(XmlNode data) {
		this.data = data;
	}
	
	public int this[int skillId] {
		get {
			return 1;
		}
	}
	
	public void recordUse(int skillId, float xp) {
	}
}