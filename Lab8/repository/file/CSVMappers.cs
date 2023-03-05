using Lab8.domain;
using Lab8.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.repository.file
{
    internal class CSVMappers
    {
        public static Team CreateTeam(string line)
        {
            string[] attributes = line.Split(',');

            return new(attributes[1])
            {
                Id = long.Parse(attributes[0])
            };
        }

        public static Player CreatePlayer(string line)
        {
            string[] attributes = line.Split(",");

            return new(attributes[1], attributes[2], long.Parse(attributes[3]))
            {
                Id = long.Parse(attributes[0])
            };
        }

        public static Match CreateMatch(string line)
        {
            string[] attributes = line.Split(",");

            return new(long.Parse(attributes[1]), long.Parse(attributes[2]), DateOnly.ParseExact(attributes[3], Constants.DateFormat))
            {
                Id = long.Parse(attributes[0])
            };
        }

        public static ActivePlayer CreateActivePlayer(string line)
        {
            string[] attributes = line.Split(",");

            return new(long.Parse(attributes[1]), long.Parse(attributes[2]), int.Parse(attributes[3]), (PlayerType)Enum.Parse(typeof(PlayerType), attributes[4], true))
            {
                Id = long.Parse(attributes[0])
            };
        }
    }
}
