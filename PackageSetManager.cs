using System.Text.Json;

namespace UVEnviroman
{
    public static class PackageSetManager
    {
        private static readonly string PackageSetsFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "UVEnviroman",
            "PackageSets.json"
        );
        
        public static List<PackageSet> GetDefaultPackageSets()
        {
            return new List<PackageSet>
            {
                new PackageSet("Basic", "Essential Python packages", 
                    "pip", "setuptools", "wheel"),
                    
                new PackageSet("Data Science", "Popular data science packages",
                    "numpy", "pandas", "matplotlib", "seaborn", "scipy", "scikit-learn", "jupyter"),
                    
                new PackageSet("Web Development", "Web framework packages",
                    "flask", "django", "fastapi", "requests", "beautifulsoup4", "selenium"),
                    
                new PackageSet("Machine Learning", "ML and AI packages",
                    "tensorflow", "torch", "transformers", "opencv-python", "pillow", "scikit-image"),
                    
                new PackageSet("Development Tools", "Development and testing tools",
                    "pytest", "black", "flake8", "mypy", "pre-commit", "ipython"),
                    
                new PackageSet("API Development", "REST API development packages",
                    "fastapi", "uvicorn", "pydantic", "sqlalchemy", "alembic", "python-multipart")
            };
        }
        
        public static async Task<List<PackageSet>> LoadPackageSetsAsync()
        {
            try
            {
                if (!File.Exists(PackageSetsFile))
                {
                    var defaultSets = GetDefaultPackageSets();
                    await SavePackageSetsAsync(defaultSets);
                    return defaultSets;
                }
                
                string json = await File.ReadAllTextAsync(PackageSetsFile);
                var sets = JsonSerializer.Deserialize<List<PackageSet>>(json) ?? new List<PackageSet>();
                
                // Merge with defaults if empty
                if (!sets.Any())
                {
                    sets = GetDefaultPackageSets();
                    await SavePackageSetsAsync(sets);
                }
                
                return sets;
            }
            catch
            {
                return GetDefaultPackageSets();
            }
        }
        
        public static async Task SavePackageSetsAsync(List<PackageSet> packageSets)
        {
            try
            {
                string directory = Path.GetDirectoryName(PackageSetsFile)!;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                
                string json = JsonSerializer.Serialize(packageSets, options);
                await File.WriteAllTextAsync(PackageSetsFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save package sets: {ex.Message}");
            }
        }
    }
}