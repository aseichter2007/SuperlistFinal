using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Superlist 
{
    public class SuperList<T> : IEnumerable<T>
    {
        private T[] array;
        private int count;
        private int capacity;
        public T this[int i]
        {
            get
            {
                if (i < count)
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
                if (i < count)
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
        }


        public SuperList()
        {
            array = new T[3];
            count = 0;
            capacity = 3;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }            
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
            work = ArrayAddCopy(array, work);
            array = work;
            capacity = capacity * 2;
        }
        private T[] ArrayAddCopy(T[] copy ,T[] paste)
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
        public void Remove(T remove)
        {
            int index = Contains(remove);
            if (index >=0)
            {
                RemoveAt(index);
            }
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
            string output="";
            return output;
        }
        public void Zip(SuperList<T> listOne, SuperList<T> listTwo)
        {

        }
        public void SortUP()
        {

        }
        public void SortDown()
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }
    }
}
