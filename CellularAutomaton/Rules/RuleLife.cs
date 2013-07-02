using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
	/// <summary>
	/// Игра "жизнь"
	/// </summary>
	public class RuleLife: IRule
	{
		public override int TransformCell(int[,] cells, int i, int j)
		{
			int centerCell = cells[i, j];
			int countAlive = CountSurrounding(cells, i, j);

			if (centerCell == 1)//Если центральная клетка жива
			{
				if (countAlive > 3 || countAlive < 2)//Если у живой клетки больше 3х или меньше 2х живых соседа, то она умирает
					return 0;
			}
			if (centerCell == 0)//Если центральная клетка мертва
			{
				if (countAlive == 3)
					return 1;//Если у мёртвой клетки ровно 3 живых соседа, то в клетке зарождается жизнь
			}
			return centerCell;
		}
	}
}
