﻿using System;

namespace iot.solution.entity
{
    public class LookupItem
    {
        private string _Value;
        public string Value { get { return _Value; } set { _Value = value; } }
        public string Text { get; set; }
    }

    public class TagLookup
    {
        public string tag { get; set; }
        public bool templateTag { get; set; }
    }

    public class GreenhouseLookup : LookupItem
    {       
        public string ParentEntityGuid { get; set; }
    }
}
