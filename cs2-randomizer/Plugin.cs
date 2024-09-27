namespace cs2_randomizer;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;

public class Plugin : BasePlugin
{
    public override string ModuleName => "CS2 Randomizer";

    public override string ModuleVersion => "0.5";

    public static bool RandomizerEnabled = false;

    public override void Load(bool hotReload)
    {
        Console.WriteLine($"CS2 Randomizer {(hotReload ? "hot " : "")}Loaded !");
    }



}
