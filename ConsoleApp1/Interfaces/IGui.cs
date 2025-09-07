namespace SceneSys.Interfaces
{
    interface IGui<T> : IGameLoop
    {
        bool IsClicked() { return false; } 
        bool IsHover() { return false; }
        void Quit() {}
        void AddButton(T element) {}
    }
}
