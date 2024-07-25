using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class ModuleRepository
    {
        private static readonly Dictionary<string, IModuleDefinition> _moduleDefinitions = new Dictionary<string, IModuleDefinition>();

        public static IReadOnlyDictionary<string, IModuleDefinition> ModuleDefinitions { get; } = new ReadOnlyDictionary<string, IModuleDefinition>(_moduleDefinitions);

        public static void Register(IModuleDefinition definition)
        {
            if (string.IsNullOrWhiteSpace(definition.Caption) || _moduleDefinitions.ContainsKey(definition.Caption))
            {
                throw new ArgumentException();
            }

            _moduleDefinitions[definition.Caption] = definition;
        }
    }
}
