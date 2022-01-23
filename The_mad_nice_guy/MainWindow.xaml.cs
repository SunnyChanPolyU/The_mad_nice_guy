using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Windows.Controls.Image;

namespace The_mad_nice_guy
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Game_scenario> game_scenario_list = new List<Game_scenario>();
        public static bool in_game = false;
        public MainWindow()
        {
            InitializeComponent();
            main_game_canvas.Visibility = Visibility.Collapsed;
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
            main_menu.Visibility = Visibility.Collapsed;
            main_game_canvas.Visibility = Visibility.Visible;
            start_game();
        }
        bool going = false;
        private void main_window_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Key);
            if (e.Key.ToString() == "A")
            {
                if (in_game && !going)
                {
                    go_to_direction(direction.left);
                }

            }
            else if (e.Key.ToString() == "D") {
                if (in_game && !going)
                {
                    go_to_direction(direction.right);
                }
            }
        }


        private void init_scenario_list()
        {

        }

        int process;
        string Sammy_good_standing = "Sammy_good_idle.png";
        string Sammy_good_walking_a = "Sammy_good_walk1.png";
        string Sammy_good_walking_b = "Sammy_good_walk2.png";
        Image Sammy_image;
        public void start_game()
        {
            process = 0;
            build_env();
            in_game = true;
        }
        public void build_env()
        {
            Bitmap Sammy_good_standing_bit = new Bitmap("resources/"+Sammy_good_standing);
            Bitmap Sammy_good_walking_a_bit = new Bitmap("resources/" + Sammy_good_walking_a);
            Bitmap Sammy_good_walking_b_bit = new Bitmap("resources/" + Sammy_good_walking_b);
            Sammy_image = new Image();
            Sammy_image.Width = 45;
            Sammy_image.Height = 45;
            Sammy_image.HorizontalAlignment = HorizontalAlignment.Left;
            Sammy_image.VerticalAlignment = VerticalAlignment.Top;
            Sammy_image.Margin = new Thickness(20, 250, 0, 0);
            Sammy_image.Name = "Sammy_image_control";
            Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_standing_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            main_game_canvas.Children.Add(Sammy_image);

        }
        enum direction
        {
            left,
            right,
        }
        async void go_to_direction(direction dir) {
            going = true;
            Bitmap Sammy_good_standing_bit = new Bitmap("resources/" + Sammy_good_standing);
            Bitmap Sammy_good_walking_a_bit = new Bitmap("resources/" + Sammy_good_walking_a);
            Bitmap Sammy_good_walking_b_bit = new Bitmap("resources/" + Sammy_good_walking_b);

            if (dir == direction.right)
            {
                if(Sammy_image.Margin.Left < 970)
                {
                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left + 5, 250, 0, 0);
                    Sammy_good_walking_a_bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_walking_a_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(100);

                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left + 5, 250, 0, 0);
                    Sammy_good_walking_b_bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_walking_b_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(100);
                }
                Sammy_good_standing_bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_standing_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                Sammy_image.UpdateLayout();
                main_game_canvas.UpdateLayout();
            }
            else
            {
                if (Sammy_image.Margin.Left > 10)
                {
                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left - 4, 250, 0, 0);
                    Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_walking_a_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(100);

                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left - 5, 250, 0, 0);
                    Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_walking_b_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(100);


                }
                Sammy_image.Source = Imaging.CreateBitmapSourceFromHBitmap(Sammy_good_standing_bit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                Sammy_image.UpdateLayout();
                main_game_canvas.UpdateLayout();
            }

            going = false;
        }
    }
    public class Main_game_handler
    {

    }
}
