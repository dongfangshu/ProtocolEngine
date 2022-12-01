//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//public class CodeWriter
//{
//    StringBuilder sb;
//    public CodeWriter()
//    {
//        sb =new StringBuilder();
//    }
//    public CodeWriter(int layer)
//    {
//        blockCount = layer;
//        for (int i = 0; i < layer; i++)
//        {
//            lineHead += "\t";
//        }
//        sb = new StringBuilder();
//    }
//    string lineHead ="";
//    public int blockCount = 0;
//    public void WriteLine(string str)
//    {
//        string formatStr = lineHead + str;
//        sb.AppendLine(formatStr);
//    }
//    public void Write(string str)
//    {
//        string formatStr = lineHead + str;
//        sb.Append(formatStr);
//    }
//    public void Append(string str, params object[] args)
//    {
//        string formatStr =string.Format(str, args);
//        sb.Append(formatStr);
//    }
//    public void Reset()
//    {
//        sb.Clear();
//        lineHead=string.Empty;
//    }
//    public void StartBlock()
//    {
//        sb.AppendLine(lineHead+"{");
//        lineHead += "\t";
//        blockCount++;
//    }
//    public void EndBlock()
//    {
//        blockCount--;
//        lineHead = string.Empty;
//        for (int i = 0; i < blockCount; i++)
//        {
//            lineHead += "\t";
//        }
//        sb.AppendLine(lineHead+"}");
//    }

//    public void Save(string path)
//    {
//        if (File.Exists(path))
//        {
//            File.Delete(path);
//        }
//        File.WriteAllText(path, sb.ToString(),Encoding.Unicode);
//    }
//    public override string ToString()
//    {
//        return sb.ToString();
//    }
//}
