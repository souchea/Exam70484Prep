using System;
using System.Collections.Generic;
using System.Text;

namespace Exam484Prep.Model
{
    public class Chapter
    {
        public string Title { get; set; }

        public List<Item> Items { get; set; }

        public Chapter()
        {
            Items = new List<Item>();
        }
    }
}
