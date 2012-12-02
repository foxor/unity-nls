using UnityEngine;
using System.Collections;

public class Preserve : MonoBehaviour {
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}