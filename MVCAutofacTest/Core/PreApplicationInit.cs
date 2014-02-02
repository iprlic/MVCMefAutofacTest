using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using MVCAutofacTest.Core;

[assembly: PreApplicationStartMethod(typeof(PreApplicationInit), "Initialize")]
namespace MVCAutofacTest.Core
{
    
    public static class PreApplicationInit
    {

        internal static DirectoryInfo PluginFolder { get; private set; }


        internal static DirectoryInfo ShadowCopyFolder { get; private set; }

        static PreApplicationInit()
        {
            PluginFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/Plugins"));
            ShadowCopyFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/Plugins/Temp"));
        }

        public static void Initialize()
        {
            if (!Directory.Exists(ShadowCopyFolder.FullName))
                Directory.CreateDirectory(ShadowCopyFolder.FullName);
            else
            {
                foreach (FileInfo fi in ShadowCopyFolder.GetFiles("*.dll", SearchOption.AllDirectories))
                {
                    try
                    {
                        fi.Delete();
                    }
                    catch (Exception ex)
                    {
                        // TODO log
                        Debug.WriteLine(ex.ToString());
                    }
                }
            } 

            foreach (var fi in PluginFolder.GetFiles("*.dll"))
            {
                try
                {
                    File.Copy(fi.FullName, Path.Combine(ShadowCopyFolder.FullName, fi.Name), true);
                }
                catch (Exception ex)
                {
                    // TODO log
                    Debug.WriteLine(ex.ToString());
                }
            }
        }
    }
}