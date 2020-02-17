﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iot.solution.entity
{
    public class BulkUploadResponse
    {
        public Guid kitGuid { get; set; }
        public string kitCode { get; set; }
        public Guid kitTypeGuid { get; set; }
        public string kitError { get; set; }
        public Guid guid { get; set; }
        public string parentUniqueId { get; set; }
        public string parentDeviceGuid { get; set; }
        public string uniqueId { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string tag { get; set; }
        public bool isProvisioned { get; set; }
        public string deviceError { get; set; }

        
    }
}