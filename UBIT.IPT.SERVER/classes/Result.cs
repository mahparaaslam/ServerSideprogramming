﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBIT.IPT.SERVER.classes
{
    public class Result
    {
 
        public int minMarks  { get; set; }

        public string minMarksSubject { get; set; }
        public int maxMarks { get; set; }

        public string maxMarksSubject { get; set; }

        public float average { get; set; }
    }

}