using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RolePlayingGame.World.GridBased;

namespace RolePlayingGame.World
{
    public class Test
    {
        [STAThread]
        static void Main(string[] args)
        {
            Grid a = new Grid();
            Grid b = new Grid();
            GridArea area = new GridArea(a, b);
            area.Start.X = 5;
            area.Start.Y = 5;
            area.End.X = -1;
            area.End.Y = -1;

            GridMatrix<Grid> g = new GridMatrix<Grid>();
            g.AddElement(a);
            g.AddElement(b);
            bool addDuplicate = g.AddElement(a);
            g.RemoveElement(a);
            g.GetArea();
            GridArea size = g.GetArea();
            bool hasGrid = g.HasElement(new Grid());

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }
    }
}
