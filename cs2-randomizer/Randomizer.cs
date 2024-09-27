using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_randomizer
{
    public class Randomizer
    {
        private ILogger _logger;
        public Randomizer(ILogger logger) {
            _logger = logger;
        }
        public void RandomizeLoadouts()
        {
            var players = Utils.GetAllPlayers();
            var random = new Random();
            var weapons = Utils.Weapons;

            foreach (var player in players)
            {
                player.RemoveWeapons();
                StripMoney(player);

                if (player.TeamNum == 3) //CT side
                {
                    if (random.Next(0, 2) == 1)
                    {
                        giveDefuser(player);
                    }
                }
                if (player.TeamNum == 2) //T side
                {
                    if (random.Next(0, 2) == 1)
                    {
                        player.GiveNamedItem(Constants.bomb_weaponName);
                    }
                }
                var weapon = weapons[random.Next(weapons.Count - 1)];
                RollArmor(player);
                player.GiveNamedItem(weapon);
                player.GiveNamedItem(Constants.knife_weaponName);
            }

        }

        private void giveDefuser(CCSPlayerController playerController)
        {
            var itemServices = new CCSPlayer_ItemServices(playerController.Pawn.Value.ItemServices.Handle);
            itemServices.HasDefuser = true;
        }

        private void RollArmor(CCSPlayerController player)
        {
            Random random = new();
            int result = random.Next(0, 3);
            switch (result)
            {
                case 0:
                    return;
                case 1:
                    player.GiveNamedItem(Constants.armor_weaponName);
                    return;
                case 2:
                    player.GiveNamedItem(Constants.armorHelmet_weaponName);
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
            Random random = new();
        }

    }

}
