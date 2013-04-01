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
                        bool b;
                        if (int.TryParse(value, out i))
                        {
                            if (i != 0)
                            {
                                prop.SetValue(this, i, null);
                            }
                        }
                        else if (bool.TryParse(value, out b))
                        {
                            prop.SetValue(this, b, null);
                        }
                        else if (PlayerColor.Blue.ToString() == value)
                        {
                            prop.SetValue(this, PlayerColor.Blue, null);
                        }
                        else if (PlayerColor.Green.ToString() == value)
                        {
                            prop.SetValue(this, PlayerColor.Green, null);
                        }
                        else if (PlayerColor.Red.ToString() == value)
                        {
                            prop.SetValue(this, PlayerColor.Red, null);
                        }
                        else if (PlayerColor.Yellow.ToString() == value)
                        {
                            prop.SetValue(this, PlayerColor.Yellow, null);
                        }
                        else
                        {
                            if (value != null)
                            {
                                prop.SetValue(this, value, null);
                            }
                        }

                    }
                    return true;
                }
            }
            return false;
        }

        public void writeElement(TextWriter tw)
        {
            Type t = this.GetType();
            tw.Write("<" + t.Name.ToLower());
            foreach (System.Reflection.PropertyInfo prop in t.GetProperties())
                tw.Write(" " + prop.Name.ToLower() + "=\"" + prop.GetValue(this, null) + "\"");
            tw.WriteLine("/>");
        }
    }
}

