using System;

namespace Project1
{
    class Item
    {
        public int Number { get; }
        public string Text { get; set; }

        public Item(int number, string text)
        {
            Number = number;
            Text = text;
        }

        public static Item GetItemFromStringLine(string dataLine)
        {
            var index = dataLine.IndexOf(' ');

            return null;
        }
    }
}
