using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class ModuleDefinitionAnyNoSome : IModuleDefinition
    {
        public string Caption => "Any, No, Some";

        public IModule CreateModule() => new ModuleAnyNoSome();
    }

    internal class ModuleAnyNoSome : IModule
    {
        private readonly string[] Answers = {
            "We have some new books in our shop.",
            "There are no people in the shop.\nThere aren't any people in the shop.",
            "Do you have any umbrellas?",

            "Let’s go somewhere to buy a new washing machine.",
            "There's someone at the door.",
            "Somebody at the office will know.",
            "Give me something to do.",
            "Is there anybody who can help me?",
            "Do you have anything to wear to the party?",
            "Can you see her anywhere?",

            "There wasn't anything in her bag.\nThere was nothing in her bag.",
            "There isn’t anybody in the playroom.\nThere is nobody in the playroom.",
            "Nobody likes this shop",
            "There wasn't anywhere for me to sit.\nThere was nowhere for me to sit.",
        };

        private readonly string[] Sentences = {
            "У нас есть нескольно новых книг в нашем магазине.",
            "В магазине нет людей.",
            "У вас есть зонтики?",

            "Поехали куда-нибудь покупать новую стиральную машину.",
            "У двери кто-то есть.",
            "Кто-нибудь в офисе узнает.",
            "Дайте мне что-нибудь сделать.",
            "Есть ли кто-нибудь, кто может мне помочь?",
            "У тебя есть что надеть на вечеринку?",
            "Вы ее где-нибудь видите?",

            "В ее сумке ничего не было.",
            "В игровой комнате никого нет.",
            "Этот магазин никому не нравится.",
            "Мне негде было присесть.",
        };

        int IModule.QuestionCount => Sentences.Length;

        QuestionInfo IModule.GetQuestion(int index)
        {
            return new QuestionInfo(Sentences[index], 12000, Answers[index], 10000);
        }
    }
}
