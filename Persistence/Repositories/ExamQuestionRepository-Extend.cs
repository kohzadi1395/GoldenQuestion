using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public partial class ExamQuestionRepository
    {
        public List<Question> GetQuestions(Guid examId)
        {
            return _context.ExamQuestions
                .AsNoTracking()
                .Where(x => x.ExamId == examId && x.Deleted == false)
                .Include(x => x.Question)
                .ThenInclude(x => x.Options.Where(y => y.Deleted == false))
                .Select(x => x.Question).ToList();
        }

        
    }
}
