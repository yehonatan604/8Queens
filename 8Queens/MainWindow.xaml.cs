using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _8Queens
{
    public partial class MainWindow : Window
    {
        public  MainViewModel Board = new();
        public Image[,]? AllImages;

        public MainWindow()
        {
            InitializeComponent();

            AllImages = new Image[8, 8]
            { { pic1_1, pic1_2, pic1_3, pic1_4, pic1_5, pic1_6, pic1_7, pic1_8 },
              { pic2_1, pic2_2, pic2_3, pic2_4, pic2_5, pic2_6, pic2_7, pic2_8 },
              { pic3_1, pic3_2, pic3_3, pic3_4, pic3_5, pic3_6, pic3_7, pic3_8 },
              { pic4_1, pic4_2, pic4_3, pic4_4, pic4_5, pic4_6, pic4_7, pic4_8 },
              { pic5_1, pic5_2, pic5_3, pic5_4, pic5_5, pic5_6, pic5_7, pic5_8 },
              { pic6_1, pic6_2, pic6_3, pic6_4, pic6_5, pic6_6, pic6_7, pic6_8 },
              { pic7_1, pic7_2, pic7_3, pic7_4, pic7_5, pic7_6, pic7_7, pic7_8 },
              { pic8_1, pic8_2, pic8_3, pic8_4, pic8_5, pic8_6, pic8_7, pic8_8 } };
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Board.Solve(0);

            foreach (List<Cell> cells in Board.CellBoard)
            {
                foreach (Cell c in cells)
                {
                    if (c.Value == 1 && AllImages != null)
                    {
                        AllImages[Board.CellBoard.IndexOf(cells), cells.IndexOf(c)].Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}
