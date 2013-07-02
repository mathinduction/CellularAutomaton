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

		private int[,] _cells; 
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

			_cells = new int[_width, _height];
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
				_cells = new int[_width, _height];
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
				_cells = new int[_width, _height];
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

		/// <summary>
		/// Клетки
		/// </summary>
		public int[,] Cells
		{
			set { _cells = value; }
			get { return _cells; }
		}
#endregion

#region Public
		/// <summary>
		/// Нарисовать сетку
		/// </summary>
		public void DrawCells()
		{
			
		}
		/// <summary>
		/// Нарисовать сетку
		/// </summary>
		public void DrawCells(int[,] cells)
		{
			_cells = cells;
			DrawCells();
		}

		/// <summary>
		/// Заполнение сетки случайными значениями c указанными вероятностями
		/// </summary>
		public void RandomFill(List<int> values, List<double> probabilities)
		{
			if (values.Count != probabilities.Count)
				return;

			if (Math.Abs(probabilities.Sum() - 1) > 0.00001)
				return;

			double[] p = new double[probabilities.Count];
			p[0] = probabilities[0];
			for (int i = 1; i < probabilities.Count; i++)
				p[i] = p[i - 1] + probabilities[i];

			Random rnd = new Random();

			for (int i = 0; i < _cells.GetLength(0); i++)
			{
				for (int j = 0; j < _cells.GetLength(1); j++)
				{
					int k;
					double r = rnd.NextDouble();
					for (k = 0; k < p.GetLength(0); k ++)
					{
						if (r < p[k])
							break;
					}
					_cells[i, j] = values[k];
				}
			}
		}

		/// <summary>
		/// Заполнение сетки случайными значениями
		/// </summary>
		public void RandomFill(List<int> values)
		{
			List<double> probabilities = new List<double>();
			double p = 1.0/values.Count;
			for (int i = 0; i < values.Count; i++)
				probabilities.Add(p);

			RandomFill(values,probabilities);
		}
#endregion
	}
}
