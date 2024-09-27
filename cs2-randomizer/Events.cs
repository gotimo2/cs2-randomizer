using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_randomizer
{
    public class Events
    {
        private readonly ILogger _logger;
        public Events(ILogger logger) { 
            _logger = logger;
        }

        [GameEventHandler]
        public HookResult OnRoundStart(EventRoundStart gameEvent, GameEventInfo eventInfo)
        {
            _logger.LogDebug("Round start");
            if (Plugin.RandomizerEnabled)
            {
                GivePlayersRandomWeapons();
            }
            return HookResult.Continue;
        }

        private void GivePlayersRandomWeapons()
        {
            var players = Utils.GetAllPlayers();
            var random = new Random();
            var weapons = Utils.Weapons;

            foreach (var player in players)
            {
                var weapon = weapons[random.Next(weapons.Count - 1)];
                player.GiveNamedItem(weapon);
                player.RemoveWeapons();
                player.GiveNamedItem("weapon_knife");
            }

        }
    }
}
