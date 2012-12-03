using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

public static class XmlUtilities {
	public static XmlNode GetXml(this byte[] bytes) {
		XmlDocument xmlDoc = new XmlDocument();
		MemoryStream ms = new MemoryStream(bytes);
		xmlDoc.Load(ms);
		ms.Close();
		return xmlDoc.DocumentElement as XmlNode;
	}
	
	public static XmlNode GetXml(this TextAsset text) {
		return text.bytes.GetXml();
	}
	
	public static IEnumerable<XmlNode> Children(this XmlNode xn, string tag) {
		return xn.SelectNodes(tag).Cast<XmlNode>();
	}
	
	public static IEnumerable<T> Map<T>(this IEnumerable<XmlNode> xns, Func<XmlNode, T> f) {
		return xns.Select<XmlNode, T>(f);
	}
}