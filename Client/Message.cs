using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Message
    {
        public string Sender;
        public string Addr;
        public string Text;
        public long Numer;
        public DateTime Time;
        
        public void Save(MyFile f)
        {
            f.WriteLong(Numer);
            f.WriteString(Sender);
            f.WriteString(Addr);
            f.WriteString(Text);
            f.WriteDataTime(Time);
        }
        public void Load(MyFile f)
        {
            Numer = f.ReadLong();
            Sender = f.ReadString();
            Addr = f.ReadString();
            Text = f.ReadString();
            Time = f.ReadDataTime();
        }
        public void Send(MyNetworkStream f)
        {
            f.Write(Numer);
            f.Write(Sender);
            f.Write(Addr);
            f.Write(Text);
            f.WriteDataTime(Time);
        }
        public void Recive(MyNetworkStream f)
        {
            Numer = f.ReadLong();
            Sender = f.ReadString();
            Addr = f.ReadString();
            Text = f.ReadString();
            Time = f.ReadDataTime();
        }
    }
}
