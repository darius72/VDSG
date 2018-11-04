using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    class Catalogue
    {
        public List<Item> lCatalogue { get; set; }

        public Catalogue()
        {
            lCatalogue = new List<Item>();
        }

        public int GetIndexOfNumber(int iNumber)
        {
            int iIndex = -1;
            for (int i = 0; i < lCatalogue.Count; i++)
            {
                if (lCatalogue[i].number == iNumber)
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
            if (Enumerable.Range(0, lCatalogue.Count).Contains(iIndex))
            {
                sResult = lCatalogue[iIndex].text;
            }
            return sResult;
        }

        public string GetTextByNumber(int iNumber)
        {
            string sResult = null;
            int iIndex = -1;
            for (int i = 0; i < lCatalogue.Count; i++)
            {
                if (lCatalogue[i].number == iNumber)
                {
                    iIndex = i;
                    sResult = lCatalogue[i].text;
                    break;
                }
            }
            return sResult;
        }

        public void ModifyTextByIndex(int iIndex, string sText)
        {
            lCatalogue[iIndex].text = sText;
        }

        // if item with given number exists - modify text value and return true
        // if not - add new item and return false
        public bool AddEditItem(int iNumber, string sText)
        {
            int iIndex = GetIndexOfNumber(iNumber);
            if (iIndex == -1)
            {
                lCatalogue.Add(new Item(iNumber, sText));
                return false;
            }
            else
            {
                lCatalogue[iIndex].text = sText;
                return true;
            }
        }

        public List<int> GetListOfNumbers()
        {
            List<int> lResult = new List<int>();
            foreach (Item it in lCatalogue)
            {
                lResult.Add(it.number);
            }
            return lResult;
        }
    }
}
