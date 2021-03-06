﻿using System;

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

        public override string ToString()
        {
            return Number.ToString() + ' ' + Text;
        }

        public static Item GetItemFromStringLine(string dataLine)
        {
            var index = dataLine.IndexOf(' ');
            if (index == -1)
                return null;
            int integer = 0;
            var success = int.TryParse(dataLine.Substring(0,index), out integer);
            if (!success)
                return null;
            return new Item(integer,dataLine.Substring(index + 1, dataLine.Length - (index + 1)));
        }
    }
}
