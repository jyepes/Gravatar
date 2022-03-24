namespace Dodo.Gravatar.Models
{
    internal class Entry
    {
        public Name name { get; set; }

        public Photo[] photos { get; set; }

        public string displayName { get; set; }
    }
}
