namespace SceneSys.Interfaces
{
    interface IGui<T>
    {

        void IsClicked() {}
        void Quit() {}
        void IsHover() {}
        void AddElement(T element) {}
    }
}
