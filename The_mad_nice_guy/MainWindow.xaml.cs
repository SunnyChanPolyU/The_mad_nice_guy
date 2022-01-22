using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_mad_nice_guy
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            main_menu.Visibility = Visibility.Visible;
            Lang_handler.default_texts();
            main_menu_start_game_button.Content = Lang_handler.texts_list.Find(x => x.text_name == "main_menu_start_text").the_text;
            main_menu_quit_game_button.Content = Lang_handler.texts_list.Find(x => x.text_name == "main_menu_quit_text").the_text;
        }

        private void main_menu_quit_game_button_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void main_menu_start_game_button_Click(object sender, RoutedEventArgs e)
        {
                                    
        }

        private void main_window_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Key);
        }
    }
}
