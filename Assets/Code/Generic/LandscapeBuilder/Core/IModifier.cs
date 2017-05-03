namespace Code.Generic.LandscapeBuilder
{
    public interface IModifier<TCell, TStorage> where TCell : Cell
    {
        void ApplyToStorage(TCell current,TStorage storage);
        void Callback(TCell current);
        void Start();
    }
}