using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Automaton
{
	public abstract class IAutomaton
	{
		/// <summary>
		/// Метод для трансформации всех клеток поля
		/// </summary>
		public int [,] NextState(int [,] cells)
		{
			int length0 = cells.GetLength(0), length1 = cells.GetLength(1);
			int[,] newCells = new int[length0, length1];

			for (int i = 0; i < length0; i++)
			{
				for (int j = 0; j < length1; j++)
				{
					int jWest = (j - 1 + length1) % length1;
					int jEast = (j + 1) % length1;
					int iNorth = (i - 1 + length0) % length0;
					int iSouth = (i + 1) % length0;

					int northWestCell = cells[iNorth, jWest];
					int northCell = cells[iNorth, j];
					int northEastCell = cells[iNorth, jEast];

					int westCell = cells[i, jWest];
					int centerCell = cells[i, j];
					int eastCell = cells[i, jEast];

					int southWestCell = cells[iSouth, jWest];
					int southCell = cells[iSouth, j];
					int southEastCell = cells[iSouth, jEast];

					newCells[i, j] = TransformCell(	northWestCell, northCell, northEastCell, 
									westCell, centerCell, eastCell, 
									southWestCell, southCell, southEastCell);
				}
			}
			return newCells;
		}

		/// <summary>
		/// Метод для преобразования клетки с учётом её текущего состояния и состояния всех её соседей
		/// </summary>
		public abstract int TransformCell(int northWestCell, int northCell, int northEastCell, int westCell, int centerCell,
		                                 int eastCell, int southWestCell, int southCell, int southEastCell);

	}
}
