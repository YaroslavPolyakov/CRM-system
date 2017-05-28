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
using CRM;
using CRM.BD;

namespace XMLE
{
    class XML
    {
        private static string filepath;
        static public XElement getXElement(object obj)
        {

            if (obj is CRM.BD.Clients)
            {
                CRM.BD.Clients ctmp = (CRM.BD.Clients)obj;
                XElement client = new XElement("Client");
                client.Add(new XElement("Название", ctmp.Name));
                client.Add(new XElement("Адрес", ctmp.Address));
                client.Add(new XElement("Телефон", ctmp.Phone));
                client.Add(new XElement("E_mail", ctmp.Email));
                client.Add(new XElement("Расчетный_счёт", ctmp.CheckingAccount));
                client.Add(new XElement("Банк", ctmp.Bank));
                client.Add(new XElement("Директор", ctmp.Director));
                client.Add(new XElement("Бухгалтер", ctmp.Accountant));
                client.Add(new XElement("Информация", ctmp.Info));
                return client;
            }
            if (obj is CRM.BD.Managers)
            {
                CRM.BD.Managers mtmp = (CRM.BD.Managers)obj;
                XElement manager = new XElement("Manager");
                manager.Add(new XElement("ФИО", mtmp.Name));
                manager.Add(new XElement("Логин", mtmp.Login));
                manager.Add(new XElement("Пароль", mtmp.Password));
                manager.Add(new XElement("Должность", mtmp.Position));
                manager.Add(new XElement("Группа", mtmp.Group));
                manager.Add(new XElement("Адрес", mtmp.Address));
                manager.Add(new XElement("Телефон", mtmp.Phone));
                manager.Add(new XElement("Пасспорт", mtmp.Passport));
                manager.Add(new XElement("Дата_рождения", mtmp.DateOfBirth));
                manager.Add(new XElement("Дата_приема_на_работу", mtmp.DateRecruitment));
                manager.Add(new XElement("E_mail", mtmp.Email));
                if (mtmp.Info != null) manager.Add(new XElement("Информация", mtmp.Info));
                else manager.Add(new XElement("Информация", ""));
                return manager;
            }
            if (obj is CRM.BD.Tasks)
            {
                CRM.BD.Tasks ttmp = (CRM.BD.Tasks)obj;
                XElement task = new XElement("Task");
                task.Add(new XElement("ID", ttmp.Id));
                task.Add(new XElement("Заказчик", ttmp.Client));
                task.Add(new XElement("Исполнитель", ttmp.Manager));
                task.Add(new XElement("Задача", ttmp.Task));
                task.Add(new XElement("Информация", ttmp.Info));
                task.Add(new XElement("Дата_начала", ttmp.DateStart));
                task.Add(new XElement("Дата_завершения", ttmp.DateComplete));
                task.Add(new XElement("Статус", ttmp.Status));
                return task;
            }
            return null;
        }

        static public void Save_Clients(List<CRM.BD.Clients> client)
        {
            XDocument xdoc = new XDocument();
            XElement xmain = new XElement("Client");
            foreach (CRM.BD.Clients tmp in client)
            {
                xmain.Add(XML.getXElement(tmp));
            }
            xdoc.Add(xmain);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"h:\Univer\Учеба\Курсач";
            sfd.Filter = "Файлы xml |*.xml";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            xdoc.Save(sfd.FileName);
        }
        static public void Save_Managers(List<CRM.BD.Managers> manager)
        {
            XDocument xdoc = new XDocument();
            XElement xmain = new XElement("Manager");
            foreach (CRM.BD.Managers tmp in manager)
            {
                if(tmp.Name!="Харсеко Никита Игоревич") xmain.Add(XML.getXElement(tmp));
            }
            xdoc.Add(xmain);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"h:\Univer\Учеба\Курсач";
            sfd.Filter = "Файлы xml |*.xml";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            xdoc.Save(sfd.FileName);
        }
        static public void Save_Tasks(List<CRM.BD.Tasks> task)
        {
            XDocument xdoc = new XDocument();
            XElement xmain = new XElement("Task");
            foreach (CRM.BD.Tasks tmp in task)
            {
                xmain.Add(XML.getXElement(tmp));
            }
            xdoc.Add(xmain);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"h:\Univer\Учеба\Курсач";
            sfd.Filter = "Файлы xml |*.xml";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            xdoc.Save(sfd.FileName);
        }

        static public void openXml_clients()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"h:\Univer\Учеба\Курсач";
            ofd.Filter = "Файлы xml |*.xml";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            filepath = ofd.FileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList nodes = doc.ChildNodes;

            CRM.BD.Clients client;

            foreach (XmlNode n in nodes)
            {

                if ("Client".Equals(n.Name))
                {

                    for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                    {
                        if ("Client".Equals(d.Name))
                        {
                            client = new CRM.BD.Clients();

                            for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                            {
                                if ("Название".Equals(k.Name))
                                {
                                    client.Name = (k.FirstChild.Value);
                                }
                                else if ("Адрес".Equals(k.Name))
                                {
                                    client.Address = k.FirstChild.Value;
                                }
                                else if ("Телефон".Equals(k.Name))
                                {
                                    client.Phone = k.FirstChild.Value;
                                }
                                else if ("E_mail".Equals(k.Name))
                                {
                                    client.Email = k.FirstChild.Value;
                                }
                                else if ("Расчетный_счёт".Equals(k.Name))
                                {
                                    client.CheckingAccount = k.FirstChild.Value;
                                }
                                else if ("Банк".Equals(k.Name))
                                {
                                    client.Bank = k.FirstChild.Value;
                                }
                                else if ("Директор".Equals(k.Name))
                                {
                                    client.Director = k.FirstChild.Value;
                                }
                                else if ("Бухгалтер".Equals(k.Name))
                                {
                                    client.Accountant = k.FirstChild.Value;
                                }
                                else if ("Информация".Equals(k.Name))
                                {
                                    client.Info = k.FirstChild.Value;
                                }
                            }
                            using (CRMContext dbContext = new CRMContext())
                            {
                                try
                                {
                                    dbContext.Clients.Add(client);
                                    dbContext.SaveChanges();
                                }
                                catch (Exception ee)
                                {
                                    MessageBox.Show("Ошибка!" + ee.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
        static public void openXml_tasks()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"h:\Univer\Учеба\Курсач";
            ofd.Filter = "Файлы xml |*.xml";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            filepath = ofd.FileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList nodes = doc.ChildNodes;

            CRM.BD.Tasks task;

            foreach (XmlNode n in nodes)
            {

                if ("Task".Equals(n.Name))
                {

                    for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                    {
                        if ("Task".Equals(d.Name))
                        {
                            task = new CRM.BD.Tasks();

                            for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                            {
                                if ("ID".Equals(k.Name))
                                {
                                    task.Id = Convert.ToInt16(k.FirstChild.Value);
                                }
                                else if ("Заказчик".Equals(k.Name))
                                {
                                    task.Client = k.FirstChild.Value;
                                }
                                else if ("Исполнитель".Equals(k.Name))
                                {
                                    task.Manager = k.FirstChild.Value;
                                }
                                else if ("Задача".Equals(k.Name))
                                {
                                    task.Task = k.FirstChild.Value;
                                }
                                else if ("Информация".Equals(k.Name))
                                {
                                    task.Info = k.FirstChild.Value;
                                }
                                else if ("Дата_начала".Equals(k.Name))
                                {
                                    task.DateStart = Convert.ToDateTime(k.FirstChild.Value);
                                }
                                else if ("Дата_завершения".Equals(k.Name))
                                {
                                    task.DateComplete = Convert.ToDateTime(k.FirstChild.Value);
                                }
                                else if ("Статус".Equals(k.Name))
                                {
                                    task.Status = Convert.ToInt32(k.FirstChild.Value);
                                }
                            }
                            using (CRMContext dbContext = new CRMContext())
                            {
                                try
                                {
                                    dbContext.Tasks.Add(task);
                                    dbContext.SaveChanges();
                                }
                                catch (Exception ee)
                                {
                                    MessageBox.Show("Ошибка!" + ee.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
        static public void openXml_managers()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"h:\Univer\Учеба\Курсач";
            ofd.Filter = "Файлы xml |*.xml";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            filepath = ofd.FileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList nodes = doc.ChildNodes;

            CRM.BD.Managers manager;

            foreach (XmlNode n in nodes)
            {

                if ("Manager".Equals(n.Name))
                {

                    for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                    {
                        if ("Manager".Equals(d.Name))
                        {
                            manager = new CRM.BD.Managers();

                            for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                            { 
                                
                                if ("ФИО".Equals(k.Name))
                                {
                                    manager.Name = k.FirstChild.Value;
                                }
                                else if ("Логин".Equals(k.Name))
                                {
                                    manager.Login = k.FirstChild.Value;
                                }
                                else if ("Должность".Equals(k.Name))
                                {
                                    manager.Position = k.FirstChild.Value;
                                }
                                else if ("Группа".Equals(k.Name))
                                {
                                    manager.Group = Convert.ToInt32(k.FirstChild.Value);
                                }
                                else if ("Адрес".Equals(k.Name))
                                {
                                    manager.Address = k.FirstChild.Value;
                                }
                                else if ("Телефон".Equals(k.Name))
                                {
                                    manager.Phone = k.FirstChild.Value;
                                }
                                else if ("Пасспорт".Equals(k.Name))
                                {
                                    manager.Passport = k.FirstChild.Value;
                                }
                                else if ("Пароль".Equals(k.Name))
                                {
                                    manager.Password = Hash.EncryptPassword(manager.Login, "1111");
                                    //manager.Password = Encoding.Default.GetBytes(k.FirstChild.Value);
                                }
                                else if ("Дата_рождения".Equals(k.Name))
                                {
                                    manager.DateOfBirth = Convert.ToDateTime(k.FirstChild.Value);
                                }
                                else if ("Дата_приема_на_работу".Equals(k.Name))
                                {
                                    manager.DateRecruitment = Convert.ToDateTime(k.FirstChild.Value);
                                }
                                else if ("E_mail".Equals(k.Name))
                                {
                                    manager.Email = k.FirstChild.Value;
                                }
                                else if ("Информация".Equals(k.Name))
                                {
                                    manager.Info = k.FirstChild.Value;
                                }
                            }
                            using (CRMContext dbContext = new CRMContext())
                            {
                                try
                                {
                                    dbContext.Managers.Add(manager);
                                    dbContext.SaveChanges();
                                }
                                catch (Exception ee)
                                {
                                    MessageBox.Show("Ошибка!" + ee.Message);
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}

