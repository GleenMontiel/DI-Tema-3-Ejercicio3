#define GAME
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    
    class Videogames
    {
        public List<Videogame> videogames = new List<Videogame>();


        public Videogames()
        {
            #if GAME
            AddNewGame(new Videogame("Call of duty cold war", 2020, eStyle.Shootemup));
            AddNewGame(new Videogame("GTA SA", 2004, eStyle.Videoaventura));
            AddNewGame(new Videogame("NBA 2K21", 2020, eStyle.Deportivo));
            #endif
        }

        public void AddNewGame(Videogame v)
        {
            this.videogames.Insert(Position(v.Year), v);
        }

        public int Position(int year)
        {
            for (int i = 0; i < this.videogames.Count(); i++)
            {
                if (this.videogames[i].Year < year)
                {
                    return i;
                }
            }
            
            return 0;
        }

        public bool Delete(int end)
        {
            end--;
            if (end < this.videogames.Count())
            {
                this.videogames.RemoveRange(0, end);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int start, int end)
        {
            start--;
          
            if (end < this.videogames.Count() && start > -1 && start != end)
            {
                this.videogames.RemoveRange(start, end);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Videogame> Search(eStyle style)
        {
            List<Videogame> videogameByStyle = new List<Videogame>();

            foreach (Videogame v in this.videogames)
            {
                if (v.Style == style)
                {
                    videogameByStyle.Add(v);
                }
            }
            return videogameByStyle;
        }

        public String CutTitle(string cad)
        {
            return cad.Length > 15 ? cad.Substring(0, 12) + "..." : cad;
        }


        public void VideogameList()
        {
            string format = "{0,-2}{1,-16}{2,-10}{3,-10}";
            int pos = 1;
            Console.WriteLine("\n"+format, "", "NAME", "YEAR", "STYLE");
            foreach (Videogame v in this.videogames)
            {
                string title = CutTitle(v.Title);
                Console.WriteLine(format, pos, title, v.Year, v.Style);
                pos++;
            }
        }

        public void VideogameList(List<Videogame> videogames)
        {
            string format = "{0,-2}{1,-16}{2,-10}{3,-10}";
            int pos = 1;
            Console.WriteLine("\n" + format, "", "NAME", "YEAR", "STYLE");
            foreach (Videogame v in videogames)
            {
                string title = CutTitle(v.Title);
                Console.WriteLine(format, pos, title, v.Year, v.Style);
                pos++;
            }
        }

        public void ModifyVideogame(int pos, int propiedad, object newValue)
        {
            pos--;
            for (int i = 0; i < this.videogames.Count(); i++)
            {
                if (pos == i)
                {
                    this.videogames[i].Title = propiedad == 1 ? (string)newValue: this.videogames[i].Title;
                    this.videogames[i].Year = propiedad == 2 ? (int)newValue : this.videogames[i].Year;
                    this.videogames[i].Style = propiedad == 3 ? (eStyle)newValue : this.videogames[i].Style;
                }
            }
        }
    }
}
