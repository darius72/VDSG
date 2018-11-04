using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            List<string> dataFile = File.ReadAllLines(filePath).ToList();
            LCatalogue.AddRange(dataFile.Select(x => Item.GetItemFromStringLine(x)).Where(x => x != null).ToList());
        }

        public void SaveToFile(string filePath)
        {
            //---
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
    }
}
