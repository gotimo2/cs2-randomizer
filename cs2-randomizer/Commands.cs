using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_randomizer
{
    internal class Commands
    {
        [ConsoleCommand("enable_randomizer", "Enables the randomizer plugin")]
        [CommandHelper((int)CommandUsage.SERVER_ONLY)]
        public void EnableRandomizer()
        {
            Plugin.RandomizerEnabled = true;
        }

        [ConsoleCommand("disble_randomizer", "Disables the randomizer plugin")]
        [CommandHelper((int)CommandUsage.SERVER_ONLY)]
        public void DisableRandomizer()
        {
            Plugin.RandomizerEnabled = false;
        }
    }
}
