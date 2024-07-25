using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    public class QuestionInfo
    {
        public string Answer { get; private set; }
        public int AnswerDelay { get; private set; }
        public string Question { get; private set; }
        public int QuestionDelay { get; private set; }

        public QuestionInfo(string question, int questionDelay, string answer, int answerDelay)
        {
            Question = question;
            QuestionDelay = questionDelay;
            Answer = answer;
            AnswerDelay = answerDelay;
        }

        public override bool Equals(object obj)
        {
            return (obj is QuestionInfo info) && info.Question == Question;
        }
    }

    internal interface IModuleDefinition
    {
        string Caption { get; }

        IModule CreateModule();
    }

    internal interface IModule
    {
        int QuestionCount { get; }

        QuestionInfo GetQuestion(int index);
    }
}
