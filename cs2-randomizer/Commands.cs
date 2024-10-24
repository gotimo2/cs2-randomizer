using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;

namespace cs2_randomizer
{
    public class Commands
    {
        private readonly ILogger _logger;
        public Commands(ILogger logger) { 
            _logger = logger;
        }

        [ConsoleCommand("enable_randomizer", "Enables the randomizer plugin")]
        [CommandHelper(minArgs: 0, usage: "enable_randomizer", whoCanExecute: CommandUsage.SERVER_ONLY)]
        public void EnableRandomizer(CCSPlayerController? player, CommandInfo commandInfo)
        {
            if (player is not null)
            {
                return;
            }

            Plugin.RandomizerEnabled = true;
            _logger.LogInformation("Randomizer enabled!");
        }

        [ConsoleCommand("disble_randomizer", "Disables the randomizer plugin")]
        [CommandHelper(minArgs: 0, usage: "disable_randomizer", whoCanExecute: CommandUsage.SERVER_ONLY)]
        public void DisableRandomizer(CCSPlayerController? player, CommandInfo commandInfo)
        {
            if (player is not null)
            {
                return;
            }

            Plugin.RandomizerEnabled = false;
            _logger.LogInformation("Randomizer Disabled!");
        }
    }
}
