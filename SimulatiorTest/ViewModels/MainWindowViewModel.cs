using ReactiveUI;
using SimulatiorTest.CommonFunc;
using SimulatiorTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimulatiorTest.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            InitCmdConfig();
        }

        private void InitCmdConfig()
        {
            string xmldocPath;
            XmlDocHelper tmpxmldoc;
            xmldocPath = @"D:\test1.xml";
            tmpxmldoc = new XmlDocHelper();
            tmpxmldoc.ReadFromFile(xmldocPath);
            XmlNode parameterSettingsListNode = tmpxmldoc.getXmlDocNode(tmpxmldoc.RootElement, "Cmd");
            if (parameterSettingsListNode == null)
            {
                return;
            }
            CmdModel cmdModel = new CmdModel();
            string cmdCode = tmpxmldoc.getNodeAttribute(parameterSettingsListNode, "CmdCode", "");
            var response = tmpxmldoc.getXmlNodeValue(parameterSettingsListNode, "IsResponse", "");
            XmlNode itemListNode = tmpxmldoc.getXmlDocNode(parameterSettingsListNode, "ResponseCmdList");
            cmdModel.CmdCode = Convert.ToInt32(cmdCode,16);
            cmdModel.IsResponse = response=="1";
            foreach (XmlNode tmpItemNode in itemListNode.ChildNodes)
            {
                ResponseCmd responseCmd = new ResponseCmd();
                var ResCmdCode = tmpxmldoc.getXmlNodeValue(tmpItemNode, "ResCmdCode", "");
                XmlNode paramListNode = tmpxmldoc.getXmlDocNode(tmpItemNode, "Parameters");

                responseCmd.ResCmdCode = Convert.ToInt32(ResCmdCode,16);

                foreach (XmlNode paramNode in paramListNode.ChildNodes)
                {
                    CmdParameter cmdParameter = new CmdParameter();
                    string paramName = tmpxmldoc.getXmlNodeValue(paramNode, "ParamName", "");
                    string paramDes = tmpxmldoc.getXmlNodeValue(paramNode, "ParamDes", "");
                    string ParamValue = tmpxmldoc.getXmlNodeValue(paramNode, "ParamValue", "");
                    cmdParameter.ParamName = paramName;
                    cmdParameter.ParamDes = paramDes;
                    cmdParameter.ParamValue = ParamValue;
                    responseCmd.Parameters.Add(cmdParameter);
                }
                cmdModel.ResponseCmdList.Add(responseCmd);
            }  
        }
    }
}
