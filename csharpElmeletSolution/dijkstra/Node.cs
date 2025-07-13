using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dijkstra;

namespace dijkstra
{
    internal class Node
    {
        private string _name;
        /// <summary>
        /// csomópont neve, amely nem lehet üres vagy csak szóközökből álló karakterlánc.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A csomópont neve nem lehet üres vagy csak szóközökből álló karakterlánc.", nameof(Name));
                }
                _name = value;
            }
        }
        private long _x;
        /// <summary>
        /// A csomópont x (horizontális) koordinátája, amely nem lehet negatív érték.
        /// </summary>
        public long x
        {
            get { return _x; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Az 'x' érték nem lehet negatív.", nameof(x));
                }
                _x = value;
            }
        }
        private long _y;

        /// <summary>
        /// A csomópont y (vertikális) koordinátája, amely nem lehet negatív érték.
        /// </summary>
        public long y
        {
            get { return _y; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Az 'y' érték nem lehet negatív.", nameof(y));
                }
                _y = value;
            }
        }
        public Node(string name, long x, long y)
        {
            this._name = name;
            this._x = x;
            this._y = y;
        }

        public Node(String line)
        {
            string[] adatok = line.Split(',');
            if (adatok.Length < 3)
            {
                throw new FormatException("A csúcsok fájl formátuma érvénytelen. Minden sor három értéket kell tartalmazzon: név, x, y.");
            }

            this._name = adatok[0].Trim();
            this._x = long.Parse(adatok[1].Trim());
            this._y = long.Parse(adatok[2].Trim());
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
