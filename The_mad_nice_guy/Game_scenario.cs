using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_mad_nice_guy
{
    public class Game_scenario
    {
        public List<String> start_text { get; set; }
        public List<String> before_start_action_text { get; set; }
        public List<String> after_start_action_text { get; set; }
        public List<String> end_text { get; set; }
        public int move_x { get; set; }
        public int move_y { get; set; }

        public int start_x { get; set; }
        public int start_y { get; set; }
        public int target_NPC { get; set; }
        public List<NPC> NPC_list { get; set; }
        public XY actual_action_XY { get; set; }
        public List<String> actual_action_images { get; set; }

        public int boarder_left, boarder_right, boarder_top, boarder_bottom;

        public Game_scenario(List<String> Start_text, List<String> Before_start_action_text, List<String> After_start_action_text, List<String> End_text,
            int Move_x, int Move_y, int Start_x, int Start_y, int Target_NPC, List<NPC> The_NPC_list, XY Actual_action_XY, List<String> Actual_action_images, int Boarder_left, int Boarder_right, int Boarder_top, int Boarder_bottom)
        {
            start_text = Start_text;
            before_start_action_text = Before_start_action_text;
            after_start_action_text = After_start_action_text;
            end_text = End_text;
            move_x = Move_x;
            move_y = Move_y;
            start_x = Start_x;
            start_y = Start_y;
            target_NPC = Target_NPC;
            NPC_list = The_NPC_list;
            actual_action_XY = Actual_action_XY;
            actual_action_images = Actual_action_images;
            boarder_left = Boarder_left;
            boarder_right = Boarder_left;
            boarder_top = Boarder_top;
            boarder_bottom = Boarder_bottom;

        }
        public Game_scenario()
        {

        }

    }
   public class XY
    {
        public int x { get; set; }
        public int y { get; set; }
        public XY(int X, int Y)
        {

            x = X;
            y = Y;
        }
    }
    public class NPC
    {
        public XY start_xy { get; set; } //Must be the multiply of 10!!
        public string left_standing { get; set; }
        public string left_walking_a { get; set; }
        public string left_walking_b { get; set; }
        public NPC(XY Start_xy, string Left_standing, string Left_walking_a, string Left_walking_b) {
            start_xy = Start_xy;
            left_standing = Left_standing;
            left_walking_a = Left_walking_a;
            left_walking_b = Left_walking_b;

        }
    }
}
