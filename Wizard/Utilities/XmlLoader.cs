using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Wizard.Utilities
{
    public class XmlLoader
    {
        public XmlDocument XmlDocument { get; private set; }

        private XmlDocument CreateEmptyXmlDocument()
        {
            //  Return an empty XmlDocument if the open file window was closed
            XmlDocument emptyMyStream = new XmlDocument();
            return emptyMyStream;
        }

        public XmlDocument OpenXml()
        {
            using (var openFileDialogXML = new OpenFileDialog())
            {
                openFileDialogXML.InitialDirectory = "C:\\";
                openFileDialogXML.Filter = "XML Files|*.xml";
                openFileDialogXML.RestoreDirectory = true;

                if (openFileDialogXML.ShowDialog() == DialogResult.Cancel)
                {
                    return CreateEmptyXmlDocument();
                }

                //  The stream will hold the results of opening the XML
                using (var myStream = openFileDialogXML.OpenFile())
                {
                    try
                    {
                        //  Successfully return the XML
                        XmlDocument parsedMyStream = new XmlDocument();
                        parsedMyStream.Load(myStream);
                        return parsedMyStream;
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show("The XML could not be read. " + ex);
                        return CreateEmptyXmlDocument();
                    }
                }
            }
        }

        public XDocument OpenXmlReturnsXDoc(string filePath)
        {
            //using (var openFileDialogXML = new OpenFileDialog())
            //{
            //    openFileDialogXML.InitialDirectory = "C:\\";
            //    openFileDialogXML.Filter = "XML Files|*.xml";
            //    openFileDialogXML.RestoreDirectory = true;

                //if (openFileDialogXML.ShowDialog() == DialogResult.Cancel)
                //{
                //    return null;
                //}
                
               

                var myStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                //  The stream will hold the results of opening the XML
                //using (var myStream = openFileDialogXML.OpenFile())
                //{
                    try
                    {
                        //  Successfully return the XML
                        XmlDocument parsedMyStream = new XmlDocument();
                        parsedMyStream.Load(myStream);
                        var s = parsedMyStream.InnerXml;
                        return XDocument.Parse(s);
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show("The XML could not be read. " + ex);
                        return null;
                    }
                //}
            //}
        }
        
        public void LoadXML_Window(object sender, System.EventArgs e)
        {
            XmlDocument = OpenXml();
        }
    }
}
