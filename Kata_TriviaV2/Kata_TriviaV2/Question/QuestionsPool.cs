using System;
using Autofac;
using Kata_TriviaV2.Public;
using System.Collections.Generic;

namespace Kata_TriviaV2
{
    class QuestionPool : IQuestionPool
    {
        private readonly IDictionary<Category, IEnumerator<IQuestion>> Questions = new Dictionary<Category, IEnumerator<IQuestion>>();
        private readonly ILifetimeScope LifeTimeScope;

        public IQuestion Current { get; private set; }

        public QuestionPool(ILifetimeScope lifetimeInjector)
        {
            LifeTimeScope = lifetimeInjector;
            GenerateQuestions(Category.Pop, 50);
            GenerateQuestions(Category.Science, 50);
            GenerateQuestions(Category.Sports, 50);
            GenerateQuestions(Category.Rock, 50);
        }

        public bool MoveNext(Category category)
        {
            bool hasNext = Questions[category].MoveNext();

            SetCurrent(category, hasNext);

            return hasNext;
        }

        private void SetCurrent(Category category, bool currentExist)
        {
            if (currentExist)
            {
                Current = Questions[category].Current;
            }
            else
            {
                Current = null;
            }
        }

        private void GenerateQuestions(Category category, int HowManyQuestions)
        {
            // linkedList because adding is O(1)
            LinkedList<IQuestion> questions = new LinkedList<IQuestion>();

            for (int i = HowManyQuestions - 1; i >= 0; i--)
            {
                questions.AddFirst(CreateQuestion(category, i));
            }

            Questions.Add(category, questions.GetEnumerator());
        }

        private IQuestion CreateQuestion(Category category, int i)
        {
            var question = LifeTimeScope.Resolve<IQuestion>();
            question.Statement = $"{category} Question {i}";
            return question;
        }
    }
}
