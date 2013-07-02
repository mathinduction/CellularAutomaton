using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Graphics
{
	/// <summary>
	/// Сетка
	/// </summary>
	class Grid
	{
#region Private
		private int _width = 10;
		private int _height = 10;
		private int _cellSize = 5;

		private List<List<int>> _cells = new List<List<int>>(); 
#endregion
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="width">Ширина</param>
		/// <param name="height">Высота</param>
		public Grid(int width, int height)
		{
			_width = width;
			_height = height;
		}

#region Properties
		/// <summary>
		/// Ширина
		/// </summary>
		public int Width
		{
			set
			{
				if (value <= 0)
					throw new Exception("Ширина области не может быть отрицательной!");
				_width = value;
			}

			get { return _width; }
		}

		/// <summary>
		/// Высота
		/// </summary>
		public int Height
		{
			set
			{
				if (value <= 0)
					throw new Exception("Высота области не может быть отрицательной!");
				_height = value;
			}

			get { return _height; }
		}

		/// <summary>
		/// Размер клетки
		/// </summary>
		public int CellSize
		{
			set
			{
				if (value <= 0)
					throw new Exception("Размер клетки не может быть отрицательной!");
				_cellSize = value;
			}

			get { return _cellSize; }
		}
#endregion
	}
}
