using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimulatiorTest.CommonFunc
{
    public class XmlDocHelper
    {

        private XmlDocument xmlDoc;
        public XmlElement RootElement;
        public string path;
        public XmlDocHelper()
        {
            this.xmlDoc = new XmlDocument();
        }
        private string Getstr_Enhance(string sourcestr, string char_s, int seq)
        {
            string returnValue = null;
            string tmpstr;
            tmpstr = sourcestr;
            int i, tmpos, tmpno;
            tmpno = 0;
            for (i = 0; i < seq - 1; i++)
            {
                tmpos = tmpstr.IndexOf(char_s);
                if (tmpos != -1)
                {
                    tmpstr = tmpstr.Remove(0, tmpos + 1);
                    tmpno++;
                }

            }
            if (seq > tmpno + 1)
            {
                returnValue = "";
            }
            else
            {
                tmpos = tmpstr.IndexOf(char_s);
                if (tmpos != -1)
                {
                    returnValue = tmpstr.Substring(0, tmpos);

                }
                else
                {
                    returnValue = tmpstr;
                }
            }

            return returnValue;
        }

        private int symbolCount(string valueStr, string symcolStr)
        {
            int count = 0;
            int i;
            for (i = 0; i < valueStr.Length; i++)
            {
                if (valueStr[i].ToString() == symcolStr)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ReadFromFile(string FileName)
        {
            this.path = FileName;
            try
            {
                if (!string.IsNullOrEmpty(FileName) && File.Exists(FileName))
                {
                    this.xmlDoc.Load(FileName);
                    RootElement = this.xmlDoc.DocumentElement;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ReadFromString(string xmlStr)
        {
            try
            {
                this.xmlDoc.LoadXml(xmlStr);
                RootElement = this.xmlDoc.DocumentElement;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CreatXmlDoc(string rootName, string Encode)
        {
            try
            {
                XmlDeclaration xmldecl;
                XmlElement xmlelem;
                xmldecl = this.xmlDoc.CreateXmlDeclaration("1.0", Encode, null);
                this.xmlDoc.AppendChild(xmldecl);
                xmlelem = this.xmlDoc.CreateElement("", rootName, "");
                this.xmlDoc.AppendChild(xmlelem);
                RootElement = this.xmlDoc.DocumentElement;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string getXmlNodeValue(XmlNode curNode, string NodeStr, object defaultValue)
        {
            XmlNode gNode;
            gNode = getXmlDocNode(curNode, NodeStr);
            return gNode == null ? defaultValue.ToString() : gNode.InnerText;

        }
        public XmlNode getXmlDocNode(XmlNode curNode, string NodeStr)
        {
            XmlNode findNode = null;
            if (curNode != null)
            {
                findNode = curNode;
            }
            else
            {
                findNode = this.xmlDoc.DocumentElement;
            }
            try
            {
                int cirNum = symbolCount(NodeStr, ",") + 1;
                int i;
                string tmpstr = "";
                for (i = 1; i <= cirNum; i++)
                {
                    tmpstr = Getstr_Enhance(NodeStr, ",", i);
                    findNode = findNode.SelectSingleNode(tmpstr);

                }
            }
            catch (System.Exception)
            {
                findNode = null;
            }
            return findNode;

        }

        public XmlNode findChildXmlNode(XmlNode parentNode, string childNodeName, string childNodeValue)
        {
            int i;
            XmlNode findXmlNode = null;
            for (i = 0; i < parentNode.ChildNodes.Count; i++)
            {
                if (getXmlNodeValue(parentNode.ChildNodes[i], childNodeName, "") == childNodeValue)
                {
                    findXmlNode = parentNode.ChildNodes[i];
                }
            }
            return findXmlNode;
        }
        //Fengtc 2017.03.01 新增
        public XmlNode findChildXmlNodeByAttribute(XmlNode parentNode, string childNodeName, string attributeName, string attributeValue)
        {
            int i;
            XmlNode findXmlNode = null;
            for (i = 0; i < parentNode.ChildNodes.Count; i++)
            {
                if (parentNode.ChildNodes[i].Name == childNodeName
                    && getNodeAttribute(parentNode.ChildNodes[i], attributeName, "") == attributeValue)
                {
                    findXmlNode = parentNode.ChildNodes[i];
                    break;
                }
            }
            return findXmlNode;
        }


        public XmlNodeList getXmlDocNodeList(XmlNode curNode, string NodeStr)
        {
            XmlNode findNode = null;
            XmlNodeList findNodeList = null;
            if (curNode != null)
            {
                findNode = curNode;
            }
            else
            {
                findNode = this.xmlDoc.DocumentElement;
            }

            int cirNum = symbolCount(NodeStr, ",") + 1;
            int i;
            string tmpstr = "";
            for (i = 1; i <= cirNum; i++)
            {
                tmpstr = Getstr_Enhance(NodeStr, ",", i);
                if (i == cirNum)
                {
                    findNodeList = findNode.SelectNodes(tmpstr);
                }
                else
                {
                    findNode = findNode.SelectSingleNode(tmpstr);

                }


            }
            return findNodeList;

        }

        public string WriteToString()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw);
            writer.Indentation = 2;  // the Indentation
            writer.Formatting = System.Xml.Formatting.Indented;
            this.xmlDoc.WriteContentTo(writer);
            writer.Close();
            return sw.ToString();

        }
        public XmlNode CreateXmlNode(string NodeName, object NodeValue)
        {
            XmlNode cNode = this.xmlDoc.CreateNode(XmlNodeType.Element, NodeName, "");
            cNode.InnerText = NodeValue == null ? null : NodeValue.ToString();
            return cNode;
        }
        public void SaveToFile(string filePath)
        {
            this.xmlDoc.Save(filePath);

        }
        //Fengtc 2017.03.01 新增
        public void SaveToFile()
        {
            this.xmlDoc.Save(this.path);

        }

        public void AddXmlNode(XmlNode rNode, string NodeName, object NodeValue)
        {
            XmlNode cNode = this.xmlDoc.CreateNode(XmlNodeType.Element, NodeName, "");
            cNode.InnerText = NodeValue == null ? null : NodeValue.ToString();
            rNode.AppendChild(cNode);
        }

        public XmlAttribute CreateAttribute(string AttributeName, string AttributeVlaue)
        {
            XmlAttribute xmlAtt = this.xmlDoc.CreateAttribute(AttributeName);
            xmlAtt.InnerText = AttributeVlaue;
            return xmlAtt;

        }

        public void XmlNodeAddAttribute(XmlNode xmlNode, string AttributeName, string AttributeVlaue)
        {
            XmlAttribute xmlAtt = this.xmlDoc.CreateAttribute(AttributeName);
            xmlAtt.InnerText = AttributeVlaue;
            xmlNode.Attributes.Append(xmlAtt);

        }

        public string getNodeAttribute(XmlNode xmlNode, string AttributeName, string defaultValue)
        {
            XmlAttribute xmlAtt = xmlNode.Attributes[AttributeName];
            if (xmlAtt != null)
            {
                return xmlAtt.Value;
            }
            else
            {
                return defaultValue;

            }

        }
        public XmlNode getChildXmlNodeByAttribute(XmlNode curNode, string NodeStr, string attributeName, string attributeValue)
        {
            XmlNode findNode = null;
            if (curNode != null)
            {
                findNode = curNode;
            }
            else
            {
                findNode = this.xmlDoc.DocumentElement;
            }

            XmlNode tmpAttFingNode = null;
            foreach (XmlNode tmpNode in findNode.ChildNodes)
            {
                if (tmpNode.Name == NodeStr
                    && getNodeAttribute(tmpNode, attributeName, "") == attributeValue)
                {
                    tmpAttFingNode = tmpNode;
                    break;
                }
            }
            return tmpAttFingNode;

        }


        public void DeleteChildXmlDocNode(XmlNode curNode, string NodeStr)
        {
            XmlNode findNode = null;
            if (curNode != null)
            {
                findNode = curNode;
            }
            else
            {
                findNode = this.xmlDoc.DocumentElement;
            }
            foreach (XmlNode tmpNode in findNode.ChildNodes)
            {
                if (tmpNode.Name == NodeStr)
                {
                    findNode.RemoveChild(tmpNode);
                }
            }


        }
    }

}
