using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class MyNetworkStream
    {
        BinaryReader rdr;
        BinaryWriter wrt;
        NetworkStream nstr;

        public void Close()
        {
            nstr.Close();
        }

        public MyNetworkStream(NetworkStream ns)
        {
            nstr = ns;
            rdr = new BinaryReader(nstr);
            wrt = new BinaryWriter(nstr);
        }

        public long WriteLong()
        {
            return rdr.ReadInt64();
        }
        public int ReadInt()
        {
            return rdr.ReadInt32();
        }

        public float ReadFloat()
        {
            return rdr.ReadSingle();
        }

        public void Flush()
        {
            wrt.Flush();
        }

        public string ReadString()
        {
            return rdr.ReadString();
        }

        public void Write(int Val)
        {
            wrt.Write(Val);
        }

        public void Write(string str)
        {
            if (str != null) wrt.Write(str);
            else wrt.Write("");
        }

        public void Write(float fl)
        {
            wrt.Write(fl);
        }
        public long ReadLong()
        {
            if (rdr != null)
            {
                return rdr.ReadInt64();
            }
            return 0L;
        }
        public void Write(long l)
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
