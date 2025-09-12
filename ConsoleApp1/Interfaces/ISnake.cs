using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneSys.Interfaces
{
    interface ISnake : IGameLoop
    {

        void AddSegment() {}
        void DelSegment() {}
        void EatFood() {}
        Queue<(int x, int y)> GetCurrentPos() { return new Queue<(int x, int y)>(); }
        bool JusteAte { get; set; }
        bool Drunk { get; set; }

    }
}
