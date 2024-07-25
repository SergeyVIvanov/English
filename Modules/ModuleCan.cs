namespace English
{
    internal class ModuleDefinitionCan : IModuleDefinition
    {
        public string Caption => "Can";

        public IModule CreateModule() => new ModuleCan();
    }

    internal class ModuleCan : IModule
    {
        private readonly string[] Answers = {
            "She can buy this bag if it isn't expensive.",
            "You cannot go to the supermarket. It's too late.",
            "Can I buy a toaster in this shopping centre?",

            "— Can it be a street market?\n— Yes, it can.",
            "— Can I put apples next to shampoos?\n— No, you can't.",
        };

        private readonly string[] Sentences = {
            "Она может купить эту сумку, если она не дорогая.",
            "Вы не можете пойти в супермаркет. Слишком поздно.",
            "Можно ли купить тостер в этом торговом центре?",

            "- Может ли это быть уличный рынок?\n- Да, может.",
            "- Можно ли класть яблоки рядом с шампунями?\n- Нет, нельзя.",
        };

        int IModule.QuestionCount => Sentences.Length;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(Sentences[index], 10000, Answers[index], 3000);
        }
    }
}
