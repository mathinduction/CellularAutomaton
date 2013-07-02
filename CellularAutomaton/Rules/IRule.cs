using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
	public abstract class IRule
	{
		#region Private and Protected

		protected int _stateNumber = 2;
		protected bool _stateNumberChangeable = true;
		protected Info.eSurroundingType _surroundingType = Info.eSurroundingType.Type1;
		protected bool _surroundingTypeChangeable = true;

		#endregion

		#region Properties
		/// <summary>
		/// Число состояний (должно быть не меньше 2х).
		/// </summary>
		public int StateNumber
		{
			get { return _stateNumber; }
			set
			{
				if (!_stateNumberChangeable)
				{
					throw new Exception("Нельзя изменить число состояний!");
				}
				if (value < 2)
				{
					throw new Exception("Число состояний не может быть меньше 2х!");
				}
				_stateNumber = value;
			}
		}

		/// <summary>
		/// Тип области
		/// </summary>
		public Info.eSurroundingType SurroundingType
		{
			set { _surroundingType = value; }
			get { return _surroundingType; }
		}
		#endregion

		#region Public

		/// <summary>
		/// Метод для трансформации всех клеток поля
		/// </summary>
		public int[,] NextState(int[,] cells)
		{
			int length0 = cells.GetLength(0), length1 = cells.GetLength(1);
			int[,] newCells = new int[length0, length1];

			for (int i = 0; i < length0; i++)
			{
				for (int j = 0; j < length1; j++)
				{
					newCells[i, j] = TransformCell(cells, i, j);
				}
			}
			return newCells;
		}

		/// <summary>
		/// Метод для преобразования клетки с учётом её текущего состояния и состояния всех её соседей
		/// </summary>
		public abstract int TransformCell(int[,] cells, int i, int j);

		#endregion

		/// <summary>
		/// Подсчитывает сумму состояний окружения
		/// </summary>
		/// <returns></returns>
		protected int CountSurrounding(int[,] cells, int i, int j)
		{
			int length0 = cells.GetLength(0), length1 = cells.GetLength(1);
			int jWest = (j - 1 + length1) % length1;
			int jEast = (j + 1) % length1;
			int iNorth = (i - 1 + length0) % length0;
			int iSouth = (i + 1) % length0;

			if (_surroundingType == Info.eSurroundingType.Type1)
			{
				int northCell = cells[iNorth, j];
				int westCell = cells[i, jWest];
				int eastCell = cells[i, jEast];
				int southCell = cells[iSouth, j];

				return northCell + westCell + eastCell + southCell;
			}
			else
			{
				int northWestCell = cells[iNorth, jWest];
				int northCell = cells[iNorth, j];
				int northEastCell = cells[iNorth, jEast];

				int westCell = cells[i, jWest];
				int eastCell = cells[i, jEast];

				int southWestCell = cells[iSouth, jWest];
				int southCell = cells[iSouth, j];
				int southEastCell = cells[iSouth, jEast];

				return northWestCell + northCell + northEastCell +
				       westCell + eastCell + southWestCell + southCell + southEastCell;
			}
		}
		
	}
}
