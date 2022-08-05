using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPOC
{
    class CustomArraylist : IList,IDisposable
    {
        public CustomArraylist()
        {
            Initialize();
        }
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private object[] values = null;

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count = 0;

        public int Capacity = 0;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        int ICollection.Count => throw new NotImplementedException();

        private void Initialize()
        {
            this.Count = 0;
            this.Capacity = 5;
            values = new object[this.Capacity];
        }

        public int Add(object value)
        {
            if (this.Count + 1 >= this.Capacity)
            {
                this.Capacity *= 2;

                object[] temValues = new object[this.Capacity];

                for (int i = 0; i < this.Count; i++)
                {
                    //tempKeys[i] = tkeys[i];
                    temValues[i] = values[i];
                }

                temValues[this.Count] = value;
                this.Count++;
                //tkeys = tempKeys;
                values = temValues;
                return this.Count - 1;
            }
            else
            {
                values[this.Count] = value;
                this.Count++;
                return this.Count - 1;
            }
            //throw new NotImplementedException();
        }

        public void Clear()
        {
            Initialize();
        }

        public bool Contains(object value)
        {
            foreach (var item in values)
            {
                if (item.Equals(value))
                    return true;

            }

            return false;
        }

        public void CopyTo(Array array, int index)
        {
            object[] temValues = new object[this.Capacity + array.Length];
            int cnt = 0;

            for (int i = 0; i < index - 1; i++)
            {
                temValues[cnt++] = values[i];
            }

            for (int i = index; i < array.Length; i++)
            {
                temValues[cnt++] = array.GetValue(i);
                this.Count++;
            }
            for (int i = index; i < values.Length; i++)
            {
                temValues[cnt++] = values[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return values[i];
            }
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Equals(value))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, object value)
        {
            object[] tempArray = new object[this.Capacity];
            for (int i = 0; i < index - 1; i++)
            {
                tempArray[i] = values[i];
            }
            tempArray[index - 1] = value;
            this.Count++;
            for (int i = index - 1; i < this.Count; i++)
            {
                tempArray[i + 1] = values[i];
            }
            values = tempArray;
        }

        public void Remove(object value)
        {
            int idx = this.IndexOf(value);
            if (idx != -1)
            {
                this.RemoveAt(idx + 1);
            }
            else
                throw new InvalidOperationException("Value not found : " + value.ToString());
        }

        public void RemoveAt(int index)
        {
            object[] tempArray = new object[this.Capacity];
            for (int i = 0; i < index - 1; i++)
            {
                tempArray[i] = values[i];
            }

            for (int i = index ; i < this.Count; i++)
            {
                tempArray[i - 1] = values[i];
            }
            this.Count--;
            values = tempArray;
       }

        protected virtual void Dispose(bool val)
        {
            
        }

        public void Dispose()
        {
            
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
