using System.Collections.Generic;

namespace MyLib
{
    public class ShapeContainer
    {
            public static List<Figur> figureList;

            static ShapeContainer()
            {
                figureList = new List<Figur>();
            }
            public static void AddFigure(Figur figure)
            {
                figureList.Add(figure);
            }
    }
}
