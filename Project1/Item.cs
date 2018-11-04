using System;

namespace Project1
{
    [Serializable]
    class Item
    {
        public int number { get; }
        public string text { get; set; }
        public Item(int n, string s)
        {
            number = n;
            text = s;
        }
    }
}
