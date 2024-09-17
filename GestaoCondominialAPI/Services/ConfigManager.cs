using System;

namespace GestaoCondominialAPI.Services {
    public class ConfigurationManager {
        private static ConfigurationManager _instance;
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private ConfigurationManager() {
            // Initialize configuration settings here
        }

        public static ConfigurationManager Instance {
            get {
                lock (_lock) {
                    if (_instance == null) {
                        _instance = new ConfigurationManager();
                    }
                    return _instance;
                }
            }
        }

        // Add configuration methods and properties here
        public string GetConfiguration(string key) {
            // Example: return configuration value based on the key
            // This is where you'd typically read from a configuration source
            return "ConfigurationValue"; // Replace with actual implementation
        }
    }
}
