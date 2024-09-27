using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_randomizer
{
    public static class Utils
    {
       public static List<string> Weapons { get => new List<string>(_weapons); }

       public static IEnumerable<CCSPlayerController> GetAllPlayers()
       {
           List<CCSPlayerController> players = new List<CCSPlayerController>();
           for(int i = 0; i < Server.MaxPlayers; i++)
           {
               var p = Utilities.GetPlayerFromSlot(i);
               if (p is not null && p.IsValid)
               {
                   players.Add(p);
               }
           }
           return players;
       }

       private static List<string> _weapons = new List<string>{
           "weapon_m4a4",
           "weapon_m4a1_silencer",
           "weapon_famas",
           "weapon_ak47",
           "weapon_galilar",
           "weapon_sg556",
           "weapon_scar20",
           "weapon_awp",
           "weapon_ssg08",
           "weapon_g3sg1",
           "weapon_mp9",
           "weapon_mp7",
           "weapon_mp5sd",
           "weapon_ump45",
           "weapon_p90",
           "weapon_bizon",
           "weapon_mac10",
           "weapon_usp_silencer",
           "weapon_hkp2000",
           "weapon_glock",
           "weapon_elite",
           "weapon_p250",
           "weapon_fiveseven",
           "weapon_cz75a",
           "weapon_tec9",
           "weapon_revolver",
           "weapon_deagle",
           "weapon_nova",
           "weapon_xm1014",
           "weapon_mag7",
           "weapon_sawedoff",
           "weapon_m249",
           "weapon_negev",
           "weapon_taser"
           };
    }
}
