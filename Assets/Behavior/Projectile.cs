using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public static GameObject Launch(Transform origin, Vector3 velocity, string prefabName) {
		GameObject projectile = GameObject.Instantiate(Resources.Load(prefabName)) as GameObject;
		projectile.transform.position = origin.position + velocity.normalized;
		projectile.rigidbody.velocity = velocity;
		Destroy(projectile, 10f);
		return projectile;
	}
}