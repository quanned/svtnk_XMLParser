using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace svtnk_XMLParser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            //PathEdit.Clear();
            //открытие диалога для выбора файла
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = true;
            FBD.ShowDialog();
            PathEdit.Text = FBD.SelectedPath;
            //System.Windows.MessageBox.Show(FBD.SelectedPath);

            string pathToXmls = @"J:\XML\OUT";
            string path = GetFullPathToFolder();

            string[] FilesPathArray = Directory.GetFiles(PathEdit.Text);
            for (int i = 0; i < FilesPathArray.Length; i++)
            {
                FilesLB.Items.Add(FilesPathArray[i]);
            }

            //if (path.StartsWith(pathToXmls))
            //{
            //    string[] FilesPathArray = Directory.GetFiles(PathEdit.Text);
            //    for (int i = 0; i < FilesPathArray.Length; i++)
            //    {
            //        FilesLB.Items.Add(FilesPathArray[i]);
            //    }
            //}
            //else System.Windows.MessageBox.Show("Chech path to files plese");
        }

        public string GetFullPathToFolder() //возвращает полный путь к папке
        {
            string fullPath = PathEdit.Text;
            return fullPath;
        }

        private void PathEdit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //обнуление поля, если устаногвлен дефолтный текст
            if (PathEdit.Text == "Path to file")
                PathEdit.Clear();
        }

        public void ParseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainTB.Text = "";
            //задаем путь к нашему рабочему файлу XML
            string fileName = FilesLB.SelectedItem.ToString();
            //читаем данные из файла
            XDocument doc = XDocument.Load(fileName);
            foreach (XElement el in doc.Root.Elements())
            {
                //Выводим имя элемента и значение аттрибута id
                MainTB.Text += el.Name + " \n";
                //Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
                MainTB.Text += "  Attributes:\n";
                //выводим в цикле все аттрибуты, заодно смотрим как они себя преобразуют в строку
                foreach (XAttribute attr in el.Attributes())
                    MainTB.Text += attr.Name + " : " + attr.Value + " \n";
                MainTB.Text += "  Elements:\n";
                //выводим в цикле названия всех дочерних элементов и их значения
                foreach (XElement element in el.Elements())
                    MainTB.Text += element.Name + " : " + element.Value + " \n";
            }

            #region backup
            //foreach (XElement el in doc.Root.Elements())
            //{
            //    //Выводим имя элемента и значение аттрибута id
            //    Console.WriteLine("{0}", el.Name);
            //    //Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
            //    Console.WriteLine("  Attributes:");
            //    //выводим в цикле все аттрибуты, заодно смотрим как они себя преобразуют в строку
            //    foreach (XAttribute attr in el.Attributes())
            //        Console.WriteLine("    {0}", attr);
            //    Console.WriteLine("  Elements:");
            //    //выводим в цикле названия всех дочерних элементов и их значения
            //    foreach (XElement element in el.Elements())
            //        Console.WriteLine("    {0}: {1}", element.Name, element.Value);
            //}
            #endregion

            #region testParsing
            //string currentPath = FilesLB.SelectedItem.ToString();
            //List<XMLStructure> xml = new List<XMLStructure>();

            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(currentPath);
            //XmlElement xRoot = xDoc.DocumentElement;
            //foreach (XmlElement xnode in xRoot)
            //{
            //    XMLStructure xs = new XMLStructure();
            //    XmlNode attr = xnode.Attributes.GetNamedItem("name");
            //    if (attr != null)
            //        xs.Name = attr.Value;

            //    foreach (XmlNode childnode in xnode.ChildNodes)
            //    {
            //        if (childnode.Name == "company")
            //            xs.Company = childnode.InnerText;

            //        if (childnode.Name == "age")
            //            xs.Age = Int32.Parse(childnode.InnerText);
            //    }
            //    xml.Add(xs);
            //}
            //foreach (XMLStructure u in xml)
            //    Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
            //Console.Read();
            #endregion

            #region other function
            //            //изменение данных
            //            //Получаем первый дочерний узел из library
            //            XNode node = doc.Root.FirstNode;
            //            while (node != null)
            //            {
            //                //проверяем, что текущий узел - это элемент
            //                if (node.NodeType == System.Xml.XmlNodeType.Element)
            //                {
            //                    XElement el = (XElement)node;
            //                    //получаем значение аттрибута id и преобразуем его в Int32
            //                    int id = Int32.Parse(el.Attribute("id").Value);
            //                    //увеличиваем счетчик на единицу и присваиваем значение обратно
            //                    id++;
            //                    el.Attribute("id").Value = id.ToString();
            //                }
            //                //переходим к следующему узлу
            //                node = node.NextNode;
            //            }
            //            doc.Save(fileName);


            //            Теперь попробуем это сделать более правильным способом для наших задач:

            //foreach (XElement el in doc.Root.Elements("track"))
            //            {
            //                int id = Int32.Parse(el.Attribute("id").Value);
            //                el.SetAttributeValue("id", --id);
            //            }
            //            doc.Save(fileName);


            //            Добавление новой записи


            //Добавим новый трек в нашу библиотеку, а заодно вычислим средствами LINQ следующий уникальный Id для трека:

            //int maxId = doc.Root.Elements("track").Max(t => Int32.Parse(t.Attribute("id").Value));
            //            XElement track = new XElement("track",
            //                new XAttribute("id", ++maxId),
            //                new XAttribute("genre", "Break Beat"),
            //                new XAttribute("time", "5:35"),
            //                new XElement("name", "Higher Than A Skyscraper"),
            //                new XElement("artist", "Hybrid"),
            //                new XElement("album", "Morning Sci-Fi"));
            //            doc.Root.Add(track);
            //            doc.Save(fileName);


            //            Удаление элементов


            //Попробуем удалить все элементы исполнителя DMX:

            //IEnumerable<XElement> tracks = doc.Root.Descendants("track").Where(
            //                t => t.Element("artist").Value == "DMX").ToList();
            //            foreach (XElement t in tracks)
            //                t.Remove();


            //            В этом примере мы вначале выбрали все треки у который дочерний элемент artst удовлетворяет критерии, а потом в цикле удалили эти элементы.Важен вызов в конце выборки ToList().Этим самым мы фиксируем в отдельном участке памяти все элементы, которые хотим удалить.Если же мы надумаем удалять из набора записей, по которому проходим непосредственно в цикле, мы получим удаление первого элемента и последующий NullReferenceException.Так что важно помнить об этом.
            //           По совету xaoccps удалять можно и более простым способом:
            //           IEnumerable < XElement > tracks = doc.Root.Descendants("track").Where(
            //                           t => t.Element("artist").Value == "DMX");
            //            tracks.Remove();


            //            Отсортируем треки по продолжительности в обратном порядке:

            //            IEnumerable<XElement> tracks = from t in doc.Root.Elements("track")
            //                                           let time = DateTime.Parse(t.Attribute("time").Value)
            //                                           orderby time descending
            //                                           select t;
            //            foreach (XElement t in tracks)
            //                Console.WriteLine("{0} - {1}", t.Attribute("time").Value, t.Element("name").Value);


            //            Отсортируем элементы по жанру, исполнителю, названию альбома, названию трека:

            //IEnumerable<XElement> tracks = from t in doc.Root.Elements("track")
            //                               orderby t.Attribute("genre").Value,
            //                                    t.Element("artist").Value,
            //                                    t.Element("album").Value,
            //                                    t.Element("name").Value
            //                               select t;
            //            foreach (XElement t in tracks)
            //            {
            //                Console.WriteLine("{0} - {1} - {2} - {3}", t.Attribute("genre").Value,
            //                                t.Element("artist").Value,
            //                                t.Element("album").Value,
            //                                t.Element("name").Value);
            //            }


            //            Простенький запрос, выводящий количество треков в каждом альбоме:

            //            var albumGroups = doc.Root.Elements("track").GroupBy(t => t.Element("album").Value);
            //            foreach (IGrouping<string, XElement> a in albumGroups)
            //                Console.WriteLine("{0} - {1}", a.Key, a.Count());
            #endregion
        }
    }

}
