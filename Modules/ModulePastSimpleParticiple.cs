using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class ModuleDefinitionPastSimpleParticiple : IModuleDefinition
    {
        public string Caption => "Past simple/participle";

        public IModule CreateModule() => new ModulePastSimpleParticiple();
    }

    internal class ModulePastSimpleParticiple : IModule
    {
        private readonly string[] Answers = {
            "be",
            "buy",
            "do",
            "eat",
            "get",
            "give",
            "go",
            "have",
            "make",
            "meet",
            "say",
            "see",
            "send",
            "sleep",
            "spend",
            "take",
        };

        private readonly string[] Sentences = {
            "was/were + been",
            "bought + bought",
            "did + done",
            "ate + eaten",
            "got + got",
            "gave + given",
            "went + gone",
            "had + had",
            "made + made",
            "met + met",
            "said + said",
            "saw + seen",
            "sent + sent",
            "slept + slept",
            "spent + spent",
            "took + taken",
        };

        int IModule.QuestionCount => Sentences.Length;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(Sentences[index], 12000, Answers[index], 10000);
        }
    }
}
