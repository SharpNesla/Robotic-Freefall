namespace Code.Generic.LandscapeBuilder
{
    public interface IModifier<TCell, TStorage> where TCell : Cell
    {
        void Apply(TCell cell,TStorage storage);
        void Callback(TCell current);
        void Start();
    }
}