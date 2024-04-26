using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class TextReader
    {
        /// <summary>
        /// Reads a text file, returning a string
        /// </summary>
        /// <param name="fileName">The file to read</param>
        /// <returns>the text contents of the file</returns>
        public static string ReadFile(string fileName)
        {
            StreamReader sr = new StreamReader("../../../../" + fileName);
            string output = sr.ReadToEnd();
            sr.Close();
            return output;
        }
        /// <summary>
        /// Reads a text file, returning an array of the lines.
        /// </summary>
        /// <param name="fileName">The file to read</param>
        /// <returns>the text contents of the file</returns>
        public static string[] ReadFileLines(string fileName)
        {
            StreamReader sr = new StreamReader("../../../" + fileName);
            string output = sr.ReadToEnd();
            sr.Close();
            return output.Split('\n');
        }
    }
}
