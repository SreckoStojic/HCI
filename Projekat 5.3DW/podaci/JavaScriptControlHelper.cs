using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Projekat_5._3DW.podaci
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        MainWindow prozor;
        Window1 prozor2;
        Window2 prozor3;
        public JavaScriptControlHelper(MainWindow w)
        {
            prozor = w;
        }

        public JavaScriptControlHelper(Window1 window1)
        {
            // TODO: Complete member initialization
           prozor2 = window1;
        }

        public JavaScriptControlHelper(Window2 window2)
        {
            // TODO: Complete member initialization
            prozor3 = window2;
        }

        public void RunFromJavascript(string param)
        {
            prozor.doThings(param);
        }
    }

}
