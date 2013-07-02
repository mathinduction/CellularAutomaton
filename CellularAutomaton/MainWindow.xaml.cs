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
using CellularAutomaton.Automaton;

namespace CellularAutomaton
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			int [,] cells = new int[4,5];
			cells[0, 0] = 1;
			cells[1, 1] = 1;
			cells[1, 3] = 1;
			cells[1, 4] = 1;
			cells[2, 2] = 1;
			cells[2, 3] = 1;
			cells[2, 4] = 1;
			cells[3, 1] = 1;

			AutomatonLife _life = new AutomatonLife();
			cells = _life.NextState(cells);
		}

		private void buttonCreateAutomaton_Click(object sender, RoutedEventArgs e)
		{

		}

	}
}
