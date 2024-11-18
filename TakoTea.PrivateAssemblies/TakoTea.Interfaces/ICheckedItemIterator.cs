namespace TakoTea.Interfaces
{
    public interface ICheckedItemIterator
    {
        bool HasNext();
        string Next();
    }
}
