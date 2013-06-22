// ----------------------------------------------------------------------
// WCF Going Crazy
// Author : Cokorda Smara
// Date   : 22 Juni 2013
// Time   : 03:05
// Url    : https://www.facebook.com/cokde.smara
// Copyright 2013 WCF Going Crazy. All Right Reserved.
// ------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GC.Foundation
{
    [DataContract]
    public class Pesan
    {
        [DataMember(Order = 1)]
        public String Error { get; set; }
    }
}
