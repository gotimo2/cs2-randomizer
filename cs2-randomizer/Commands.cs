using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_randomizer
{
    public class Commands
    {
        private readonly ILogger _logger;
        public Commands(ILogger logger) { 
            _logger = logger;
        }


        [ConsoleCommand("enable_randomizer", "Enables the randomizer plugin")]
        public void EnableRandomizer(CCSPlayerController? player, CommandInfo commandInfo)
        {
            Plugin.RandomizerEnabled = true;
            _logger.LogInformation("Randomizer enabled!");
        }

        [ConsoleCommand("disble_randomizer", "Disables the randomizer plugin")]
        public void DisableRandomizer(CCSPlayerController? player, CommandInfo commandInfo)
        {
            Plugin.RandomizerEnabled = false;
            _logger.LogInformation("Randomizer Disabled!");
        }
    }
}
