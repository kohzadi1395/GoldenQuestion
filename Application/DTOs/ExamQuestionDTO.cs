using Domain.Entities;

namespace Application.DTOs
{
    public class ExamQuestionDto : ExamQuestion
    {
        public ExamQuestion Mapper()
        {
            return new ExamQuestion
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Exam = Exam,
                ExamId = ExamId,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Question = Question,
                QuestionId = QuestionId,
                QuestionNumber = QuestionNumber,
                RowVersion = RowVersion
            };
        }

        public static ExamQuestionDto GetDto(ExamQuestion examQuestion)
        {
            return new ExamQuestionDto
            {
                CreateDate = examQuestion.CreateDate,
                CreateUser = examQuestion.CreateUser,
                Deleted = examQuestion.Deleted,
                Exam = examQuestion.Exam,
                ExamId = examQuestion.ExamId,
                Id = examQuestion.Id,
                ModifyDate = examQuestion.ModifyDate,
                ModifyUser = examQuestion.ModifyUser,
                Question = examQuestion.Question,
                QuestionId = examQuestion.QuestionId,
                QuestionNumber = examQuestion.QuestionNumber,
                RowVersion = examQuestion.RowVersion
            };
        }
    }
}