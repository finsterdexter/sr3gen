using SR3Generator.Data.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Creation
{
    internal static class RaceDatabase
    {
        public static List<Race> PlayerRaces { get; set; }

        static RaceDatabase()
        {
            PlayerRaces = new List<Race>
            {
                new Race {Name = RaceName.Human, AttributeMods = new List<AttributeMod>(), Extras = new List<string>()},
                new Race {Name = RaceName.Elf, 
                    AttributeMods = new List<AttributeMod>()
                    {
                        new AttributeMod {AttributeName = AttributeName.Quickness, ModValue = 1},
                        new AttributeMod {AttributeName = AttributeName.Charisma, ModValue = 2}
                    }, 
                    Extras = new List<string>()
                    {
                        "Low-light Vision"
                    }
                },
                new Race {Name = RaceName.Dwarf, 
                    AttributeMods = new List<AttributeMod>()
                    {
                        new AttributeMod {AttributeName = AttributeName.Body, ModValue = 1},
                        new AttributeMod {AttributeName = AttributeName.Strength, ModValue = 2},
                        new AttributeMod {AttributeName = AttributeName.Willpower, ModValue = 1}
                    }, 
                    Extras = new List<string>()
                    {
                        "Thermographic Vision", 
                        "Resistance (+2 Body) to any disease or toxin"
                    }
                },
                new Race {Name = RaceName.Ork, 
                    AttributeMods = new List<AttributeMod>()
                    {
                        new AttributeMod {AttributeName = AttributeName.Body, ModValue = 3},
                        new AttributeMod {AttributeName = AttributeName.Strength, ModValue = 2},
                        new AttributeMod {AttributeName = AttributeName.Charisma, ModValue = -1},
                        new AttributeMod {AttributeName = AttributeName.Intelligence, ModValue = -1}
                    }, 
                    Extras = new List<string>()
                    {
                        "Low-light Vision",
                    }
                },
                new Race {Name = RaceName.Troll,
                    AttributeMods = new List<AttributeMod>()
                    {
                        new AttributeMod {AttributeName = AttributeName.Body, ModValue = 5},
                        new AttributeMod {AttributeName = AttributeName.Quickness, ModValue = -1},
                        new AttributeMod {AttributeName = AttributeName.Strength, ModValue = 4},
                        new AttributeMod {AttributeName = AttributeName.Intelligence, ModValue = -2},
                        new AttributeMod {AttributeName = AttributeName.Charisma, ModValue = -2},
                    }, 
                    Extras = new List<string>()
                    {
                        "Thermographic Vision",
                        "+1 Reach for Armed/Unarmed Combat",
                        "Dermal Armor (+1 Body)"
                    }
                }
            };
        }
    }
}
