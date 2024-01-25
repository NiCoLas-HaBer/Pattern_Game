using PatternsColors.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PatternsColors
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private List<T> items;
        private int position = -1;

        public MyEnumerator(List<T> items)
        {
            this.items = items;
        }

        public bool MoveNext()
        {
            position++;
            return position < items.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            // Implement IDisposable pattern if needed
        }

        public T Current
        {
            get
            {
                if (position >= 0 && position < items.Count)
                    return items[position];
                else
                    throw new InvalidOperationException();
            }
        }

        object IEnumerator.Current => Current;
    }
}
