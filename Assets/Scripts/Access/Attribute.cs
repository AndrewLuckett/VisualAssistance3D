
[System.Serializable]
public struct Attribute {
    public Attribute(string name, string value) {
        attrib_name = name;
        attrib_value = value;
    }
    public string attrib_name;
    public string attrib_value;
}