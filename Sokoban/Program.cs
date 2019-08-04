using System;
using Sokoban.Controller;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Service s = new Service();
            s.StartUp();
        }
    }
}