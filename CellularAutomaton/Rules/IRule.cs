using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
	class IRule
	{
		#region Private

		private int _stateNumber = 2;
		private eSurroundingType _surroundingType;

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
				if (value < 2)
				{
					throw new Exception("Число состояний не может быть меньше 2х!");
				}
				else
					_stateNumber = value;
			}
		}

		/// <summary>
		/// Тип области
		/// </summary>
		public eSurroundingType SurroundingType
		{
			set { _surroundingType = value; }
			get { return _surroundingType; }
		}
		#endregion

		#region Public

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

		
		#endregion

		
	}
}
