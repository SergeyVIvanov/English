using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Speech.Synthesis;

namespace English
{
    public partial class Form1 : Form
    {
        private bool _isQuestion;
        private IModule _module;
        private List<int> _questionIndexes = new List<int>();
        private QuestionInfo _questionInfo;
        private Random _random;
        private Timer _timer;
        private bool _useButton = true;

        public Form1()
        {
            InitializeComponent();

            InitModuleCaptions();
            lblCount.Text = "";
        }

        #region Event handlers
        private void btn_Click(object sender, EventArgs e)
        {
            if (_isQuestion)
                ShowAnswer();
            else
                ShowNextQuestion();
        }

        private void cbModuleCaptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_useButton)
            {
                if (_timer != null)
                {
                    _timer.Tick -= timer_Tick;
                    _timer.Stop();
                }

                _timer = new Timer();
                _timer.Tick += timer_Tick;
            }

            _module = ModuleRepository.ModuleDefinitions[cbModuleCaptions.Text].CreateModule();
            _questionIndexes.Clear();
            _random = new Random();
            btn.Focus();

            ShowNextQuestion();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //if (_count == 30)
            //{
            //    Close();
            //    return;
            //}

            //label1.Text = "";

            //Consts.Time time = (Consts.Time)_rnd.Next(Enum.GetNames(typeof(Consts.Time)).Length);
            //int verbIndex = _rnd.Next(Consts.Verbs.Count);

            //int pronounIndex1 = _rnd.Next(Consts.Pronouns.Length);
            //int pronounIndex2;
            ////do
            ////{
            //pronounIndex2 = _rnd.Next(Consts.Pronouns2.Length);
            ////} while (index2 == index1);

            //int formIndex = _rnd.Next(3);

            //string s = Consts.Pronouns[pronounIndex1];
            //switch (formIndex)
            //{
            //    case 0:
            //        s = "Вопрос " + s + " " + Consts.Verbs.ElementAt(verbIndex).Value[time][pronounIndex1] + " " + Consts.Pronouns2[pronounIndex2] + "?";
            //        break;
            //    case 1:
            //        s = s + " " + Consts.Verbs.ElementAt(verbIndex).Value[time][pronounIndex1] + " " + Consts.Pronouns2[pronounIndex2];
            //        break;
            //    case 2:
            //        s = s + " не " + Consts.Verbs.ElementAt(verbIndex).Value[time][pronounIndex1] + " " + Consts.Pronouns2[pronounIndex2];
            //        break;
            //}

            //label1.Text = s;

            //var builder = new PromptBuilder();
            //builder.StartVoice(new CultureInfo("ru-RU"));
            //builder.AppendText(s);
            //builder.EndVoice();
            //_synthesizer.Speak(builder);

            //_count++;

            _timer.Stop();

            if (_isQuestion)
            {
                ShowAnswer();
            }
            else
            {
                ShowNextQuestion();
            }
        }
        #endregion

        private void InitModuleCaptions()
        {
            List<string> captions = ModuleRepository.ModuleDefinitions.Keys.ToList();
            captions.Sort();
            cbModuleCaptions.Items.AddRange(captions.ToArray());
        }

        private void FillQuestionIndexes()
        {
            for (int i = 0; i < _module.QuestionCount; i++)
                _questionIndexes.Add(i);
        }

        private void ShowNextQuestion()
        {
            if (_questionIndexes.Count == 0)
                FillQuestionIndexes();
            int index = _random.Next(_questionIndexes.Count);
            _questionInfo = _module.GetQuestion(_questionIndexes[index]);
            _questionIndexes.RemoveAt(index);
            lblCount.Text = _questionIndexes.Count.ToString();

            label1.Text = _questionInfo.Question;
            _isQuestion = true;

            if (_useButton)
            {
                btn.Text = "Ответ";
            }
            else
            {
                _timer.Interval = _questionInfo.QuestionDelay;
                _timer.Start();
            }
        }

        private void ShowAnswer()
        {
            label1.Text = _questionInfo.Answer;
            _isQuestion = false;

            if (_useButton)
            {
                btn.Text = "Вопрос";
            }
            else
            {
                _timer.Interval = _questionInfo.AnswerDelay;
                _timer.Start();
            }
        }
    }
}
