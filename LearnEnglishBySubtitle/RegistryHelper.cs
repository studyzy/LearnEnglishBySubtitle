using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Studyzy.LearnEnglishBySubtitle
{
    class RegistryHelper
    {
        public static string GetRegistData(string name)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("LearnEnglishBySubtitle", true);
            if (aimdir == null)
            {
                return null;
            }
            registData = aimdir.GetValue(name).ToString();
            return registData;
        }
        public static void WTRegedit(string name, string tovalue)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.CreateSubKey("LearnEnglishBySubtitle");
            aimdir.SetValue(name, tovalue);
        }
    }
}
