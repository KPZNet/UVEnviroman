using System.Diagnostics;

namespace UVEnviroman
{
    public partial class Form1 : Form
    {
        private string selectedLocation = "";
        private List<PackageSet> packageSets = new();
        private PackageSet? currentEditingPackageSet = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Initialize Python version dropdown
            cmbPythonVersion.Items.AddRange(new string[]
            {
                "3.12",
                "3.11",
                "3.10",
                "3.9",
                "3.8"
            });
            cmbPythonVersion.SelectedIndex = 0; // Default to Python 3.12

            // Set default location to a dedicated Python environments folder
            string defaultLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Python Environments");
            
            // Create the directory if it doesn't exist
            try
            {
                if (!Directory.Exists(defaultLocation))
                {
                    Directory.CreateDirectory(defaultLocation);
                }
                selectedLocation = defaultLocation;
            }
            catch
            {
                // Fallback to current directory if we can't create the default folder
                selectedLocation = Environment.CurrentDirectory;
            }
            
            txtLocation.Text = selectedLocation;

            // Load package sets
            await LoadPackageSets();

            // Set initial window state and ensure proper sizing
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Initialize splitter position
            if (panelLeft != null)
            {
                panelLeft.Width = Math.Min(480, this.Width / 2);
            }
            
            // Welcome message
            AppendOutput("Welcome to UV Python Environment Manager!");
            AppendOutput($"Default location: {selectedLocation}");
            AppendOutput("Select your Python version, environment name, and package set to get started.");
            AppendOutput("");
        }

        private async Task LoadPackageSets()
        {
            try
            {
                packageSets = await PackageSetManager.LoadPackageSetsAsync();
                RefreshPackageSetDropdowns();
                
                // Select the first package set by default
                if (cmbPackageSet.Items.Count > 0)
                {
                    cmbPackageSet.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                AppendOutput($"Error loading package sets: {ex.Message}");
            }
        }

        private void RefreshPackageSetDropdowns()
        {
            // Update Create Environment tab dropdown
            cmbPackageSet.Items.Clear();
            foreach (var packageSet in packageSets)
            {
                cmbPackageSet.Items.Add(packageSet);
            }

            // Update Manage Package Sets tab dropdown
            cmbExistingPackageSets.Items.Clear();
            foreach (var packageSet in packageSets)
            {
                cmbExistingPackageSets.Items.Add(packageSet);
            }
        }

        private void cmbPackageSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPackageSet.SelectedItem is PackageSet selectedSet)
            {
                lstSelectedPackages.Items.Clear();
                foreach (var package in selectedSet.Packages)
                {
                    lstSelectedPackages.Items.Add(package);
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh dropdowns when switching tabs
            if (tabControl.SelectedTab == tabManagePackageSets)
            {
                RefreshPackageSetDropdowns();
            }
        }

        // Package Set Management Methods

        private void btnNewPackageSet_Click(object sender, EventArgs e)
        {
            currentEditingPackageSet = new PackageSet();
            txtPackageSetName.Text = "";
            txtPackageSetDescription.Text = "";
            lstPackageSetPackages.Items.Clear();
            cmbExistingPackageSets.SelectedIndex = -1;
            txtPackageSetName.Focus();
        }

        private void btnLoadPackageSet_Click(object sender, EventArgs e)
        {
            if (cmbExistingPackageSets.SelectedItem is PackageSet selectedSet)
            {
                currentEditingPackageSet = new PackageSet
                {
                    Name = selectedSet.Name,
                    Description = selectedSet.Description,
                    Packages = new List<string>(selectedSet.Packages)
                };
                
                txtPackageSetName.Text = selectedSet.Name;
                txtPackageSetDescription.Text = selectedSet.Description;
                lstPackageSetPackages.Items.Clear();
                foreach (var package in selectedSet.Packages)
                {
                    lstPackageSetPackages.Items.Add(package);
                }
            }
        }

        private void btnAddToSet_Click(object sender, EventArgs e)
        {
            AddPackageToSet();
        }

        private void txtNewPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddPackageToSet();
                e.Handled = true;
            }
        }

        private void AddPackageToSet()
        {
            string packageName = txtNewPackage.Text.Trim();
            if (!string.IsNullOrEmpty(packageName) && !lstPackageSetPackages.Items.Contains(packageName))
            {
                lstPackageSetPackages.Items.Add(packageName);
                txtNewPackage.Clear();
                txtNewPackage.Focus();
            }
        }

        private void btnRemoveFromSet_Click(object sender, EventArgs e)
        {
            var selectedItems = lstPackageSetPackages.SelectedItems.Cast<string>().ToList();
            foreach (string item in selectedItems)
            {
                lstPackageSetPackages.Items.Remove(item);
            }
        }

        private async void btnSavePackageSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPackageSetName.Text))
            {
                MessageBox.Show("Please enter a package set name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPackageSetName.Focus();
                return;
            }

            try
            {
                var packageSet = new PackageSet
                {
                    Name = txtPackageSetName.Text.Trim(),
                    Description = txtPackageSetDescription.Text.Trim(),
                    Packages = lstPackageSetPackages.Items.Cast<string>().ToList()
                };

                // Check if this is a new package set or updating existing
                var existingSet = packageSets.FirstOrDefault(ps => ps.Name.Equals(packageSet.Name, StringComparison.OrdinalIgnoreCase));
                if (existingSet != null)
                {
                    var result = MessageBox.Show($"Package set '{packageSet.Name}' already exists. Do you want to update it?", 
                                               "Package Set Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                    
                    packageSets.Remove(existingSet);
                }

                packageSets.Add(packageSet);
                await PackageSetManager.SavePackageSetsAsync(packageSets);
                
                RefreshPackageSetDropdowns();
                AppendOutput($"Package set '{packageSet.Name}' saved successfully.");
                
                MessageBox.Show("Package set saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving package set: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeletePackageSet_Click(object sender, EventArgs e)
        {
            if (cmbExistingPackageSets.SelectedItem is PackageSet selectedSet)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the package set '{selectedSet.Name}'?", 
                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        packageSets.Remove(selectedSet);
                        await PackageSetManager.SavePackageSetsAsync(packageSets);
                        
                        RefreshPackageSetDropdowns();
                        btnNewPackageSet_Click(sender, e); // Clear the form
                        
                        AppendOutput($"Package set '{selectedSet.Name}' deleted successfully.");
                        MessageBox.Show("Package set deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting package set: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a package set to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Original methods remain the same

        private void btnBrowseLocation_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder for Python environment creation";
                folderDialog.SelectedPath = selectedLocation;
                folderDialog.ShowNewFolderButton = true;
                
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string newLocation = folderDialog.SelectedPath;
                    
                    // Validate the selected path
                    if (ValidateLocation(newLocation))
                    {
                        selectedLocation = newLocation;
                        txtLocation.Text = selectedLocation;
                        AppendOutput($"Location changed to: {selectedLocation}");
                    }
                    else
                    {
                        MessageBox.Show("The selected location is not writable. Please choose a different folder.", 
                                      "Invalid Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private bool ValidateLocation(string path)
        {
            try
            {
                // Test if we can write to this location
                string testFile = Path.Combine(path, $"test_write_{Guid.NewGuid()}.tmp");
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void btnCreateEnvironment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnvironmentName.Text))
            {
                MessageBox.Show("Please enter an environment name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnvironmentName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedLocation))
            {
                MessageBox.Show("Please select a location for the environment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPackageSet.SelectedItem == null)
            {
                MessageBox.Show("Please select a package set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the current location before proceeding
            if (!ValidateLocation(selectedLocation))
            {
                MessageBox.Show("The selected location is not writable. Please choose a different folder.", 
                              "Invalid Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string environmentPath = Path.Combine(selectedLocation, txtEnvironmentName.Text.Trim());
            
            // Check if environment already exists
            if (Directory.Exists(environmentPath))
            {
                var result = MessageBox.Show($"Environment '{txtEnvironmentName.Text}' already exists in this location.\n\nDo you want to continue anyway?", 
                                           "Environment Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            btnCreateEnvironment.Enabled = false;
            btnCreateEnvironment.Text = "Creating...";
            txtOutput.Clear();
            
            try
            {
                await CreateUVEnvironment();
            }
            catch (Exception ex)
            {
                AppendOutput($"Error: {ex.Message}");
            }
            finally
            {
                btnCreateEnvironment.Enabled = true;
                btnCreateEnvironment.Text = "?? Create Environment";
            }
        }

        private async Task CreateUVEnvironment()
        {
            string environmentName = txtEnvironmentName.Text.Trim();
            string pythonVersion = cmbPythonVersion.SelectedItem?.ToString() ?? "3.12";
            string environmentPath = Path.Combine(selectedLocation, environmentName);
            var selectedPackageSet = (PackageSet)cmbPackageSet.SelectedItem!;

            AppendOutput("Creating UV Python environment...");
            AppendOutput($"Environment Name: {environmentName}");
            AppendOutput($"Python Version: {pythonVersion}");
            AppendOutput($"Package Set: {selectedPackageSet.Name}");
            AppendOutput($"Location: {environmentPath}");
            AppendOutput("");

            // Check if UV is installed
            if (!await CheckUVInstalled())
            {
                AppendOutput("UV is not installed or not found in PATH.");
                AppendOutput("Please install UV first: pip install uv");
                return;
            }

            // Create UV environment
            string createCommand = $"uv venv \"{environmentPath}\" --python {pythonVersion}";
            AppendOutput($"Running: {createCommand}");
            
            bool success = await RunCommand("uv", $"venv \"{environmentPath}\" --python {pythonVersion}");
            
            if (!success)
            {
                AppendOutput("Failed to create environment.");
                return;
            }

            AppendOutput("Environment created successfully!");

            // Install packages from the selected package set
            if (selectedPackageSet.Packages.Any())
            {
                AppendOutput("");
                AppendOutput($"Installing packages from '{selectedPackageSet.Name}' package set...");
                
                string packagesStr = string.Join(" ", selectedPackageSet.Packages);
                string installCommand = $"pip install {packagesStr}";
                
                // Get the python executable path for the new environment
                string pythonExe = GetPythonExecutablePath(environmentPath);
                
                AppendOutput($"Running: {pythonExe} -m {installCommand}");
                
                success = await RunCommand(pythonExe, $"-m {installCommand}");
                
                if (success)
                {
                    AppendOutput("Packages installed successfully!");
                }
                else
                {
                    AppendOutput("Some packages may have failed to install. Check the output above.");
                }
            }

            AppendOutput("");
            AppendOutput("Environment setup complete!");
            AppendOutput($"To activate the environment, run:");
            AppendOutput($"  {GetActivationCommand(environmentPath)}");
            AppendOutput("");
            AppendOutput($"Environment created at: {environmentPath}");
        }

        private async Task<bool> CheckUVInstalled()
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "uv",
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                if (process == null) return false;

                await process.WaitForExitAsync();
                return process.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> RunCommand(string fileName, string arguments)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = selectedLocation
                };

                using var process = Process.Start(processInfo);
                if (process == null) return false;

                // Read output asynchronously
                var outputTask = process.StandardOutput.ReadToEndAsync();
                var errorTask = process.StandardError.ReadToEndAsync();

                await process.WaitForExitAsync();

                string output = await outputTask;
                string error = await errorTask;

                if (!string.IsNullOrWhiteSpace(output))
                {
                    AppendOutput(output);
                }

                if (!string.IsNullOrWhiteSpace(error))
                {
                    AppendOutput($"Error: {error}");
                }

                return process.ExitCode == 0;
            }
            catch (Exception ex)
            {
                AppendOutput($"Exception running command: {ex.Message}");
                return false;
            }
        }

        private string GetPythonExecutablePath(string environmentPath)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                return Path.Combine(environmentPath, "Scripts", "python.exe");
            }
            else
            {
                return Path.Combine(environmentPath, "bin", "python");
            }
        }

        private string GetActivationCommand(string environmentPath)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                return Path.Combine(environmentPath, "Scripts", "activate.bat");
            }
            else
            {
                return $"source {Path.Combine(environmentPath, "bin", "activate")}";
            }
        }

        private void AppendOutput(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AppendOutput(text)));
                return;
            }

            txtOutput.AppendText(text + Environment.NewLine);
            txtOutput.ScrollToCaret();
        }

        private void btnResetLocation_Click(object sender, EventArgs e)
        {
            // Reset to default location
            string defaultLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Python Environments");
            
            try
            {
                if (!Directory.Exists(defaultLocation))
                {
                    Directory.CreateDirectory(defaultLocation);
                }
                selectedLocation = defaultLocation;
                txtLocation.Text = selectedLocation;
                AppendOutput($"Location reset to default: {selectedLocation}");
            }
            catch
            {
                // Fallback to current directory if we can't create the default folder
                selectedLocation = Environment.CurrentDirectory;
                txtLocation.Text = selectedLocation;
                AppendOutput($"Location reset to current directory: {selectedLocation}");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Ensure minimum layout constraints when resizing
            if (WindowState != FormWindowState.Minimized)
            {
                // Adjust panel sizes if needed
                if (panelLeft?.Width > 0 && panelRight?.Width > 0)
                {
                    // Maintain minimum widths
                    if (panelLeft.Width < 400)
                    {
                        panelLeft.Width = 400;
                    }
                    
                    // Ensure right panel has minimum space
                    int rightPanelMinWidth = 300;
                    if (Width - panelLeft.Width - splitter.Width < rightPanelMinWidth)
                    {
                        panelLeft.Width = Math.Max(400, Width - rightPanelMinWidth - splitter.Width);
                    }
                }
            }
        }
    }
}
