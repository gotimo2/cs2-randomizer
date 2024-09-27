using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace cs2_randomizer
{
    public class Events
    {
        private readonly ILogger _logger;
        private readonly Randomizer randomizer;

        public Events(ILogger logger) { 
            _logger = logger;
            randomizer = new Randomizer(logger);
        }

        [GameEventHandler]
        public HookResult OnRoundStart(EventRoundStart gameEvent, GameEventInfo eventInfo)
        {
            _logger.LogDebug("Round start");
            if (Plugin.RandomizerEnabled)
            {
                randomizer.RandomizeLoadouts();
            }
            return HookResult.Continue;
        }

        [GameEventHandler]
        public HookResult OnGrenadeThrow(EventGrenadeThrown gameEvent, GameEventInfo eventInfo)
        {
            _logger.LogInformation("grenade thrown " + JsonSerializer.Serialize(gameEvent));
            return HookResult.Continue;
        }


    }
}
