using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.ExamQuestion;
using Application.Interfaces.General;
using Domain.Entities;

namespace Application.Services
{
    public partial class QuestionService
    {
        private readonly IExamQuestionService _examQuestionService;
        private readonly IUtilities _utilities;

        public ICollection<Question> GetRandomQuestions(int questionNumber)
        {
            return _questionRepository.GetRandomQuestions(questionNumber);
        }

        public  Question AddQuestion(QuestionDto questionDto)
        {
            var question = questionDto.Mapper();
            return _questionRepository.AddQuestion(question);
        }

        public  bool UpdateQuestion(QuestionDto questionDto)
        {
            var question = questionDto.Mapper();
            return _questionRepository.UpdateQuestion(question);
        }

        public async Task<bool> AddExamQuestions(List<Question> questions, ExamDto examDto)
        {
            var exam = examDto.Mapper();
            var savedFile = await _utilities.GetImage(examDto.Id.ToString(), examDto.Picture);
            if (savedFile != null)
                exam.Logo = savedFile.File;

            try
            {
                for (var i = 0; i < questions.Count; i++)
                {
                    var examQuestion = new ExamQuestion
                    {
                        CreateUser = exam.CreateUser,
                        CreateDate = DateTime.Now,
                        ModifyUser = exam.CreateUser,
                        ModifyDate = DateTime.Now,
                        Deleted = false,
                        QuestionNumber = i,
                        Question = questions[i],
                        Exam = exam
                    };
                    _examQuestionService.AddExamQuestion(examQuestion,x=>x.ExamId==exam.Id
                                                                         && x.QuestionId== examQuestion.QuestionId);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public async Task<bool> UpdateExamQuestions(List<Question> questions, ExamDto examDto)
        {
            var exam = examDto.Mapper();
            var savedFile = await _utilities.GetImage(examDto.Id.ToString(), examDto.Picture);
            if (savedFile != null)
                exam.Logo = savedFile.File;

            try
            {
                for (var i = 0; i < questions.Count; i++)
                {
                    var examQuestion = new ExamQuestion
                    {
                        CreateUser = exam.CreateUser,
                        CreateDate = DateTime.Now,
                        ModifyUser = exam.CreateUser,
                        ModifyDate = DateTime.Now,
                        Deleted = false,
                        QuestionNumber = i,
                        Question = questions[i],
                        Exam = exam
                    };
                    _examQuestionService.AddExamQuestion(examQuestion, x => x.ExamId == exam.Id
                                                                            && x.QuestionId == examQuestion.QuestionId);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Question> GetQuestions(Expression<Func<Question, bool>> predicate = null)
        {
            return _questionRepository.GetAllWithOption(predicate);
        }

    }
}