using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._2._1.DYNAMIC_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> arr = new(5);
            arr.Add(5454);
            var array = arr.Clone();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

        }

    }



    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        protected T[] list;
        public int Lenght = 0;
        private static readonly T[] emptyArray = new T[0];
        public int capaсity = 8;

        public DynamicArray()
        {
            this.list = new T[8];

        }

        public DynamicArray(int capaсity)
        {
            this.capaсity = capaсity;
            this.list = new T[capaсity];
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new Exception($"collectrion {nameof(collection)} is null");
            }

            if (collection is ICollection<T> c)
            {
                Lenght += c.Count;
                list = new T[c.Count];
                c.CopyTo((T[])list, 0);
            }

        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Lenght; i++)
            {
                yield return list[i];
            }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new Exception($"collectrion {nameof(item)} is null");
            }
            if (Lenght != capaсity)
            {

                list[Lenght] = item;
                Lenght++;

            }
            else if (Lenght == capaсity)
            {
                Array.Resize<T>(ref list, capaсity *= 2);

                list[Lenght] = item;
                Lenght++;
            }

        }



        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new Exception($"collectrion {nameof(collection)} is null");
            }
            else
            {
                foreach (var item in collection)
                {
                    Add(item);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }


        public bool Remove(T element)
        {
            int c = -1;
            foreach (var item in list)
            {
                c++;
                if (element.Equals(item))
                {
                    for (int i = c; i < list.Length; i++)
                    {
                        try
                        {
                            list[i] = list[i + 1];
                        }
                        catch
                        {
                            Lenght--;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public bool Insert(int index, T item)
        {
            if (index < list.Length)
            {
                if (Lenght + 1 > capaсity)
                {

                    Array.Resize<T>(ref list, capaсity * 2);
                }
                T element = default;
                for (int i = index; i < list.Length; i++)
                {
                    element = list[i];
                    list[i] = item;
                    item = element;
                }
                Lenght++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public T this[int index]
        {

            get
            {

                if (index > capaсity)
                {
                    throw new ArgumentOutOfRangeException($"The index '{nameof(index)}' is out of the array ");
                }
                else if (index < 0)
                {
                    if (index < Lenght - Lenght - Lenght)
                    {
                        throw new ArgumentOutOfRangeException($"The index '{nameof(index)}' is out of the array ");
                    }
                    return list[Lenght + index];
                }
                else
                {
                    return list[index];
                }
                // return list[index];
            }
            set
            {
                if (index > capaсity)
                {
                    throw new ArgumentOutOfRangeException($"The index '{nameof(index)}' is out of the array ");
                }
                else if (index < 0)
                {
                    if (index < Lenght - Lenght - Lenght)
                    {
                        throw new ArgumentOutOfRangeException($"The index '{nameof(index)}' is out of the array ");
                    }
                    list[Lenght + index] = value;
                }
                else
                {
                    list[index] = value;
                }

            }
        }

        public void Capacity(int capacityOverride)
        {
            this.capaсity = capacityOverride;
        }

        public T[] ToArray()
        {

            if (Lenght == 0)
            {
                return emptyArray;
            }
            T[] array = new T[Lenght];
            for (int i = 0; i < list.Length + 1; i++)
            {
                array[i] = list[i];
            }
            return array;
        }

        public object Clone()
        {
            return list.Clone();
        }
    }



    public class DynamicArrayCircle<T> : DynamicArray<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                for (int i = 0; i < Lenght; i++)
                {
                    yield return list[i];// неверно
                }
            }
        }
    }
}


