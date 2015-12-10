using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("SpokenLineCollection")]
public class SpokenLineContainer
{
    [XmlArray("SpokenLines")]
    [XmlArrayItem("SpokenLine")]
    public List<SpokenLine> spokenLines = new List<SpokenLine>();

    public static SpokenLineContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(SpokenLineContainer));

        StringReader reader = new StringReader(_xml.text);

        SpokenLineContainer spokenLines = serializer.Deserialize(reader) as SpokenLineContainer;

        reader.Close();

        return spokenLines;
    }
}
