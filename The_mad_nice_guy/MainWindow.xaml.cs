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
using System.IO;

namespace The_mad_nice_guy
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Game_scenario> game_scenario_list = new List<Game_scenario>();
        public static bool in_game = false;
        public static bool entered = false;
        List<int> the_byte = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> request_byte = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        int reveal_counter = 0;
        public MainWindow()
        {
            //try
            //{
                InitializeComponent();
                main_game_canvas.Visibility = Visibility.Collapsed;
                main_menu.Visibility = Visibility.Visible;
                Lang_handler.default_texts();
                about_text.Text = "Creator list:\n  Chan Yat Chu Sunny (Programmer)\n   Jammie Chan (Artist)\n  Kyle Ng (Artist)\n   SOSYBOI (Tester)\n   Lam (Tester)\n\n    Contact email: chanyatchunsunny@gmail.com\n\n\n\n\n\n\nThis is a very short game about you being a mad nice guy that like to help others, an average gameplay should take only around 5 minutes to finish";
                main_menu_start_game_button.Content = Lang_handler.texts_list.Find(x => x.text_name == "main_menu_start_text").the_text;
                main_menu_quit_game_button.Content = Lang_handler.texts_list.Find(x => x.text_name == "main_menu_quit_text").the_text;
                main_menu_about_button.Content = Lang_handler.texts_list.Find(x => x.text_name == "main_menu_about_text").the_text;
                back_to_main_menu_button.Content = Lang_handler.texts_list.Find(x => x.text_name == "back_to_main_menu_text").the_text;
            init_scenario_list();
           //}

           // catch (Exception e)
           // {

            //}
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
            switch (e.Key.ToString())
            {
                case "A":
                    if (in_game && !going)
                    {
                        go_to_direction(direction.left);
                    }
                    break;
                case "D":
                    if (in_game && !going)
                    {
                        go_to_direction(direction.right);
                    }
                    break;
                case "W":
                    if (in_game && !going)
                    {
                        go_to_direction(direction.up);
                    }
                    break;
                case "S":
                    if (in_game && !going)
                    {
                        go_to_direction(direction.down);
                    }
                    break;
                case "Return":
                    entered = true;
                    break;
            }
        }


        private void init_scenario_list()
        {
            game_scenario_list.Add(new Game_scenario());
            //Blind person left his wallet on the other side of the road
            game_scenario_list[0].NPC_list = new List<NPC> { new NPC(new XY(500, 150), "blind_idle.png", "", "") };
            game_scenario_list[0].boarder_bottom = 550;
            game_scenario_list[0].boarder_top = 110;
            game_scenario_list[0].boarder_left = 0;
            game_scenario_list[0].boarder_right = 1000;
            game_scenario_list[0].start_x = 300;
            game_scenario_list[0].start_y = 150;
            game_scenario_list[0].move_y = 350;
            game_scenario_list[0].actual_action_images = new List<String> { "scenario0-0.png", "scenario0-1.png", "scenario0-2.png", "scenario0-3.png", "scenario0-4.png", "scenario0-5.png" };

            game_scenario_list[0].start_text = new List<String> { "You are Sammy, and you knew you must help people around you",
                "Because you are a nice guy that want to help others and see the smile of others",
                "There seems to be a blind person in distress, let's help him!!"};

            game_scenario_list[0].before_start_action_text = new List<String> { "[The blind person] Arr... Where is my wallet?...",
                "It seems that he left his wallet on the other side of the road, \nset your brain on the top right corner to help him!"};

            game_scenario_list[0].after_start_action_text = new List<String> {"[Sammy] Sir, you left your wallet on the other side of the road!",
            "[Sammy] Let's me go help you fetch it back!", "[The blind person] Thank you, kind stranger."};

            game_scenario_list[0].end_text = new List<String> { "This will only be one of many people you are going to help",
            "Now continue helping others."};

            //An old lady needs to deliver meal to her son
            game_scenario_list.Add(new Game_scenario());
            game_scenario_list[1].NPC_list = new List<NPC> { new NPC(new XY(800, 320), "old_idle.png", "", "") };
            game_scenario_list[1].boarder_bottom = 320;
            game_scenario_list[1].boarder_top = 250;
            game_scenario_list[1].boarder_left = 0;
            game_scenario_list[1].boarder_right = 1000;
            game_scenario_list[1].start_x = 900;
            game_scenario_list[1].start_y = 320;
            game_scenario_list[1].move_x = -800;
            game_scenario_list[1].actual_action_images = new List<String> { "scenario1-0.png", "scenario1-1.png", "scenario1-2.png", "scenario1-3.png", "scenario1-4.png" };
            game_scenario_list[1].start_text = new List<String> { "Hmm, that old woman may need help, approach her to ask how you can help her!" };

            game_scenario_list[1].before_start_action_text = new List<String> {"[Sammy] Hello, is there anything I can help you?",
            "[The old woman] Oh, well, actually I am just about to deliver the basket of meal",
             "to my son across the river, maybe you can help me?",
            "[A demonic voice] Hey, do you want to see the truth?\n Enter the opposite of what you supposed to do to reveal the truth!"};

            game_scenario_list[1].after_start_action_text = new List<String> { "[Sammy] Of course, I can do that! Let's me help you!" };

            game_scenario_list[1].end_text = new List<String> { "Great job! You had bring the nice meal to her son!",
                "You may now process."};

            //Water the garden

            game_scenario_list.Add(new Game_scenario());
            game_scenario_list[2].NPC_list = new List<NPC> { new NPC(new XY(800, 260), "water.png", "", "") };
            game_scenario_list[2].boarder_bottom = 280;
            game_scenario_list[2].boarder_top = 180;
            game_scenario_list[2].boarder_left = 0;
            game_scenario_list[2].boarder_right = 1000;
            game_scenario_list[2].start_x = 900;
            game_scenario_list[2].start_y = 260;
            game_scenario_list[2].move_x = -800;
            game_scenario_list[1].actual_action_images = new List<String> { "scenario2-0.png", "scenario2-1.png", "scenario2-2.png", "scenario2-3.png", "scenario2-4.png", "scenario2-5.png", "scenario2-6.png", "scenario2-7.png", "scenario2-8.png" };
            game_scenario_list[2].start_text = new List<String> { "Well, even the flowers may need someone to help them!",
                "Collect the water and share with them!",
                "Anyway, do not listen to the other voice, this is definitely the reality!"};

            game_scenario_list[2].before_start_action_text = new List<String> { "Come on! You need stop and face the truth! You need to get some help!" };
            game_scenario_list[2].after_start_action_text = new List<String> { "" };
            game_scenario_list[2].end_text = new List<String> { "Great! You even saved the flowers!", "Now face the consequence!" };

        }

        int process;
        int progress_in_process = 0;
        string Sammy_good_standing = "Sammy_good_idle.png";
        string Sammy_good_walking_a = "Sammy_good_walk1.png";
        string Sammy_good_walking_b = "Sammy_good_walk2.png";
        Image Sammy_image;
        public void start_game()
        {
            process = 0;
            build_env();
            in_game = true;
            build_scenario();
        }
        public void build_env()
        {
            Bitmap Sammy_good_standing_bit = new Bitmap("resources/" + Sammy_good_standing);
            Bitmap Sammy_good_walking_a_bit = new Bitmap("resources/" + Sammy_good_walking_a);
            Bitmap Sammy_good_walking_b_bit = new Bitmap("resources/" + Sammy_good_walking_b);
            Sammy_image = new Image();
            Sammy_image.Width = 45;
            Sammy_image.Height = 45;
            Sammy_image.HorizontalAlignment = HorizontalAlignment.Left;
            Sammy_image.VerticalAlignment = VerticalAlignment.Top;
            Sammy_image.Margin = new Thickness(60, 250, 0, 0);
            Sammy_image.Name = "Sammy_image_control";
            Sammy_image.Source = shorter.bm_source(Sammy_good_standing_bit);
            main_game_canvas.Children.Add(Sammy_image);

        }
        List<Image> NPC_images_list = new List<Image>();
        public async void build_scenario()
        {

            going = true;

            main_game_switches_panel.Visibility = Visibility.Collapsed;
            for (int i = 0; i < NPC_images_list.Count; i++)
            {
                NPC_images_list[i].Visibility = Visibility.Collapsed;
            }
            NPC_images_list.Clear();
            if (process <= 2)
            {
                progress_in_process = 0;
                Sammy_image.Margin = new Thickness(game_scenario_list[process].start_x, game_scenario_list[process].start_y, 0, 0);
                Bitmap BG_bit = new Bitmap("resources/scenario" + process.ToString() + ".png");
                main_game_image.Source = shorter.bm_source(BG_bit);
                for (int i = 0; i < game_scenario_list[process].NPC_list.Count; i++)
                {
                    Bitmap temp_bm = new Bitmap("resources/" + game_scenario_list[process].NPC_list[i].left_standing);
                    Image temp_image = new Image();
                    temp_image.Width = 45;
                    temp_image.Height = 45;
                    temp_image.HorizontalAlignment = HorizontalAlignment.Left;
                    temp_image.VerticalAlignment = VerticalAlignment.Top;
                    temp_image.Margin = new Thickness(game_scenario_list[process].NPC_list[i].start_xy.x, game_scenario_list[process].NPC_list[i].start_xy.y, 0, 0);
                    temp_image.Name = "Sammy_image_control";
                    temp_image.Source = shorter.bm_source(temp_bm);
                    NPC_images_list.Add(temp_image);
                    main_game_canvas.Children.Add(temp_image);

                }
                main_game_text_output.Visibility = Visibility.Visible;
                for (int i = 0; i < game_scenario_list[process].start_text.Count; i++)
                {
                    main_game_text_output.Content = game_scenario_list[process].start_text[i];
                    await Task.Delay(3000);
                }
                main_game_text_output.Visibility = Visibility.Collapsed;
                going = false;
            }
            else
            {
                main_game_text_output.Visibility = Visibility.Collapsed;

                if(reveal_counter < 2)
                {
                    if (!File.Exists("resources/bad_end.png"))
                        System.IO.Compression.ZipFile.ExtractToDirectory("resources/bad_end.data", "resources");
                    Bitmap BG_bit = new Bitmap("resources/bad_end.png");
                    main_game_image.Source = shorter.bm_source(BG_bit);

                }
                else
                {
                    if (!File.Exists("resources/good_end.png"))
                        System.IO.Compression.ZipFile.ExtractToDirectory("resources/good_end.data", "resources");
                    Bitmap BG_bit = new Bitmap("resources/good_end.png");
                    main_game_image.Source = shorter.bm_source(BG_bit);
                }
            }
        }
        enum direction
        {
            left,
            right,
            up,
            down,
        }

        async
        Task
go_to_direction(direction dir)
        {
            going = true;
            Bitmap Sammy_good_standing_bit = new Bitmap("resources/" + Sammy_good_standing);
            Bitmap Sammy_good_walking_a_bit = new Bitmap("resources/" + Sammy_good_walking_a);
            Bitmap Sammy_good_walking_b_bit = new Bitmap("resources/" + Sammy_good_walking_b);

            if (dir == direction.right)
            {
                if (Sammy_image.Margin.Left < game_scenario_list[process].boarder_right)
                {
                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left + 5, Sammy_image.Margin.Top, 0, 0);
                    Sammy_good_walking_a_bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_a_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(150);

                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left + 5, Sammy_image.Margin.Top, 0, 0);
                    Sammy_good_walking_b_bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_b_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(150);
                }
                Sammy_good_standing_bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Sammy_image.Source = shorter.bm_source(Sammy_good_standing_bit);
                Sammy_image.UpdateLayout();
                main_game_canvas.UpdateLayout();
            }
            else if (dir == direction.left)
            {
                if (Sammy_image.Margin.Left > game_scenario_list[process].boarder_left)
                {
                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left - 5, Sammy_image.Margin.Top, 0, 0);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_a_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(150);

                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left - 5, Sammy_image.Margin.Top, 0, 0);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_b_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(150);


                }
                Sammy_image.Source = shorter.bm_source(Sammy_good_standing_bit);
                Sammy_image.UpdateLayout();
                main_game_canvas.UpdateLayout();
            }
            else if (dir == direction.up)
            {
                if (Sammy_image.Margin.Top > game_scenario_list[process].boarder_top)
                {
                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left, Sammy_image.Margin.Top - 5, 0, 0);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_a_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(200);

                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left, Sammy_image.Margin.Top - 5, 0, 0);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_b_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(200);


                }
                Sammy_image.Source = shorter.bm_source(Sammy_good_standing_bit);
                Sammy_image.UpdateLayout();
                main_game_canvas.UpdateLayout();

            }
            else
            {
                if (Sammy_image.Margin.Top < game_scenario_list[process].boarder_bottom)
                {
                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left, Sammy_image.Margin.Top + 5, 0, 0);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_a_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(150);

                    Sammy_image.Margin = new Thickness(Sammy_image.Margin.Left, Sammy_image.Margin.Top + 5, 0, 0);
                    Sammy_image.Source = shorter.bm_source(Sammy_good_walking_b_bit);
                    Sammy_image.UpdateLayout();
                    main_game_canvas.UpdateLayout();
                    await Task.Delay(150);


                }
                Sammy_image.Source = shorter.bm_source(Sammy_good_standing_bit);
                Sammy_image.UpdateLayout();
                main_game_canvas.UpdateLayout();
            }
            double x1 = Sammy_image.Margin.Left;
            double y1 = Sammy_image.Margin.Top;
            double x2 = game_scenario_list[process].NPC_list[game_scenario_list[process].target_NPC].start_xy.x;
            double y2 = game_scenario_list[process].NPC_list[game_scenario_list[process].target_NPC].start_xy.y;
            if (Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)) <= 10 && progress_in_process == 0)//distance to target NPC
            {
                going = false;
                progress_in_process += 1;
                //before_start_action_text
                main_game_text_output.Visibility = Visibility.Visible;
                for (int i = 0; i < game_scenario_list[process].before_start_action_text.Count; i++)
                {
                    main_game_text_output.Content = game_scenario_list[process].before_start_action_text[i];
                    await Task.Delay(3000);
                }
                //puzzle
                main_game_switches_panel.Visibility = Visibility.Visible;
                switch1.Content = the_byte[0].ToString();
                switch2.Content = the_byte[1].ToString();
                switch3.Content = the_byte[2].ToString();
                switch4.Content = the_byte[3].ToString();
                switch5.Content = the_byte[4].ToString();
                switch6.Content = the_byte[5].ToString();
                switch7.Content = the_byte[6].ToString();
                switch8.Content = the_byte[7].ToString();
                string temp_text = "";
                Random ran = new Random(System.DateTime.Now.Millisecond);
                for (int i = 0; i < 8; i++)
                {
                    request_byte[i] = ran.Next(0, 2);
                    temp_text += request_byte[i];
                }
                request_label.Content = temp_text;


            }

            going = false;
        }

        async void do_game_good_action()
        {
            //after start action text
            main_game_text_output.Visibility = Visibility.Visible;
            for (int i = 0; i < game_scenario_list[process].after_start_action_text.Count; i++)
            {
                main_game_text_output.Content = game_scenario_list[process].after_start_action_text[i];
                await Task.Delay(3000);
            }
            main_game_text_output.Visibility = Visibility.Collapsed;
            //move x
            if (game_scenario_list[process].move_x > 0)
            {
                for (int i = 0; i < game_scenario_list[process].move_x; i += 10)
                {
                    await go_to_direction(direction.right);
                }
            }
            else if (game_scenario_list[process].move_x < 0)
            {
                for (int i = 0; i > game_scenario_list[process].move_x; i -= 10)
                {
                    await go_to_direction(direction.left);
                }
            }

            //move y
            if (game_scenario_list[process].move_y > 0)
            {
                for (int i = 0; i < game_scenario_list[process].move_y; i += 10)
                {
                    await go_to_direction(direction.down);
                }
            }
            else if (game_scenario_list[process].move_y < 0)
            {
                for (int i = 0; i > game_scenario_list[process].move_y; i -= 10)
                {
                    await go_to_direction(direction.up);
                }
            }

            main_game_text_output.Visibility = Visibility.Visible;
            for (int i = 0; i < game_scenario_list[process].end_text.Count; i++)
            {

                main_game_text_output.Content = game_scenario_list[process].end_text[i];
                await Task.Delay(3000);
            }
            //entered = false;
            //while (!entered) { 
            // }
            process++;
            build_scenario();
        }
        async void do_game_bad_action()
        {
            main_game_text_output.Visibility = Visibility.Collapsed;
            main_game_switches_panel.Visibility = Visibility.Collapsed;
            Sammy_image.Visibility = Visibility.Collapsed;
            for (int i = 0;i < NPC_images_list.Count; i++)
            {
                NPC_images_list[i].Visibility = Visibility.Collapsed;
            }
            NPC_images_list.Clear();
            if(!File.Exists("resources/" + game_scenario_list[process].actual_action_images[0]))
                System.IO.Compression.ZipFile.ExtractToDirectory("resources/scenario" + process.ToString() + ".data", "resources");

            for (int i = 0; i < game_scenario_list[process].actual_action_images.Count; i++)
            {
                Bitmap temp_bitmap = new Bitmap("resources/" + game_scenario_list[process].actual_action_images[i]);
                main_game_image.Source = shorter.bm_source(temp_bitmap);
                
                await Task.Delay(800);
                
            }
            //entered = false;
            //while (!entered)
            //{
            // }
            reveal_counter++;
            process++;
            build_scenario();
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[0] == 0)
            {
                the_byte[0] = 1;
            }
            else { the_byte[0] = 0; }
            switch1.Content = the_byte[0].ToString();
        }

        private void switch2_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[1] == 0)
            {
                the_byte[1] = 1;
            }
            else { the_byte[1] = 0; }
            switch2.Content = the_byte[1].ToString();
        }

        private void switch3_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[2] == 0)
            {
                the_byte[2] = 1;
            }
            else { the_byte[2] = 0; }
            switch3.Content = the_byte[2].ToString();
        }

        private void switch4_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[3] == 0)
            {
                the_byte[3] = 1;
            }
            else { the_byte[3] = 0; }
            switch4.Content = the_byte[3].ToString();
        }

        private void switch5_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[4] == 0)
            {
                the_byte[4] = 1;
            }
            else { the_byte[4] = 0; }
            switch5.Content = the_byte[4].ToString();
        }

        private void switch6_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[5] == 0)
            {
                the_byte[5] = 1;
            }
            else { the_byte[5] = 0; }
            switch6.Content = the_byte[5].ToString();
        }

        private void switch7_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[6] == 0)
            {
                the_byte[6] = 1;
            }
            else { the_byte[6] = 0; }
            switch7.Content = the_byte[6].ToString();
        }

        private void switch8_Click(object sender, RoutedEventArgs e)
        {
            if (the_byte[7] == 0)
            {
                the_byte[7] = 1;
            }
            else { the_byte[7] = 0; }
            switch8.Content = the_byte[7].ToString();

        }

        private void execute_button_Click(object sender, RoutedEventArgs e)
        {
            int true_counter = 0;
            for (int i = 0; i < 8; i++)
            {
                if (the_byte[i] == request_byte[i])
                {
                    true_counter++;
                }
            }
            if (true_counter == 8)
            {
                do_game_good_action();
            }
            else if (true_counter == 0)
            {
                do_game_bad_action();
            }
        }

        private void main_menu_about_button_Click(object sender, RoutedEventArgs e)
        {
            main_menu.Visibility = Visibility.Collapsed;
            about_page.Visibility = Visibility.Visible;
        }

        private void back_to_main_menu_button_Click(object sender, RoutedEventArgs e)
        {
            about_page.Visibility = Visibility.Collapsed;
            main_menu.Visibility = Visibility.Visible;
        }
    }
    public class shorter
    {
        public static BitmapSource bm_source(Bitmap bm)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

    }
}
