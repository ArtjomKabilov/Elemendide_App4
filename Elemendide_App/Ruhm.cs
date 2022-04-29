using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Elemendide_App
{
    class Ruhm<K,T> : ObservableCollection<T>
    {
        public K Nimetus { get; private set; }
        public Ruhm(K nimetus, IEnumerable<T> items)
        {
            Nimetus = nimetus;
            foreach (T item in items)
                Items.Add(item);
        }
    }
}
