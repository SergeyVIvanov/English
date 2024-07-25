using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    internal class Consts
    {
        internal enum Time { Past, Present, Future };

        internal static readonly string[] Pronouns = { "Я", "Он", "Она", "Оно", "Мы", "Ты", "Вы", "Они" };
        internal static readonly string[] Pronouns2 = { "меня", "его", "её", "его (оно)", "нас", "тебя", "вас", "их" };

        internal static readonly Dictionary<string, Dictionary<Time, string[]>> Verbs = new Dictionary<string, Dictionary<Time, string[]>>()
        {
            ["hate"] = new Dictionary<Time, string[]>()
            {
                [Time.Past] = new string[] { "ненавидел", "ненавидел", "ненавидела", "ненавидело", "ненавидели", "ненавидел", "ненавидели", "ненавидели" },
                [Time.Present] = new string[] { "ненавижу", "ненавидит", "ненавидит", "ненавидит", "ненавидим", "ненавидишь", "ненавидите", "ненавидят" },
                [Time.Future] = new string[] { "буду ненавидеть", "будет ненавидеть", "будет ненавидеть", "будет ненавидеть", "будем ненавидеть", "будешь ненавидеть", "будете ненавидеть", "будут ненавидеть" }
            },
            ["love"] = new Dictionary<Time, string[]>()
            {
                [Time.Past] = new string[] { "любил", "любил", "любила", "любило", "любили", "любил", "любили", "любили" },
                [Time.Present] = new string[] { "люблю", "любит", "любит", "любит", "любим", "любишь", "любите", "любят" },
                [Time.Future] = new string[] { "полюблю", "полюбит", "полюбит", "полюбит", "полюбим", "полюбишь", "полюбите", "полюбят" }
            },
            ["see"] = new Dictionary<Time, string[]>()
            {
                [Time.Past] = new string[] { "видел", "видел", "видела", "видело", "видели", "видел", "видели", "видели" },
                [Time.Present] = new string[] { "вижу", "видит", "видит", "видит", "видим", "видишь", "видите", "видят" },
                [Time.Future] = new string[] { "увижу", "увидит", "увидит", "увидит", "увидим", "увидишь", "увидите", "увидят" }
            }
        };
    }
}
