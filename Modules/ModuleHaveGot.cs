using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class ModuleDefinitionHaveGot : IModuleDefinition
    {
        public string Caption => "HaveGot";

        public IModule CreateModule() => new ModuleHaveGot();
    }

    internal class ModuleHaveGot : IModule
    {
        private readonly string[] Answers = {
            "She has got ('s got) blonde hair.",
            "I have got ('ve got) long hair.",
            "She has not got (hasn’t got) a big face.",
            "I have not got (haven’t got) blonde straight hair.",

            "Have you got any other roles for me?",
            "Has she got any talents?",
        };

        private readonly string[] Sentences = {
            "У нее светлые волосы.",
            "У меня длинные волосы.",
            "У нее нет большого лица.",
            "У меня нет светлых прямых волос.",

            "У вас есть для меня другие роли?",
            "Есть ли у нее таланты?",
        };

        int IModule.QuestionCount => Sentences.Length;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(Sentences[index], 10000, Answers[index], 3000);
        }
    }
}
