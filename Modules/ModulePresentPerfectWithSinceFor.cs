using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class ModuleDefinitionPresentPerfectWithSinceFor : IModuleDefinition
    {
        public string Caption => "Present Perfect with \"since/for\"";

        public IModule CreateModule() => new ModulePresentPerfectWithSinceFor();
    }

    internal class ModulePresentPerfectWithSinceFor : IModule
    {
        private readonly string[] Answers = {
            "I've traveled around the world since 2020.",
            "I've done yoga for two hours.",
            "He hasn't been to Asia since he was eighteen.",
            "My mum hasn't been to that hotel for many years.",
            "- How long have you learnt German?\n- I've learnt it for four months.",
        };

        private readonly string[] Sentences = {
            "Я путешествую по миру с 2020 года.",
            "Я занимаюсь йогой уже два часа.",
            "Он не был в Азии с восемнадцати лет.",
            "Моя мама не была в том отеле уже много лет.",
            "- Как давно Вы изучаете немецкий язык?\n- Я изучаю его четыре месяца.",
        };

        int IModule.QuestionCount => Sentences.Length;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(Sentences[index], 12000, Answers[index], 10000);
        }
    }
}
