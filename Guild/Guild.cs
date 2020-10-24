using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> roster;
        public Guild(string name, int capacity)
        {
            roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isRemoved = false;

            foreach (var item in roster)
            {
                if (item.Name == name)
                {
                    isRemoved = true;
                    roster.Remove(item);
                    break;
                }
            }

            return isRemoved;
        }

        public void PromotePlayer(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (roster[i].Name == name && roster[i].Rank != "Member")
                {
                    roster[i].Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var item in roster)
            {
                if (item.Name == name && item.Rank != "Trial")
                {
                    item.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string className)
        {
            var array = roster.Where(p => p.Class == className).ToArray();
            roster.RemoveAll(p => p.Class == className);

            return array;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
