using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class MyFile
    {
        BinaryReader rdr;
        BinaryWriter wrt;
        FileStream str;
        public void Close()
        {
            str.Close();
        }
        public int OpenRead(string FName)
        {
            if (File.Exists(FName))
            {
                str = File.Open(FName, FileMode.Open);
                rdr = new BinaryReader(str);
                return 1;
            }
            return 0;
        }
        public int OpenWrite(string FName)
        {
            if (File.Exists(FName))
            {
                File.Delete(FName);
            }
            str = File.Create(FName);
            wrt = new BinaryWriter(str);
            return 1;
        }
        public int ReadInt()
        {
            return rdr.ReadInt32();
        }
        public string ReadString()
        {
            return rdr.ReadString();
        }
        public void WriteInt(int Val)
        {
            wrt.Write(Val);
        }
        public void WriteString(string str)
        {
            wrt.Write(str);
        }

        public long ReadLong()
        {
            if (rdr != null)
            {
                return rdr.ReadInt64();
            }
            return 0L;
        }
        public void WriteLong(long l)
        {
            if (wrt != null) wrt.Write(l);
        }
        public void WriteDataTime(DateTime dt)
        {
            if (wrt != null) wrt.Write(dt.ToString());
        }
        public DateTime ReadDataTime()
        {
            DateTime dt = new DateTime(1980, 1, 1, 0, 0, 0);
            if (rdr != null)
            {
                return Convert.ToDateTime(rdr.ReadString());
            }
            return dt;
        }
    }

}
