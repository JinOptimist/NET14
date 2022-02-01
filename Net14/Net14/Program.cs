using Net14.Maze;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new MazeBuilder();
            var drawer = new Drawer();


            var maze = builder.BuildSmallStandrad();
            drawer.DrawMaze(maze);
        }

        family n = new family();
        
      
        

    }
}
