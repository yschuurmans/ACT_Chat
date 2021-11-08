using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_Chat.Models.Chat
{
    public class World
    {
        private static Dictionary<string, Worlds> _worldMap;
        public static Dictionary<string, Worlds> WorldMap { get
            {
                if (_worldMap != null) return _worldMap;
                _worldMap = new Dictionary<string, Worlds>();

                Enum.GetValues(typeof(Worlds))
                    .Cast<Worlds>().ToList()
                    .ForEach(x => _worldMap.Add(x.ToString(), x));
                return _worldMap;
            }
        }

        public static Worlds? FindWorld(string name)
        {
            foreach (var map in WorldMap)
            {
                if (name.EndsWith(map.Key)) return map.Value;
            }
            return null;
        }
    }
    public enum Worlds
    {
        Adamantoise,
        Cactuar,
        Faerie,
        Gilgamesh,
        Jenova,
        Midgardsormr,
        Sargatanas,
        Siren,
        Balmung,
        Brynhildr,
        Coeurl,
        Diabolos,
        Goblin,
        Malboro,
        Mateus,
        Zalera,
        Name,
        Behemoth,
        Excalibur,
        Exodus,
        Famfrit,
        Hyperion,
        Lamia,
        Leviathan,
        Ultros,
        Cerberus,
        Louisoix,
        Moogle,
        Omega,
        Ragnarok,
        Spriggan,
        Lich,
        Odin,
        Phoenix,
        Shiva,
        Twintania,
        Zodiark,
        Aegis,
        Atomos,
        Carbuncle,
        Garuda,
        Gungnir,
        Kujata,
        Ramuh,
        Tonberry,
        Typhon,
        Unicorn,
        Alexander,
        Bahamut,
        Durandal,
        Fenrir,
        Ifrit,
        Ridill,
        Tiamat,
        Ultima,
        Valefor,
        Yojimbo,
        Zeromus,
        Anima,
        Asura,
        Belias,
        Chocobo,
        Hades,
        Ixion,
        Mandragora,
        Masamune,
        Pandemonium,
        Shinryu,
        Titan
    }
}
