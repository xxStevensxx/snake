using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneSys.Interfaces
{
    // utilisation du default interface methods le corps permet de ne pas implémenter
    // les methodes dans les classes utilisant l'interface
    interface IScene : IGameLoop
    {
        string Name { get; set; }
        void Show() {}
        void Hide() {}
        void Close() {}
        void IsActive() {}
        void Restart() {}

    }
}
