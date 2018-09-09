using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phone_book
{
    public partial class Form1 : Form
    {
        String path = @"./test.txt";
        class Person {
          public int SNO {get; set;}
          public string NAME {get; set;}
          public string EMAIL {get; set;}
          public string PHONE {get; set;}
          public Person(int value0, string value1, string value2, string value3)
            {
              SNO = value0;
              NAME = value1;
              EMAIL = value2;
              PHONE = value3;
            }
        }
        public Form1()
        {
            InitializeComponent();
            readFile();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            readFile();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.Write("textBox1 :: {0}", textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write("textBox1 :: {0}", textBox1.Text);
            Console.Write("textBox2 :: {0}", textBox2.Text);
            Console.Write("textBox3 :: {0}", textBox3.Text);
            saveIntoFile(textBox1.Text, textBox2.Text, textBox3.Text);
        }
        private void readFile()
        {
            int counter = 0;
            List<string> arr = new List<string>();
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                arr.Add(line);
                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
            createTable(arr);
        }
        private void saveIntoFile(string textToSave1, string textToSave2, string textToSave3) 
        {
            Console.Write("textToSave :: {0}", textToSave1);
            //if (File.Exists(path))
            //{
            //    using (var tw = new StreamWriter(path, true))
            //    {
            //        tw.WriteLine("{0},{1},{2}", textToSave1, textToSave2, textToSave3);
            //        readFile();
            //    }
            //}
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (StreamWriter tw = File.AppendText(path))
                {
                    tw.WriteLine("{0},{1},{2}", textToSave1, textToSave2, textToSave3);
                    tw.Close();
                }

            }
            else if (File.Exists(path))
            {
                using (StreamWriter tw = File.AppendText(path))
                {
                    tw.WriteLine("{0},{1},{2}", textToSave1, textToSave2, textToSave3);
                    tw.Close();
                }
            }
            readFile();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            readFile();
        }
        private void createTable(List<string> dataArr)
        {
            List<Person> persons = new List<Person>();
            DataTable table = new DataTable();
            BindingSource Source = new BindingSource();
            for (int i = 0; i < dataArr.Count; i++)
            {
                Console.WriteLine(dataArr[i]);
                string[] splittedStr = dataArr[i].Split(',');
                //Source.Add('SNO',splittedStr[0]);
                persons.Add(new Person(i, splittedStr[0], splittedStr[1], splittedStr[2]));

            };
            dataGridView1.DataSource = persons;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Console.Write("textBox2 :: {0}", textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Console.Write("textBox3 :: {0}", textBox3.Text);
        }
    }
    
}
