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

            if (path.StartsWith(pathToXmls))
            {
                string[] FilesPathArray = Directory.GetFiles(PathEdit.Text);
                for (int i = 0; i < FilesPathArray.Length; i++)
                {
                    FilesLB.Items.Add(FilesPathArray[i]);
                }
            }
            else System.Windows.MessageBox.Show("Chech path to files plese");
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

        public class issuance
        {

        }
        public void ParseBtn_Click(object sender, RoutedEventArgs e)
        {

            //задаем путь к нашему рабочему файлу XML
            string fileName = FilesLB.SelectedItem.ToString();
            //читаем данные из файла
            XDocument doc = XDocument.Load(fileName);
            foreach (XElement el in doc.Root.Elements())
            {
                //Выводим имя элемента и значение аттрибута id
                Console.WriteLine("{0}", el.Name);
                //Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
                Console.WriteLine("  Attributes:");
                //выводим в цикле все аттрибуты, заодно смотрим как они себя преобразуют в строку
                foreach (XAttribute attr in el.Attributes())
                    Console.WriteLine("    {0}", attr);
                Console.WriteLine("  Elements:");
                //выводим в цикле названия всех дочерних элементов и их значения
                foreach (XElement element in el.Elements())
                    Console.WriteLine("    {0}: {1}", element.Name, element.Value);
            }

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
        }
    }
    
}
