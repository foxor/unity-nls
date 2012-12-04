using UnityEngine;
using System.Collections;
using System.Xml;

public static class BoolData {
	public static bool GetBool(this XmlNode xn) {
		return xn != null;
	}
}