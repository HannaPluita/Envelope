﻿using EnvelopesEmbeder.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvelopesEmbeder.UserUI;

namespace EnvelopesEmbeder
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            app.Run(args);

            Console.ReadKey();
        }
    }
}
