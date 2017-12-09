using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielomiany
{
    public class Wielomian<T> : ICloneable, IComparable where T : IComparable
    {
        private T[] wspolczynniki { get; set; }

        public Wielomian(T[] wspolczynniki)
        {
            this.wspolczynniki = wspolczynniki;
        }

        public T GetValue(T argument)
        {
            T value = (dynamic) 0;
            for(int i=0;i<this.wspolczynniki.Length;i++)
            {
                value += (dynamic) Math.Pow((dynamic)argument, i + 1) * this.wspolczynniki[i];
            }
            return value;
        }

        public static Wielomian<T> operator -(Wielomian<T> wielomianPierwszy, Wielomian<T> wielomianDrugi)
        {
            Wielomian<T> dluzszyWielomian, krotszyWielomian;
            if (wielomianPierwszy.wspolczynniki.Length > wielomianDrugi.wspolczynniki.Length)
            {
                dluzszyWielomian = wielomianPierwszy;
                krotszyWielomian = wielomianDrugi;
            }
            else
            {
                dluzszyWielomian = wielomianDrugi;
                krotszyWielomian = wielomianPierwszy;
            }
            for (int i = 0; i < krotszyWielomian.wspolczynniki.Length; i++)
            {
                dluzszyWielomian.wspolczynniki[i] -= (dynamic)krotszyWielomian.wspolczynniki[i];
            }
            return dluzszyWielomian;
        }

        public static Wielomian<T> operator +(Wielomian<T> wielomianPierwszy, Wielomian<T> wielomianDrugi)
        {
            Wielomian<T> dluzszyWielomian, krotszyWielomian;
            if (wielomianPierwszy.wspolczynniki.Length > wielomianDrugi.wspolczynniki.Length)
            {
                dluzszyWielomian = wielomianPierwszy;
                krotszyWielomian = wielomianDrugi;
            }
            else
            {
                dluzszyWielomian = wielomianDrugi;
                krotszyWielomian = wielomianPierwszy;
            }
            for (int i = 0; i < krotszyWielomian.wspolczynniki.Length; i++)
            {
                dluzszyWielomian.wspolczynniki[i] += (dynamic)krotszyWielomian.wspolczynniki[i];
            }
            return dluzszyWielomian;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.wspolczynniki.Length; i++)
            {
                builder.Append(this.wspolczynniki[i]).Append("*x^").Append(i + 1).Append("+");
            }
            builder.Length--;
            return builder.ToString();
        }

        public object Clone()
        {
            return new Wielomian<T>(this.wspolczynniki);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Wielomian<T> innyWieomian = obj as Wielomian<T>;
            if (innyWieomian != null)
                return Convert.ToInt32(this.wspolczynniki.SequenceEqual(innyWieomian.wspolczynniki));
            else
                throw new ArgumentException("Object is not a Wielomian");
        }
    }
}
