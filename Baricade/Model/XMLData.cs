using System;
using System.IO;
using System.Xml;


namespace Baricade.Model
{
    // Generic XML data type to wrap any object
    // All Properties will be imported/exported to XML-data

    public class XmlData<T>  // We use REFLECTION to find T's properties
    {
        public bool readElement(XmlReader f)
        {
            if (f.IsStartElement())
            {
                Type t = typeof(T);
                if (f.NodeType == XmlNodeType.Element)
                {
                    foreach (System.Reflection.PropertyInfo prop in t.GetProperties())
                    {

                        String value = f.GetAttribute(prop.Name.ToLower());
                        int i;
                        if (int.TryParse(value, out i))
                        {
                            prop.SetValue(this, i, null);
                        }
                        else
                        {
                            prop.SetValue(this, value, null);
                        }

                    }
                    return true;
                }
            }
            return false;
        }

        public void writeElement(TextWriter tw)
        {
            Type t = typeof(T);
            tw.WriteLine("<" + t.Name.ToLower());
            foreach (System.Reflection.PropertyInfo prop in t.GetProperties())
                tw.WriteLine("\t" + prop.Name.ToLower() + "=\"" + prop.GetValue(this, null) + "\"");
            tw.WriteLine("/>");
        }
    }
}

