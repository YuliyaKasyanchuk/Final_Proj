using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace InternetApp.Models.ModelLogick
{
    [Table("QuestionSet")]
    public abstract class Question
    {
        public Question()
        {
            mAnswers = new HashSet<Answer>();
        }
        [Key]
        public int Id { get; set; }
        public int Test_Id { get; set; }

        // флаг, который отвечает за то, будет ли вопрос проверяться компьютером,
        // или его нужно будет отправить администратору
        protected bool mIsCheckedByComputer;
        [Required]
        public bool IsCheckedByComputer
        {
            set { mIsCheckedByComputer = value; }
            get { return mIsCheckedByComputer; }
        }

        protected string mText;
        [Required]
        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        public  IEnumerator<Answer> GetNextAnswer()
        {
            foreach (var answer in mAnswers)
                yield return answer;
        }

        protected ICollection<Answer> mAnswers;
        [Required]
        public ICollection<Answer> Answers
        {
            get { return mAnswers; }
            set { mAnswers = value; }
        }

        public virtual Test Test { get; set; }

        public abstract bool CheckIsQuestionRight(Question question);
        public abstract void AddAnswer(Answer answer);

        public abstract string GetEditWay();
    }

        public class          OpenQuestion : Question
        {
            public OpenQuestion()
            {
         
            }

            public override bool CheckIsQuestionRight(Question question)
            {
                return true;
            }
            // открытый вопрос будет также содержать коллекцию ответов, которая, однако, будет состоять из одного элемента
            // попытка перезаписи ответа предполагает очищение коллекции и добавление нового ответа
            // не костыль, а фича :(
            public override void AddAnswer(Answer answer)
            {
                if (mAnswers.Count != 0)
                    mAnswers.Clear();
                mAnswers.Add(answer);
            }

            public override string GetEditWay()
            {
                return "_OpenEdit";
            }

        }
        public abstract class ClosedQuestion : Question
        {
            public ClosedQuestion()
            {

            }

            public override bool CheckIsQuestionRight(Question question)
            {
                foreach (var answer in mAnswers)
                    if (answer.IsRight != question.GetNextAnswer().Current.IsRight)
                        return false;
                return true;
            }
            public override void AddAnswer(Answer answer)
            {
                if(!mAnswers.Contains(answer))
                    // тут должна быть интеллектуальная проверка на совпадения формулировок вопроса
                    mAnswers.Add(answer);
            }
        }

            public class SingleClosedQuestion : ClosedQuestion
            {
                public override string GetEditWay()
                {
                    return "_ClosedEditS";
                }
            }
            public class MultyClosedQuestion : ClosedQuestion
            {
                public override string GetEditWay()
                {
                    return "_ClosedEditM";
                }
            }
}