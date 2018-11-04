using System;

namespace Project1
{
    [Serializable]
    class Item
    {
        public int Number { get; }
        public string Text { get; set; }

        public Item(int number, string text)
        {
            Number = number;
            Text = text;
        }
    }
}
