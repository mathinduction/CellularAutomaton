using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CellularAutomaton.Rules;
using Grid = CellularAutomaton.Graphics.Grid;

namespace CellularAutomaton
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
#region Private

		/// <summary>
		/// Текущее правило
		/// </summary>
		private IRule _currentRule;

		/// <summary>
		/// Ширина области
		/// </summary>
		private int _width = 10;
		/// <summary>
		/// Высота области
		/// </summary>
		private int _height = 10;
		/// <summary>
		/// Размер клетки
		/// </summary>
		private int _cellSize = 5;

		/// <summary>
		/// Сетка
		/// </summary>
		private Graphics.Grid _grid;
#endregion
		public MainWindow()
		{
			InitializeComponent();

			_grid = new Grid(_width, _height);

			comboBoxRule.ItemsSource = Info.RuleNames;
			comboBoxRule.SelectedIndex = 0;

			comboBoxSurroundingType.ItemsSource = Info.SurroundingNames;
			comboBoxSurroundingType.SelectedIndex = 0;

			textBoxGridHeight.Text = _height.ToString();
			textBoxGridWidth.Text = _width.ToString();
			textBoxCellSize.Text = _cellSize.ToString();
		}

		private void buttonCreateAutomaton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void comboBoxRule_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_currentRule = Info.Rule((Info.eRules) comboBoxRule.SelectedIndex);
			textBoxStateNumber.Text = _currentRule.StateNumber.ToString();
			comboBoxSurroundingType.SelectedValue = _currentRule.SurroundingType;
		}

		private void comboBoxSurroundingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_currentRule.SurroundingType = (Info.eSurroundingType)comboBoxSurroundingType.SelectedIndex;
		}

	}
}
