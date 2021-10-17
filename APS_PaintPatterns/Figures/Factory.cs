using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    /// <summary>
    /// Абстрактный класс фабрики
    /// </summary>
    abstract class Factory
    {
        /// <summary>
        /// Метод создания фигуры
        /// </summary>
        /// <param name="x">координата Х фигуры</param>
        /// <param name="y">координата Y фигуры</param>
        /// <param name="width">ширина фигуры</param>
        /// <param name="height">высота фигуры</param>
        /// <param name="borderColor">Цвет контура</param>
        /// <param name="bgColor">цвет заливки</param>
        /// <returns>Объект, который наследуется от абстрактного класса Figure</returns>
        public abstract Figure Create(int x, int y, int width, int height, System.Drawing.Color borderColor, System.Drawing.Color bgColor);
    }
}
