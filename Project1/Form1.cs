using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project1
{
    public partial class Form1 : Form
    {
        private Catalogue vdsgCatalogue;

        //private string filePath = "vdsgCatalogue.bin";
        private string filePath = "datafile.txt";

        public Form1()
        {
            InitializeComponent();

            vdsgCatalogue = new Catalogue();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vdsgCatalogue.LoadFromFile(filePath);
            //LoadListFromFile(filePath);
            // update ListBox
            listBox1.Items.Clear();
            List<int> lNumbers = vdsgCatalogue.GetListOfNumbers();
            foreach (int i in lNumbers)
            {
                listBox1.Items.Add(i);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // get value of listbox selected item
                string sNumberSelected = listBox1.SelectedItem.ToString();
                int iNumber = Int32.Parse(sNumberSelected);
                // fetch item
                textBoxItemNumber.Text = sNumberSelected;
                textBoxItemText.Text = vdsgCatalogue.GetTextByNumber(iNumber);
            }
        }

        private void buttonItemSave_Click(object sender, EventArgs e)
        {
            // create new item
            string sNumber = textBoxItemNumber.Text;
            bool parsed = Int32.TryParse(sNumber, out int iNumber);
            string sText = textBoxItemText.Text;
            // add or update item
            bool bExists = vdsgCatalogue.AddEditItem(iNumber, sText);
            if (!bExists)
            {
                listBox1.Items.Add(iNumber);
            }

            toolStripStatusLabel1.Text = iNumber + " saved.";
        }

        private void textBoxItemNumber_TextChanged(object sender, EventArgs e)
        {
            // clean 'number' textBox from incorrect symbols
            string sNumber = textBoxItemNumber.Text;
            bool parsed = Int32.TryParse(sNumber, out int iNumber);
            // fetch item
            textBoxItemNumber.Text = iNumber.ToString();
            textBoxItemText.Text = vdsgCatalogue.GetTextByNumber(iNumber);
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveListToFile(filePath);

            Close();
        }

        private void LoadListFromFile(string sFilePath)
        {
            using (Stream stream = File.Open(sFilePath, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                //vdsgCatalogue.LCatalogue = (List<Item>)bformatter.Deserialize(stream);
            }
        }

        private void SaveListToFile(string sFilePath)
        {
            using (Stream stream = File.Open(sFilePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //bformatter.Serialize(stream, vdsgCatalogue.LCatalogue);
            }
        }
    }
}
