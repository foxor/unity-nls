using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

public static class XmlUtilities {
	public const string DATA = "data";
	
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
	
	public static XmlNode Child(this XmlNode xn, string tag) {
		return xn.SelectSingleNode(tag);
	}
	
	public static IEnumerable<T> Map<T>(this IEnumerable<XmlNode> xns, Func<XmlNode, T> f) {
		return xns.Select<XmlNode, T>(f);
	}
	
	public static XmlNode FindById(this XmlNode xn, string id) {
		return xn.OwnerDocument.SelectSingleNode(string.Format("//*[@id='{0}']", id));
	}
	
	public static XmlNode CreateChild(this XmlNode xn, string tagName) {
		XmlNode x = xn.OwnerDocument.CreateNode(XmlNodeType.Element, tagName, "");
		xn.AppendChild(x);
		return x;
	}
	
	public static void SetAttribute(this XmlNode xn, string attribute, string val) {
		XmlAttribute xa = xn.OwnerDocument.CreateAttribute(attribute);
		xa.Value = val;
		xn.Attributes.Append(xa);
	}
}