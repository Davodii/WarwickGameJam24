namespace GT.Characters
{
    public sealed class Npc
    {
        private readonly string _name;

        public Npc(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}