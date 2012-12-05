using UnityEngine;
using System.Collections;

public class LevelThreshold {
	public static float xpThreshold(int level) {
		return Mathf.Pow(2f, (float)level);
	}
}