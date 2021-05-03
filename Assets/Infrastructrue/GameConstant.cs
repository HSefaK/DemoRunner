using UnityEngine;
using System.Collections;

namespace Assets.Infrastructrue
{
    public static class GameConstant 
    {
        public const string NPC = "NPC";
        public const string BOY = "Boy";
        public const string RUNNING = "Running";
        public const string DANCE = "Dance";
        public const string FLYING = "Flying";
        public const string STANDING = "Standing";
        public const string RUNNING_WITHOUT_BALANCE = "RunningWithoutBalance";
        public const string OBSTACLE_TURNING_RIGHT_TO_LEFT = "RtoL";
        public const string OBSTACLE_TURNING_LEFT_TO_RIGHT = "LtoR";
        public const string ENEMY = "Enemy";
        public const string SPEED_DOWNER_STICKS = "SpeedDowner";
        public const int GAME_END_POSITION_NPC = 32;
        public const int GAME_END_POSITION_PLAYER = 35;
        public const int GAME_END_POSITION_AGENT = 95;
        public const int PLAYER_FLY_Y_AXIS = 15;
        public const int ROTATOR_START_AXIS = -23;
        public const int ROTATOR_FINISH_AXIS = 0;

        //   public const string RUNNING = "Running";
    }
}