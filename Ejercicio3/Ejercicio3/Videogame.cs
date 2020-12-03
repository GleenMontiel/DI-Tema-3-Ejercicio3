using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    enum eStyle
    {
        Arcade,
        Videoaventura,
        Shootemup,
        Estrategia,
        Deportivo
    }
    class Videogame
    {
        private string title;
        public string Title
        {
            set 
            {
                title = value;
            }
            get
            {
                return title;
            }
        }
        private int year;
        public int Year
        {
            set
            {
                year = value;
            }
            get
            {
                return year;
            }
        }

        private eStyle style;
        public eStyle Style 
        {
            set 
            {
                style = value;
            }
            get 
            {
                return style;
            }
        }

        public Videogame(string title, int year, eStyle style)
        {
            this.Title = title;
            this.Year = year;
            this.Style = style;
        }
    }
}
