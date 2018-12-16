using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;

namespace Project1
{
    class Catalogue
    {
        private List<Item> LCatalogue;

        public Catalogue()
        {
            LCatalogue = new List<Item>();
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                LCatalogue.AddRange(File.ReadAllLines(filePath).ToList().Select(x => Item.GetItemFromStringLine(x)).Where(x => x != null).ToList());
            }
        }

        public void SaveToFile(string filePath)
        {
            File.WriteAllLines(filePath, LCatalogue.Select(x => x.ToString()).ToList());
        }

        public int GetIndexOfNumber(int iNumber)
        {
            int iIndex = -1;
            for (int i = 0; i < LCatalogue.Count; i++)
            {
                if (LCatalogue[i].Number == iNumber)
                {
                    iIndex = i;
                    break;
                }
            }
            return iIndex;
        }

        public string GetTextByIndex(int iIndex)
        {
            string sResult = null;
            if (Enumerable.Range(0, LCatalogue.Count).Contains(iIndex))
            {
                sResult = LCatalogue[iIndex].Text;
            }
            return sResult;
        }

        public string GetTextByNumber(int iNumber)
        {
            string sResult = null;
            int iIndex = -1;
            for (int i = 0; i < LCatalogue.Count; i++)
            {
                if (LCatalogue[i].Number == iNumber)
                {
                    iIndex = i;
                    sResult = LCatalogue[i].Text;
                    break;
                }
            }
            return sResult;
        }

        public void ModifyTextByIndex(int iIndex, string sText)
        {
            LCatalogue[iIndex].Text = sText;
        }

        // if item with given number exists - modify text value and return true
        // if not - add new item and return false
        public bool AddEditItem(int iNumber, string sText)
        {
            int iIndex = GetIndexOfNumber(iNumber);
            if (iIndex == -1)
            {
                LCatalogue.Add(new Item(iNumber, sText));
                return false;
            }
            else
            {
                LCatalogue[iIndex].Text = sText;
                return true;
            }
        }

        public List<int> GetListOfNumbers()
        {
            return LCatalogue.Select(x => x.Number).ToList();
        }

        public void SaveToFileXml(string filePath)
        {
            DataTable dt = new DataTable();
            dt.TableName = "item";
            dt.Columns.Add("number");
            dt.Columns.Add("text");
            foreach (var item in LCatalogue)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["number"] = item.Number;
                dt.Rows[dt.Rows.Count - 1]["text"] = item.Text;
            }
            dt.WriteXml(filePath, XmlWriteMode.WriteSchema);
        }

        public void LoadFromFileXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                DataTable newTable = new DataTable();
                newTable.ReadXml(filePath);
                var convertedList = (from rw in newTable.AsEnumerable()
                                     select new Item(
                                         Convert.ToInt32(rw["number"]),
                                         Convert.ToString(rw["text"])
                                         )
                                     ).ToList();
                LCatalogue = convertedList;
            }
        }
    }
}
