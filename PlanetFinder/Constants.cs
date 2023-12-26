using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetFinder
{
    public static class Constants
    {
        public const int DARK_FOG__ENERGY_SHARD = 5206;
        public const int DARK_FOG__MATRIX = 5201;
        public const int DARK_FOG__2 = 5202;
        public const int DARK_FOG__STAR_CORE = 5203;
        public const int DARK_FOG__4 = 5205;
        public const int DARK_FOG__5 = 5204;


        public static bool IsDark(int id)
        {
            return id == DARK_FOG__2 ||
                   id == DARK_FOG__4 ||
                   id == DARK_FOG__ENERGY_SHARD ||
                   id == DARK_FOG__MATRIX ||
                   id == DARK_FOG__STAR_CORE ||
                   id == DARK_FOG__5;
        }
    }
}
