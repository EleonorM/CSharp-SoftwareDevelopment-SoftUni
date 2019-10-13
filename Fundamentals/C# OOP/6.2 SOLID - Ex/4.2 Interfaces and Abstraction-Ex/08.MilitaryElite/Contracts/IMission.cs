namespace _08.MilitaryElite.Contracts
{
    using _08.MilitaryElite.Enumerations;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
