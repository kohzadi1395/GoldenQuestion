using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces.Question;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public partial class QuestionRepository
    {
        public ICollection<Question> GetRandomQuestions(int questionNumber)
        {
            //var result = _context.Questions
            //    .Where(junction => junction.ProductId == productId)
            //    .Select(junction => new
            //    {
            //        EnumerationCode = junction.Enumeration.EnumerationCode,
            //        PartNumber = junction.Part.Number,
            //        PartDescription = junction.Part.Description,
            //    });
            return _context.Questions
                .AsNoTracking()
                .OrderBy(r => Guid.NewGuid())
                .Include(x => x.Options)
                .Take(questionNumber).ToList();
        }

        public List<Question> GetAllWithOption(Expression<Func<Question, bool>> predicate = null)
        {
            var query = _context.Questions
                .AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query. OrderBy(r => Guid.NewGuid())
                    .Include(x => x.Options)
                    .OrderBy(x=>x.CreateDate)
                    .ToList();
            
        }

    }
}