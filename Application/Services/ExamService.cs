using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.Comment;
using Application.Interfaces.Exam;
using Application.Interfaces.ExamQuestion;
using Application.Interfaces.General;
using Application.Interfaces.LikeView;
using Application.Interfaces.Question;
using Application.Interfaces.RateScore;
using Domain.Entities;

namespace Application.Services
{
    public partial class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository,
            ILikeViewService likeViewService,
            IRateScoreService rateScoreService,
            ICommentService commentService, 
            IUtilities utilities)
        {
            _examRepository = examRepository;
            _utilities = utilities;
            _commentService = commentService;
            _rateScoreService = rateScoreService;
            _likeViewService = likeViewService;
        }

        public Exam AddExam(Exam exam, Expression<Func<Exam, bool>> predicate = null)
        {
            return _examRepository.AddExam(exam, predicate);
        }

        public bool RemoveExam(Exam exam)
        {
            return _examRepository.RemoveExam(exam);
        }

        public bool RemoveExam(Expression<Func<Exam, bool>> predicate)
        {
            return _examRepository.RemoveExam(predicate);
        }

        public bool UpdateExam(Exam exam)
        {
            return _examRepository.UpdateExam(exam);
        }

        public IEnumerable<Exam> Find(Expression<Func<Exam, bool>> criteria)
        {
            return _examRepository.Find(criteria);
        }
    }
}