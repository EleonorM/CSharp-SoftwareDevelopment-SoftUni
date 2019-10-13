namespace _08.MilitaryElite.Contracts
{
    using _08.MilitaryElite.Enumerations;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
