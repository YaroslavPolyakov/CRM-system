using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using CRM.BD;

namespace XMLE
{
    class XML
    {
        static public XElement getXElement(Clients tmp)
        {
            XElement xsubj = new XElement("clients");

            xsubj.Add(new XAttribute("name", tmp.Name));
            xsubj.Add(new XElement("address", tmp.Address));
            xsubj.Add(new XElement("phone", tmp.Phone));
            xsubj.Add(new XElement("email", tmp.Email));
            xsubj.Add(new XElement("checkingaccount", tmp.CheckingAccount));
            xsubj.Add(new XElement("bank", tmp.Bank));
            xsubj.Add(new XElement("director", tmp.Director));
            xsubj.Add(new XElement("accountant", tmp.Accountant));
            xsubj.Add(new XElement("info", tmp.Info));
            return xsubj;
        }
        static public Clients getSubject(XElement tmp)
        {
            Clients client = null;

            try
            {
                client = new Clients();

                client.Name = tmp.Attribute("name").Value;
                client.Address = tmp.Element("address").Value;
                client.Phone = tmp.Element("phone").Value;
                client.Email = tmp.Element("email").Value;
                client.CheckingAccount = tmp.Element("checkingaccount").Value;
                client.Bank = tmp.Element("bank").Value;
                client.Director = tmp.Element("director").Value;
                client.Accountant = tmp.Element("accountant").Value;
                client.Info = tmp.Element("info").Value;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            return client;

        }

        static public void saveToXml(List <Clients> client)
        {
            XDocument xdoc = new XDocument();
            XElement xmain = new XElement("client");

            foreach (Clients tmp in client)
            {
                xmain.Add(XML.getXElement(tmp));
            }

            xdoc.Add(xmain);

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = @"h:\Univer\Учеба";
            sfd.Filter = "Файлы xml |*.xml";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            xdoc.Save(sfd.FileName);
        }

    }
}
