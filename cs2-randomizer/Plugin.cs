namespace cs2_randomizer;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;

public class Plugin : BasePlugin
{
    public override string ModuleName => "CS2 Randomizer";

    public override string ModuleVersion => "0.5";

    private bool _enabled = false;

    public override void Load(bool hotReload)
    {
        Console.WriteLine($"CS2 Randomizer {(hotReload ? "hot " : "")}Loaded !");
    }

    [ConsoleCommand ("enable_randomizer", "Enables the randomizer plugin")]
    [CommandHelper((int)CommandUsage.SERVER_ONLY)]
    public void EnableRandomizer()
    {
        _enabled = true;
    }

    [ConsoleCommand("disble_randomizer", "Disables the randomizer plugin")]
    [CommandHelper((int)CommandUsage.SERVER_ONLY)]
    public void DisableRandomizer()
    {
        _enabled = true;
    }
}
