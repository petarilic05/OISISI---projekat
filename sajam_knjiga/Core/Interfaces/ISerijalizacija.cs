namespace Core.Interfaces
{
    public interface ISerijalizacija
    {
        string[] ToCSV();
        void FromCSV(string[] values);
    }
}