﻿using System;
using System.IO;
using Newtonsoft.Json;
using part_one;

namespace part_five
{
    public class DataFillerJSON : DataFiller
    {

        private string filename { get; }

        public DataFillerJSON(string filename)
        {
            this.filename = filename;
        }
        public void Fill(DataContext context)
        {
            DataContext _context = JsonConvert.DeserializeObject<DataContext>(File.ReadAllText(this.filename));
            context.wykazList = _context.wykazList;
            context.katalogDict = _context.katalogDict;
            context.zdarzenieCollection = _context.zdarzenieCollection;
            context.statusInfoList = _context.statusInfoList;
        }
    }
}