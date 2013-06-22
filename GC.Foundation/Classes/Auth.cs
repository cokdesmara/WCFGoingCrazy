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
using System.Text;

namespace GC.Foundation
{
    public class Auth
    {
        public Auth() { }

        public Boolean Autentikasi(String User, String ApiKey)
        {
            if (User == "admin" && ApiKey == "123456789")
                return true;
            else
                return false;
        }
    }
}
