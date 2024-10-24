using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;

namespace cs2_randomizer
{
    public class Randomizer
    {
        private ILogger _logger;
        private Random _random;
        public Randomizer(ILogger logger, Random? random = null)
        {
            _logger = logger;
            _random = random ?? new Random();
        }

        public void RandomizeLoadouts()
        {
            var players = Utils.GetAllPlayers();
            var weapons = Utils.Weapons;

            foreach (var player in players)
            {
                player.RemoveWeapons();
                StripMoney(player);

                if (player.TeamNum == 3) //CT side
                {
                    if (_random.Next(0, 2) == 1)
                    {
                        giveDefuser(player);
                    }
                }
                if (player.TeamNum == 2) //T side
                {
                    if (_random.Next(0, 2) == 1)
                    {
                        player.GiveNamedItem(Constants.bombWeaponName);
                    }
                }
                var weapon = weapons[_random.Next(weapons.Length)];
                RollArmor(player);
                RollGrenades(player);
                player.GiveNamedItem(weapon);
                player.GiveNamedItem(Constants.knifeWeaponName);
            }

        }

        private void giveDefuser(CCSPlayerController playerController)
        {
            var itemServices = new CCSPlayer_ItemServices(playerController.Pawn.Value.ItemServices.Handle);
            itemServices.HasDefuser = true;
        }

        private void RollArmor(CCSPlayerController player)
        {
            int result = _random.Next(0, 3);
            switch (result)
            {
                case 0:
                    return;
                case 1:
                    player.GiveNamedItem(Constants.armorWeaponName);
                    return;
                case 2:
                    player.GiveNamedItem(Constants.armorHelmetWeaponName);
                    return;
            }
        }

        private void StripMoney(CCSPlayerController player)
        {
            var buyServices = player.InGameMoneyServices;
            buyServices.Account = 0;
        }

        private void RollGrenades(CCSPlayerController player)
        {
            var amount = _random.Next(0, 4);
            for (int i = 0; i < amount; i++) { 
                var item = Utils.Grenades[_random.Next(0, Utils.Grenades.Length)];
                player.GiveNamedItem(item);
            }
        }

    }

}
