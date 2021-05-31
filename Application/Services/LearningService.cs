using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.Interfaces.Comment;
using Application.Interfaces.General;
using Application.Interfaces.Learning;
using Application.Interfaces.LikeView;
using Application.Interfaces.RateScore;
using Application.QTO;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public partial class LearningService : ILearningService
    {
        private readonly ILearningRepository _learningRepository;

        public LearningService(ILearningRepository learningRepository,
            IUtilities utilities,
            IMemoryCache memoryCache,
            ILikeViewService likeViewService,
            IRateScoreService rateScoreService, ICommentService commentService)
        {
            _learningRepository = learningRepository;
            _commentService = commentService;
            _rateScoreService = rateScoreService;
            _likeViewService = likeViewService;
            _utilities = utilities;
        }

        public Learning AddLearning(Learning learning, Expression<Func<Learning, bool>> predicate = null)
        {
            return _learningRepository.AddLearning(learning, predicate);
        }

        public bool RemoveLearning(Learning learning)
        {
            return _learningRepository.RemoveLearning(learning);
        }

        public bool RemoveLearning(Expression<Func<Learning, bool>> predicate)
        {
            return _learningRepository.RemoveLearning(predicate);
        }

        public bool UpdateLearning(Learning learning)
        {
            return _learningRepository.UpdateLearning(learning);
        }

        public IEnumerable<Learning> Find(Expression<Func<Learning, bool>> criteria)
        {
            return _learningRepository.Find(criteria);
        }

       
        
    }
}