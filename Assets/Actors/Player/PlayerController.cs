using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Actor actor;
	void Awake () {
		actor = gameObject.GetComponent<Actor>();
	}
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			actor.ActivateSkill(0);
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