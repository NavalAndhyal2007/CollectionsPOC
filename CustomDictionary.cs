using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPOC
{
    class CustomDictionary<Tkey, TValue> : IDictionary<Tkey,TValue>//where TValue : struct
    {
        private const int V = -1;
        Tkey[] tkeys;
        TValue[] tvalues;
        public int capacity = 0;
        public int size = 0;

        public CustomDictionary()
        {
            Clear();
        }

        //public int MyProperty { get { } set }

        public TValue this[Tkey key]
        {
            get
            {
                TValue value = default(TValue);
                this.TryGetValue(key, out value);
                return value;
            }

            set
            {
                this.Add(new KeyValuePair<Tkey, TValue>(key, value));
            }
        }

        public int Count => this.size;

        public bool IsReadOnly => throw new NotImplementedException();

        ICollection<Tkey> IDictionary<Tkey, TValue>.Keys => throw new NotImplementedException();

        ICollection<TValue> IDictionary<Tkey, TValue>.Values => throw new NotImplementedException();

        public void PrintKeys()
        {
            if (this.size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(tkeys[i].ToString());
                }
            }
        }
        public void PrintValues()
        {
            if (this.size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(tvalues[i].ToString());
                }
            }
        }

        public void Add(Tkey key, TValue value)
        {
            if (this.ContainsKey(key))
                throw new InvalidOperationException("Key is Alread Presernt " + key.ToString());
            if(this.size + 1 >= this.capacity)
            {
                this.capacity = this.capacity * 2;

                Tkey[] tempKeys = new Tkey[this.capacity];
                TValue[] temValues = new TValue[this.capacity];

                for (int i = 0; i < tkeys.Length; i++)
                {
                    tempKeys[i] = tkeys[i];
                    temValues[i] = tvalues[i];
                }

                this.size++;
                tempKeys[this.size - 1] = key;
                temValues[this.size - 1] = value;
                tkeys = tempKeys;
                tvalues = temValues;
            }
            else
            {
                this.size++;
                tkeys[this.size - 1] = key;
                tvalues[this.size - 1] = value;
            }
        }

        public void Add(KeyValuePair<Tkey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.capacity = 5;
            this.size = 0;
            tkeys = new Tkey[this.capacity];
            tvalues = new TValue[this.capacity];
        }

        public bool Contains(KeyValuePair<Tkey, TValue> item)
        {
            bool retVal = false;
            if (this.size > 0)
            {
                retVal = this.ContainsKey(item.Key);

                foreach (var val in this.tvalues)
                {
                    if (val.Equals(item.Value))
                        retVal = true;
                }
            }
            return retVal;
        }

        public bool ContainsKey(Tkey key)
        {
            if (this.size > 0)
            {
                foreach (var key1 in this.tkeys)
                {
                    if (key1.Equals(key))
                        return true;
                    // return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<Tkey, TValue>[] array, int arrayIndex)
        {

            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                KeyValuePair<Tkey, TValue> keyValuePair = new KeyValuePair<Tkey, TValue>(tkeys[i], tvalues[i]);
                yield return keyValuePair;

            }
        }

        public int GetKeyIndex(Tkey key)
        {

            int cnt = 0;
            if (this.size > 0)
            {
                foreach (var item in tkeys)
                {
                    if (item.ToString().Equals(key.ToString()))
                    {
                        return cnt;
                    }
                    cnt++;
                }
            }
            return -1;
        }

        private bool IsKeyFound(Tkey key)
        {
            foreach (var item in tkeys)
            {
                if (item.Equals(key))
                    return true;
            }

            return false; ;
        }
        public bool Remove(Tkey key)
        {
            int idxKey = GetKeyIndex(key);
            if (idxKey == -1)
                throw new KeyNotFoundException();
            else
            {
                var tkeysList = tkeys.ToList();
                tkeysList.Remove(key);
                tkeys = tkeysList.ToArray();

                var tvaluesList = tvalues.ToList();
                tvaluesList.Remove(tvalues[idxKey]);
                tvalues = tvaluesList.ToArray();
                this.size--;
                return true;
            }
        }

        public bool Remove(KeyValuePair<Tkey, TValue> item)
        {
            return this.Remove(item.Key);
        }

        public bool TryGetValue(Tkey key, out TValue value)
        {
            var idxKey = GetKeyIndex(key);
            if (this.size > 0)
            {
                if (idxKey == -1)
                {
                    TValue retVal = default(TValue);
                    value = retVal;
                    return false;
                }
                else
                {
                    value = tvalues[idxKey];
                    return true;
                }
            }
            TValue retVa1l = default(TValue);
            value = retVa1l;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
