using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.IO;

namespace English.Modules
{
    internal class FileQuestion
    {
        public string T { get; set; }
        public string F { get; set; }
    }

    internal class FileModule
    {
        public string Caption { get; set; }
        public List<FileQuestion> Questions { get; set; }
    }

    internal class SimpleModuleDefinition : IModuleDefinition
    {
        private FileModule _fileModule;

        public SimpleModuleDefinition(string filePath)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            _fileModule = deserializer.Deserialize<FileModule>(File.ReadAllText(filePath));
        }

        string IModuleDefinition.Caption => _fileModule.Caption;

        IModule IModuleDefinition.CreateModule()
        {
            return new SimpleModule(_fileModule.Questions);
        }
    }

    internal class SimpleModule : IModule
    {
        private List<FileQuestion> _questions;

        public SimpleModule(List<FileQuestion> questions)
        {
            _questions = questions;
        }

        int IModule.QuestionCount => _questions.Count;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(_questions[index].F, 10000, _questions[index].T, 10000);
        }
    }
}
