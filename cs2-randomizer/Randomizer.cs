using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
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
        private Random _random;
        public Randomizer(ILogger logger, Random random = null)
        {
            _logger = logger;
            _random = random;
            if (random is null)
            {
                _random = new Random();
            }
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
                        player.GiveNamedItem(Constants.bomb_weaponName);
                    }
                }
                var weapon = weapons[_random.Next(weapons.Count)];
                RollArmor(player);
                RollGrenades(player);
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
            int result = _random.Next(0, 3);
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
            var amount = _random.Next(0, 4);
            for (int i = 0; i < amount; i++) { 
                var item = Utils.Grenades[_random.Next(0, Utils.Grenades.Count)];
                player.GiveNamedItem(item);
            }
        }

    }

}
