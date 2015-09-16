using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class SpokenLine 
{
    [XmlAttribute("ID")]
    public int ID;

    [XmlElement("Speaker")]
    public Character Speaker;

    [XmlElement("Text")]
    public string Text;

    [XmlElement("DialogueType")]
    public DialogueType DialogueType;

    [XmlElement("AudioId")]
    public int AudioId;

    [XmlElement("Notes")]
    public string Notes;
}
