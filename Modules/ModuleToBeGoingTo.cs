using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class ModuleDefinitionToBeGoingTo : IModuleDefinition
    {
        public string Caption => "To be going to";

        public IModule CreateModule() => new ModuleToBeGoingTo();
    }

    internal class ModuleToBeGoingTo : IModule
    {
        private readonly string[] Answers = {
            "I'm going to miss the lesson.",
            "They are going to leave the office.",
            "It's going to rain.",

            "I'm not going to fall asleep.",
            "We aren’t going to have a baby.",
            "She isn’t going to believe you.",

            "Am I going to be late?",
            "Is she going to be angry?",
        };
        private readonly string[] Sentences = {
            "Я собираюсь пропустить урок.",
            "Они собираются покинуть офис.",
            "Дождь собирается.",

            "Я не собираюсь засыпать.",
            "Мы не собираемся иметь ребёнка.",
            "Она не собирается верить тебе.",

            "Я опоздаю?",
            "Она разозлится?",
        };

        int IModule.QuestionCount => Sentences.Length;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(Sentences[index], 10000, Answers[index], 3000);
        }
    }
}
