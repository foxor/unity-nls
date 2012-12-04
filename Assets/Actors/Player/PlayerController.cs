using UnityEngine;
using System.Collections;
using System.Xml;

public class PlayerController : Actor {
	private const string PLAYER = "player";
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			ActivateSkill(0);
		}
	}
	
	protected override XmlNode datasource {
		get {
			return UserProperty.GetPropNode(PLAYER);
		}
	}
}

public static class PlayerUtils {
	public static Vector3 GetSkillMouseDelta(this GameObject player) {
		Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		float cameraToClicked = (player.transform.position.y - clickRay.origin.y) / clickRay.direction.y;
		Vector3 delta = -player.transform.position + (clickRay.origin + clickRay.direction * cameraToClicked);
		delta.Normalize();
		return delta;
	}
}