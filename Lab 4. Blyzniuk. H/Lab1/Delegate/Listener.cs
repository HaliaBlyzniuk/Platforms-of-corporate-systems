using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Delegate
{
    class Listener
    {
        public List<ListEntry> ListenerList { get; set; }

        public Listener()
        {
            ListenerList = new List<ListEntry>();
        }

        public void AddEvent(object source, MagazineListHandlerEventArgs args)
        {
            Console.WriteLine("tr");
            ListEntry entry = new ListEntry(args.CollectionName, args.CollectionChangeType, args.ElementNumber);
            ListenerList.Add(entry);
        }

        public override string ToString() => $"{string.Join("\n", ListenerList.Select(x => x.ToString()).ToArray())}";
    }
}
