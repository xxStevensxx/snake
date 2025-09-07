using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneSys.Interfaces
{
    interface IGrid : IGameLoop
    {
        void CellToScreen() {}
    }
}
