namespace _03._Ferrari
{
    public interface ICar
    {
        string Model { get; }

        string DriverName { get; set; }

        string Break();

        string Gas();
    }
}
