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
        MOD_UNKNOWN,
        [Description("MOD_SHOTGUN")]
        MOD_SHOTGUN,
        [Description("MOD_GAUNTLET")]
        MOD_GAUNTLET,
        [Description("MOD_MACHINEGUN")]
        MOD_MACHINEGUN,
        [Description("MOD_GRENADE")]
        MOD_GRENADE,
        [Description("MOD_GRENADE_SPLASH")]
        MOD_GRENADE_SPLASH,
        [Description("MOD_ROCKET")]
        MOD_ROCKET,
        [Description("MOD_ROCKET_SPLASH")]
        MOD_ROCKET_SPLASH,
        [Description("MOD_PLASMA")]
        MOD_PLASMA,
        [Description("MOD_PLASMA_SPLASH")]
        MOD_PLASMA_SPLASH,
        [Description("MOD_RAILGUN")]
        MOD_RAILGUN,
        [Description("MOD_LIGHTNING")]
        MOD_LIGHTNING,
        [Description("MOD_BFG")]
        MOD_BFG,
        [Description("MOD_BFG_SPLASH")]
        MOD_BFG_SPLASH,
        [Description("MOD_WATER")]
        MOD_WATER,
        [Description("MOD_SLIME")]
        MOD_SLIME,
        [Description("MOD_LAVA")]
        MOD_LAVA,
        [Description("MOD_CRUSH")]
        MOD_CRUSH,
        [Description("MOD_TELEFRAG")]
        MOD_TELEFRAG,
        [Description("MOD_FALLING")]
        MOD_FALLING,
        [Description("MOD_SUICIDE")]
        MOD_SUICIDE,
        [Description("MOD_TARGET_LASER")]
        MOD_TARGET_LASER,
        [Description("MOD_TRIGGER_HURT")]
        MOD_TRIGGER_HURT,
        [Description("MOD_NAIL")]
        MOD_NAIL,
        [Description("MOD_CHAINGUN")]
        MOD_CHAINGUN,
        [Description("MOD_PROXIMITY_MINE")]
        MOD_PROXIMITY_MINE,
        [Description("MOD_KAMIKAZE")]
        MOD_KAMIKAZE,
        [Description("MOD_JUICED")]
        MOD_JUICED,
        [Description("MOD_GRAPPLE")]
        MOD_GRAPPLE
    }
}
