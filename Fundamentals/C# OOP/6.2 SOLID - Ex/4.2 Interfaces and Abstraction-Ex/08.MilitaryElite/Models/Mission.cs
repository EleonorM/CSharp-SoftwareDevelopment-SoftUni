namespace _08.MilitaryElite.Models
{
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Enumerations;
    using _08.MilitaryElite.Exceptions;
    using System;

    class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State != State.Finished)
            {
                this.State = State.Finished;
            }
            else
            {
                throw new InvalidMissionCompletionException();
            }
        }

        private void ParseState(string stateStr)
        {
            bool parsed = Enum.TryParse(stateStr, out State state);

            if (!parsed)
            {
                throw new InvalidStateException();
            }
            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
