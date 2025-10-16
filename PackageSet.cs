namespace UVEnviroman
{
    public class PackageSet
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Packages { get; set; } = new();
        
        public PackageSet() { }
        
        public PackageSet(string name, string description, params string[] packages)
        {
            Name = name;
            Description = description;
            Packages = packages.ToList();
        }
        
        public override string ToString()
        {
            return $"{Name} ({Packages.Count} packages)";
        }
    }
}