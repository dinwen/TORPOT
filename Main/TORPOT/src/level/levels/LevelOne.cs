using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.level.Levels
{
    public class LevelOne : Level
    {

        public LevelOne(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/test.txt");
        }

    }
}
