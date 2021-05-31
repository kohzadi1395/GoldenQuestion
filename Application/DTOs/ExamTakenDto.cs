using Domain.Entities;

namespace Application.DTOs
{
    public class ExamTakenDto : ExamTaken
    {
        public ExamTaken Mapper()
        {
            return new ExamTaken
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Exam = Exam,
                ExamId = ExamId,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                RowVersion = RowVersion,
                TakeExam = TakeExam,
                UserId = UserId
            };
        }

        public static ExamTakenDto GetDto(ExamTaken examTaken)
        {
            return new ExamTakenDto
            {
                CreateDate = examTaken.CreateDate,
                CreateUser = examTaken.CreateUser,
                Deleted = examTaken.Deleted,
                Exam = examTaken.Exam,
                ExamId = examTaken.ExamId,
                Id = examTaken.Id,
                ModifyDate = examTaken.ModifyDate,
                ModifyUser = examTaken.ModifyUser,
                RowVersion = examTaken.RowVersion,
                TakeExam = examTaken.TakeExam,
                UserId = examTaken.UserId
            };
        }
    }
}