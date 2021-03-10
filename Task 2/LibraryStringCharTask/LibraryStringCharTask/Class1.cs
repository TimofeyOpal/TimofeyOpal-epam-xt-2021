using System;
using System.Collections.Generic;
using System.Linq;


namespace LibraryStringCharTask
{
  
    
        
       public class CustomChar
        {
            string[] ar;
            public int Leng;
            public CustomChar(int Size)
            {
                ar = new string[Size];
                Leng = Size;
            }

            public string this[int index]
            {
                set
                {
                    ar[index] = value;
                }
                get
                {
                    return ar[index];
                }
            }




            public string ConcatString(params string[] str)
            {
                string res = "";
                foreach (string item in str)
                {
                    res += item;
                }
                return res;
            }


            

            /// <summary>
            /// Возвращает значение есть ли такой символ в строке или нет
            /// </summary>
            public bool ContainsChar(string str, char value)
            {
                bool result = false;
                char[] arrChar = str.ToCharArray();
                foreach (var st in arrChar)
                {
                    if (st == value)
                    {
                        result = true;
                        break;
                    }
                }
                return result;
            }

            /// <summary>
            /// Возвращает массив индексов на каких индексах найдено нужное нам значение cимвола
            /// </summary>
            public int[] Find(string str, char oneStr)
            {
                char[] stringCharArr = str.ToCharArray();
                List<int> ListIndex = new List<int>();
                int currentIndex = -1;
                foreach (var st in stringCharArr)
                {
                    currentIndex++;
                    if (st == oneStr)
                    {
                        ListIndex.Add(currentIndex);
                    }
                }
                int[] indices = ListIndex.ToArray();
                return indices;
            }


            public string ConvertToString(char[] str)
            {
                return string.Join("", str);
            }

            public char[] ConvertToArray(string str)
            {
                return str.ToCharArray();
            }
            public string DeleteEmpty(string str)
            {
                char[] arr = str.ToCharArray();
                var list = arr.Cast<char>().ToList();
                int index = -1;
                foreach (char item in list)
                {
                    index++;
                    if (item == ' ')
                        list.RemoveAt(index);
                }
                return string.Join("", list);
            }


        }


    
}
