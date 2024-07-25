using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using English.Modules;

namespace English
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegisterModules();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void RegisterModules()
        {
            ModuleRepository.Register(new ModuleDefinitionAnyNoSome());
            ModuleRepository.Register(new ModuleDefinitionCan());
            ModuleRepository.Register(new ModuleDefinitionHaveGot());
            ModuleRepository.Register(new ModuleDefinitionPastSimpleParticiple());
            ModuleRepository.Register(new ModuleDefinitionPresentPerfectWithSinceFor());
            ModuleRepository.Register(new ModuleDefinitionToBeGoingTo());

            RegisterSimpleModules();
        }

        private static void RegisterSimpleModules()
        {
            foreach (string path in Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.yaml", SearchOption.TopDirectoryOnly))
                ModuleRepository.Register(new SimpleModuleDefinition(path));
        }
    }
}
