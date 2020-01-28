using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Verp
{
    class Program
    {
        static string mPath = String.Empty;
        static string path1 = AppDomain.CurrentDomain.BaseDirectory + @"AssemblyInfo.cs";
        static string path2 = AppDomain.CurrentDomain.BaseDirectory + @"AssemblyInfo.cs";
        static string[] assemblyLines;
        static int? assemblyVersionIndex;
        static int? AssemblyFileVersionIndex;
        static string assemblyVersion;
        static string assemblyFileVersion;

        static void Main(string[] args)
        {
            mPath = path1;

            assemblyVersionIndex = GetAssemblyVersionIndex();
            AssemblyFileVersionIndex = GetAssemblyFileVersionIndex();

            assemblyVersion = GetAssemblyVersion();
            assemblyFileVersion = GetAssemblyFileVersion();

            int nb = NewBuild();
            SetAssemblyVersion(nb);

            Console.WriteLine("AssemblyVersion: {0}", assemblyVersion);
            Console.WriteLine("AssemblyFileVersion: {0}", assemblyFileVersion);

            assemblyVersion = GetAssemblyVersion();
            assemblyFileVersion = GetAssemblyFileVersion();

            Console.WriteLine("New AssemblyVersion: {0}", assemblyVersion);
            Console.WriteLine("New AssemblyFileVersion: {0}", assemblyFileVersion);
        }

        static int? GetAssemblyVersionIndex()
        {
            if (assemblyLines == null)
                assemblyLines = File.ReadAllLines(mPath);

            for (int i = 0; i < assemblyLines.Length; i++)
            {
                if (assemblyLines[i].Contains("assembly: AssemblyVersion")
                    && assemblyLines[i][0] != '/')
                    return i;
            }
            return null;
        }
        static int? GetAssemblyFileVersionIndex()
        {
            if (assemblyLines == null)
                assemblyLines = File.ReadAllLines(mPath);

            for (int i = 0; i < assemblyLines.Length; i++)
            {
                if (assemblyLines[i].Contains("assembly: AssemblyFileVersion")
                    && assemblyLines[i][0] != '/')
                    return i;
            }
            return null;
        }

        static string GetAssemblyVersion()
        {
            if (assemblyVersionIndex == null)
                return "0.0.0.0";
            return assemblyLines[assemblyVersionIndex.Value].Substrings("AssemblyVersion(\"", "\")]")[0];
        }
        static string GetAssemblyFileVersion()
        {
            if (AssemblyFileVersionIndex == null)
                return "0.0.0.0";
            return assemblyLines[AssemblyFileVersionIndex.Value].Substrings("AssemblyFileVersion(\"", "\")]")[0];
        }

        static void SetAssemblyVersion(int ver)
        {
            string avp = "[assembly: AssemblyVersion(\"{0}.{1}.{2}.0\")]";
            string afvp = "[assembly: AssemblyFileVersion(\"{0}.{1}.{2}.0\")]";
            string[] v1 = assemblyVersion.Split('.');

            assemblyLines[assemblyVersionIndex.Value] =
                string.Format(avp, v1[0], v1[1], ver);
            assemblyLines[AssemblyFileVersionIndex.Value] =
                string.Format(afvp, v1[0], v1[1], ver);

            File.WriteAllLines(mPath, assemblyLines);
        }

        static int NewBuild()
        {
            /*
            int b1 = (int)(DateTime.UtcNow - new DateTime(DateTime.UtcNow.Year, 1, 1)).TotalDays;
            int b2 = (int)(DateTime.UtcNow - new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day)).TotalMinutes;
            return b2;*/

            int build = 1;

            string vBin = AppDomain.CurrentDomain.BaseDirectory + @"v.bin";
            if (File.Exists(vBin))
            {
                byte[] b = File.ReadAllBytes(vBin);
                build = BitConverter.ToInt32(b, 0);
            }

            byte[] bn = BitConverter.GetBytes(build + 1);
            File.WriteAllBytes(vBin, bn);
            return build;
        }

    }
}