namespace cs2_randomizer;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;

public class Plugin : BasePlugin
{
    public override string ModuleName => "CS2 Randomizer";

    public override string ModuleVersion => "0.5";

    public static bool RandomizerEnabled = true;

    public override void Load(bool hotReload)
    {
        Logger.LogInformation($"CS2 Randomizer {(hotReload ? "hot " : "")}Loaded !");
        RegisterConsoleCommandAttributeHandlers(new Commands(Logger));
        RegisterAllAttributes(new Events(Logger));
        base.Load(hotReload);
    }

}
