using System;
using System.Text;

namespace Gorcnakan15._03
{
    public enum Enumerate
    {
        CaseSensitive,
        ReverseComparer,
        Whitespace,
        InsensitiveComparer
    }

    public class Mystring
    {
        private int Size;
        private char[] _string;
        public int Length => _string.Length;
        public bool Empty => _string.Length == 0;

        public Mystring()
        {
            Size = 5;
            _string = new char[Size];
        }

        public Mystring(char[] str)
        {
            _string = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                _string[i] = str[i];
            }
        }

        public Mystring(string[] str)
        {
            string array = string.Join("", str);
            _string = array.ToCharArray();
        }

        public Mystring(char[] str, int index, int count)
        {
            if (index < 0 || index >= str.Length)
            {
                throw new IndexOutOfRangeException();
            }
            _string = new char[count];
            Array.Copy(str, index, _string, 0, count);
        }

        public Mystring(Mystring str, int index, int count)
        {
            if (str.Empty)
            {
                throw new ArgumentException("String is empty");
            }
            else if (index < 0 || index >= str.Length)
            {
                throw new IndexOutOfRangeException();
            }
            _string = new char[count];
            Array.Copy(str._string, index, _string, 0, count);
        }

        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                return _string[index];
            }
        }

        public static int MyCompare(Mystring a, Mystring b, Enumerate arate)
        {
            if (a.Empty || b.Empty)
            {
                throw new ArgumentException("One of these strings is empty");
            }

            int Length = a.Length <= b.Length ? a.Length : b.Length;
            string copyA = new string(a._string);
            string copyB = new string(b._string);
            switch (arate)
            {
                case Enumerate.CaseSensitive:
                    break;
                case Enumerate.ReverseComparer:
                    copyA = new string(copyA.Reverse().ToArray());
                    copyB = new string(copyB.Reverse().ToArray());
                    break;
                case Enumerate.Whitespace:
                    copyA = copyA.Trim();
                    copyB = copyB.Trim();
                    break;
                case Enumerate.InsensitiveComparer:
                    copyA = copyA.ToLower();
                    copyB = copyB.ToLower();
                    break;
                default:
                    Console.WriteLine("Invalid case");
                    throw new Exception("Invalid option");
            }

            for (int i = 0; i < Length; i++)
            {
                if (copyA[i] != copyB[i])
                {
                    return copyA[i] < copyB[i] ? -1 : 1;
                }
            }

            if (copyA.Length == copyB.Length)
            {
                return 0;
            }

            return copyA.Length < copyB.Length ? -1 : 1;
        }

        public static bool operator ==(Mystring a, Mystring b)
        {
            if (a.Empty || b.Empty)
            {
                throw new ArgumentException("One of these strings is empty");
            }

            return MyCompare(a, b, Enumerate.CaseSensitive) == 0;
        }

        public static bool operator !=(Mystring a, Mystring b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || (this.GetType() != obj.GetType()))
            {
                throw new ArgumentException("Object must be of type Mystring");
            }

            return this == (Mystring)obj;
        }

        public static bool Equals(Mystring a, Mystring b)
        {
            if (a.Empty || b.Empty)
            {
                throw new ArgumentException("One of these strings is empty");
            }

            return new string(a._string).Equals(new string(b._string));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ 11;
        }

        public static string Join(Mystring[] array, char separator)
        {
            StringBuilder substring = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Empty)
                {
                    continue;
                }

                if (i == array.Length - 1)
                {
                    substring.Append(array[i].ToString());
                    continue;
                }
                substring.Append(array[i].ToString());
                substring.Append(separator);
            }
            return substring.ToString();
        }

        public bool EndsWith(string str)
        {
            if (this.Empty)
            {
                return false;
            }

            if (_string.Length < str.Length)
            {
                Console.WriteLine("String too short");
                return false;
            }

            for (int i = _string.Length - str.Length, j = 0; j < str.Length; j++, i++)
            {
                if (str[j] != _string[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool StartsWith(string str)
        {
            if (this.Empty)
            {
                return false;
            }

            if (_string.Length < str.Length)
            {
                Console.WriteLine("String too short");
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != _string[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static Mystring operator +(Mystring a, Mystring b)
        {
            if (a.Empty || b.Empty)
            {
                throw new ArgumentException("One of these strings is empty");
            }

            string str = new string(a._string) + new string(b._string);
            return new Mystring(str.ToCharArray());
        }

        public override string ToString()
        {
            return new string(_string);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = new char[] { 'H', 'E', 'L', 'L', 'O' };
            char[] arr2 = new char[] { 'h', 'e', 'l', 'l', 'o' };
            Mystring mystring = new Mystring(arr);
            Mystring mystring1 = new Mystring(arr2);

            if (Mystring.MyCompare(mystring, mystring1, Enumerate.InsensitiveComparer) == 0)
            {
                Console.WriteLine("The strings are equal");
            }
        }
    }
}
