using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_mad_nice_guy
{
    public class Lang_handler
    {
        public static List<text_pair> texts_list = new List<text_pair>();
        public static void default_texts(){
            texts_list.Add(new text_pair("main_menu_start_text", "Start game"));
            texts_list.Add(new text_pair("main_menu_quit_text", "Quit game"));
            texts_list.Add(new text_pair("main_menu_about_text", "About this game"));
            texts_list.Add(new text_pair("back_to_main_menu_text", "Main menu"));
        }
    }
    public class text_pair
    {
        public string text_name { get; set; }
        public string the_text { get; set; }

        public text_pair(string Text_name, string The_text)
        {

            text_name = Text_name;
            the_text = The_text;
        }
    }
}
