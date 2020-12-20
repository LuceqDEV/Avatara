﻿using Avatara;
using Avatara.Figure;
using System;
using System.IO;

namespace AvataraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FigureExtractor.Parse();
                FigureExtractor.Parse();
                FigureExtractor.Parse();

                var Parts = FigureExtractor.Parts;

                var figuredataReader = new FiguredataReader();
                figuredataReader.LoadFigurePalettes();
                figuredataReader.loadFigureSetTypes();
                figuredataReader.LoadFigureSets();

                string figure = "hd-180-1.hr-100-.ch-260-62.lg-275-64.ha-1008-.ea-1402-.ca-1806-73";
                Console.WriteLine("Parsing: " + figure);

                var avatar = new Avatar(figure, false, 5, 5, figuredataReader, "std");
                File.WriteAllBytes("temp5.png", avatar.Run());

                avatar = new Avatar(figure, false, 1, 1, figuredataReader, "std");
                File.WriteAllBytes("temp1.png", avatar.Run());

                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.Read();
        }
    }
}
