using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
	/// <summary>
	/// Информация
	/// </summary>
	public static class Info
	{
#region Типы областей
		/// <summary>
		/// Тип области
		/// </summary>
		public enum eSurroundingType//+++ TODO сделать нормальные названия
		{
			/// <summary>
			/// 4 соседа
			/// </summary>
			Type1,
			/// <summary>
			/// 8 соседей
			/// </summary>
			Type2
		}
		private static List<string> _surroundingNames = new List<string>();
		/// <summary>
		/// Названия имеющихся правил
		/// </summary>
		public static List<string> SurroundingNames
		{
			get { return _surroundingNames; }
		}
#endregion
#region Правила
		/// <summary>
		/// Имеющиеся правила
		/// </summary>
		public enum eRules
		{
			Life
		}

		private static List<string> _ruleNames = new List<string>();
		/// <summary>
		/// Названия имеющихся правил
		/// </summary>
		public static List<string> RuleNames
		{
			get { return _ruleNames; }
		}
#endregion
		/// <summary>
		/// Конструктор
		/// </summary>
		static Info()
		{
			_ruleNames.Add("Игра жизнь");

			_surroundingNames.Add("4 соседа");
			_surroundingNames.Add("8 соседей");
		}

		/// <summary>
		/// Создать правило
		/// </summary>
		/// <param name="rule"></param>
		/// <returns></returns>
		public static IRule Rule(eRules rule)
		{
			switch (rule)
			{
					case eRules.Life:
						return new RuleLife();
					break;
				default:
					return null;
			}
		}
	}
}
