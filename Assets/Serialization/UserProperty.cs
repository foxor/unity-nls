using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

public class UserProperty : MonoBehaviour {
	
	private static Encoding enc = Encoding.Unicode;
	private static UserProperty singleton;
	
	public string defaultUserState;
	public string resourceName;
	public bool alwaysWipe;
	
	private XmlNode data;
	
	public void Awake() {
		singleton = this;
		if (alwaysWipe || PlayerPrefs.GetString(resourceName) == "") {
			Wipe();
		}
		Load();
	}
	
	public static void Load() {
		singleton.data = enc.GetBytes(PlayerPrefs.GetString(singleton.resourceName)).GetXml();
	}
	
	public static void Wipe() {
		singleton.data = (Resources.Load(singleton.defaultUserState) as TextAsset).GetXml();
		Save();
	}
	
	public static void Save() {
		MemoryStream ms = new MemoryStream();
		singleton.data.OwnerDocument.Save(ms);
		PlayerPrefs.SetString(singleton.resourceName, enc.GetString(ms.GetBuffer()));
		ms.Close();
	}
	
	public static string GetProp(string propName) {
		return GetPropNode(propName).GetString();
	}

	public static XmlNode GetPropNode(string propName) {
		return singleton.data.Child(propName);
	}

	public static void setProp(string propName, string val) {
		XmlNode root = singleton.data.OwnerDocument.DocumentElement;
		foreach (XmlNode toRemove in root.Children(propName).ToArray()) {
			root.RemoveChild(toRemove);
		}
		root.CreateChild(propName).SetAttribute(XmlUtilities.DATA, val);
		Save();
	}
	
	public static XmlNode AddProp(string propName) {
		XmlNode xn = singleton.data.OwnerDocument.DocumentElement.CreateChild(propName);
		Save();
		return xn;
	}
}