using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Automaton
{
	/// <summary>
	/// Игра "жизнь"
	/// </summary>
	public class AutomatonLife :IAutomaton
	{
		public override int TransformCell(int northWestCell, int northCell, int northEastCell, int westCell, int centerCell,
										  int eastCell, int southWestCell, int southCell, int southEastCell)
		{
			int countAlive = northWestCell + northCell + northEastCell + 
								westCell + eastCell + 
								southWestCell + southCell + southEastCell; //Число живых соседей
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
