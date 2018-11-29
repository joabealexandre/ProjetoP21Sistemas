using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum CausaMorte
    {
        [Description("MOD_UNKNOWN")]
        MOD_UNKNOWN = 0,
        [Description("MOD_SHOTGUN")]
        MOD_SHOTGUN = 1,
        [Description("MOD_GAUNTLET")]
        MOD_GAUNTLET = 2,
        [Description("MOD_MACHINEGUN")]
        MOD_MACHINEGUN = 3,
        [Description("MOD_GRENADE")]
        MOD_GRENADE = 4,
        [Description("MOD_GRENADE_SPLASH")]
        MOD_GRENADE_SPLASH = 5,
        [Description("MOD_ROCKET")]
        MOD_ROCKET = 6,
        [Description("MOD_ROCKET_SPLASH")]
        MOD_ROCKET_SPLASH = 7,
        [Description("MOD_PLASMA")]
        MOD_PLASMA = 8,
        [Description("MOD_PLASMA_SPLASH")]
        MOD_PLASMA_SPLASH = 9,
        [Description("MOD_RAILGUN")]
        MOD_RAILGUN = 10,
        [Description("MOD_LIGHTNING")]
        MOD_LIGHTNING = 11,
        [Description("MOD_BFG")]
        MOD_BFG = 12,
        [Description("MOD_BFG_SPLASH")]
        MOD_BFG_SPLASH = 13,
        [Description("MOD_WATER")]
        MOD_WATER = 14,
        [Description("MOD_SLIME")]
        MOD_SLIME = 15,
        [Description("MOD_LAVA")]
        MOD_LAVA = 16,
        [Description("MOD_CRUSH")]
        MOD_CRUSH = 17,
        [Description("MOD_TELEFRAG")]
        MOD_TELEFRAG = 18,
        [Description("MOD_FALLING")]
        MOD_FALLING = 19,
        [Description("MOD_SUICIDE")]
        MOD_SUICIDE = 20,
        [Description("MOD_TARGET_LASER")]
        MOD_TARGET_LASER = 21,
        [Description("MOD_TRIGGER_HURT")]
        MOD_TRIGGER_HURT = 22,
        [Description("MOD_NAIL")]
        MOD_NAIL = 23,
        [Description("MOD_CHAINGUN")]
        MOD_CHAINGUN = 24,
        [Description("MOD_PROXIMITY_MINE")]
        MOD_PROXIMITY_MINE = 25,
        [Description("MOD_KAMIKAZE")]
        MOD_KAMIKAZE = 26,
        [Description("MOD_JUICED")]
        MOD_JUICED = 27,
        [Description("MOD_GRAPPLE")]
        MOD_GRAPPLE = 28
    }
}
