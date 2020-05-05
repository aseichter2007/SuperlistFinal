using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Superlist 
{
    public class SuperList<T> : IEnumerable where T : IComparable<T>
    {
        private T[] array;
        private int count;
        private int capacity;
        public T this[int i]
        {
            get
            {
                if (i>-1&&i < count)
                {
                    return array[i];
                }
                else
                {
                    throw new Exception("index outside of list");
                }
            }
            set
            {
                if (i>-1&&i < count)
                {
                    array[i] = value;
                }
                else
                {
                    throw new Exception("index outside of list");
                }
            }
        }
        public int Count
        {
            get => count;
        }
        public int Capacity
        {
            get => capacity;
            set {
                    if (Capacity<capacity)
                    {
                        ExtendCapacity(Capacity);
                    }
            }
        }


        public SuperList()
        {
            array = new T[3];
            count = 0;
            capacity = 3;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }
        //aparently the SuperList itself is not generic, but can contain generic items. Gottem.
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return ((IEnumerable<T>)array).GetEnumerator();
        //}


        public static SuperList<T> operator +(SuperList<T> list1, SuperList<T> list2)
        {
            SuperList<T> work = new SuperList<T>();
            foreach (T item in list1)
            {
                work.Add(item);
            }
            foreach (T item in list2)
	        {
                work.Add(item);
	        }
            return work;
        }
        public static SuperList<T> operator -(SuperList<T> list, SuperList<T> list2subtract)
        {
            SuperList<T> work = new SuperList<T>();
            foreach (T item in list)
            {
                work.Add(item);
            }
            foreach (T item in list2subtract)
            {
                work.Remove(item);
            }
            return work;
        }

        public void Add(T add)
        {
            bool fit = FitTest(count);
            if (fit)
            {
                array[count] = add;
                count++;
            }
            else
            {
                ExtendArray();
                array[count ] = add;
                count++;
            }


        }
        private bool FitTest(int index)
        {
            bool output =true;
            if (index == capacity)
            {
                output = false;
            }
            return output;
        }
        private void ExtendArray()
        {
            T[] work = new T[capacity*2];
            work = ArrayCopy(array, work);
            array = work;
            capacity = capacity * 2;
        }
        private void ExtendCapacity(int capacity)
        {
            T[] work = new T[capacity];
            work = ArrayCopy(array, work);
            array = work;
            this.capacity = capacity;
        }
        private T[] ArrayCopy(T[] copy ,T[] paste)
        {
            T[] output = paste;
            for (int i = 0; i < count; i++)
            {                
                    output[i] = copy[i];                   
            }
            return output;
        }
        public int Contains(T content)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(content))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public bool Remove(T remove)
        {
            bool output = false;
            int index = Contains(remove);
            if (index >=0&&index<count)
            {
                RemoveAt(index);
                output = true;
            }
            return output;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < count-1; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
        }
        public void CleanArray()
        {
            T[] work = new T[count];
            for (int i = 0; i < count; i++)
            {
                work[i] = array[i];
            }
            array = work;
            capacity = count;
        }
        
        public void RemoveAll(T remove)
        {
            int index = Contains(remove);
            while (index>-1)
            {
                RemoveAt(index);
                index = Contains(remove);
            }           
        }
        public override string ToString()
        {
            //you can use Object.ToString() to assist you
            string output="";
            StringBuilder stringBuilder = new StringBuilder();
            Type type= array[0].GetType();
            for (int i = 0; i < count; i++)
            {
                if (type.Equals(typeof(int)))
                {
                    stringBuilder.Append(array[i].ToString());
                    if (i < count - 1) 
                    {
                        stringBuilder.Append(", ");
                    }
                }
                else
                {
                    stringBuilder.Append(array[i].ToString());
                }
           }
            output = stringBuilder.ToString();
            return output;
        }
        public SuperList<T> Zip(SuperList<T> odd, SuperList<T> even)
        {
            SuperList<T> work = new SuperList<T>();
            int length = 0;
            if (odd.count>even.count)
            {
                length = odd.count;
            }
            else
            {
                length = even.count;
            }
            for (int i = 0; i < length; i++)
            {
                if (i<odd.count)
                {
                    work.Add(odd[i]);
                }
                if (i<even.count)
                {
                    work.Add(even[i]);
                }
            }
            return work;

        }
        public void SortUP()
        {
            T[] work = new T[count];
            int low = 0;
            int dupe = 0;
            SuperList<T> container = new SuperList<T>();
            T item;
            for (int i = 0; i < count; i++)
            {
                low = 0;
                dupe = 0;
                item = array[i];

                if (container.Contains(item)<0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (j != i && item.CompareTo(array[j]) > 0)
                        {
                            low++;
                        }
                        else if (item.Equals(array[j]))
                        {
                            dupe++;
                        }
                    }
                }
                container.Add(item);
                for (int k = 0; k < dupe; k++)
                {
                    work[k + low] = item;
                }
            }
            array = work;

        }
        public void SortDown()
        {
            T[] work = new T[count];
            int low = 0;
            int dupe = 0;
            SuperList<T> container = new SuperList<T>();
            T item;
            for (int i = 0; i < count; i++)
            {
                low = 0;
                dupe = 0;
                item = array[i];

                if (container.Contains(item) < 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (j != i && item.CompareTo(array[j]) > 0)
                        {
                            low++;
                        }
                        else if (item.Equals(array[j]))
                        {
                            dupe++;
                           container.Add(item);

                        }
                    }
                }
                low = count - low-dupe;
                //inverter for down
                for (int k = 0; k < dupe; k++)
                {
                    work[k + low] = item;
                }
            }
            array = work;

        }

        
    }
}
