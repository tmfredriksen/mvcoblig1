﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}