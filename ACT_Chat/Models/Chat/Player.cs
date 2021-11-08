using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ACT_Chat.Models.Chat
{
    public class Player
    {
        private Regex specialCharacterFilter = new Regex("[^a-zA-Z ]");

        public Player()
        { }

        public Player(string name, Worlds defaultWorld)
        {
            RawName = name;
            World = Chat.World.FindWorld(name) ?? defaultWorld;
            Name = name;
            if (name.EndsWith(World.ToString()))
            {
                Name = name.Substring(0, name.LastIndexOf(World.ToString()));
            }
            Name = specialCharacterFilter.Replace(Name, "");
        }

        public string RawName { get; set; }
        public string Name { get; set; }
        public Worlds World { get; set; }
        public string FullName { get => $"{Name}@{World}"; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
