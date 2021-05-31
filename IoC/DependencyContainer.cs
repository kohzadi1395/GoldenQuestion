
using Application.Interfaces.General;
using Application.Interfaces.Comment;
using Application.Interfaces.Country;
using Application.Interfaces.Exam;
using Application.Interfaces.ExamQuestion;
using Application.Interfaces.ExamTaken;
using Application.Interfaces.Language;
using Application.Interfaces.Learning;
using Application.Interfaces.LikeView;
using Application.Interfaces.Option;
using Application.Interfaces.Question;
using Application.Interfaces.QuestionType;
using Application.Interfaces.RateScore;
using Application.Interfaces.State;
using Application.Interfaces.Tag;

using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Core;
using Persistence.Repositories;

namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<ICountryService, CountryService>();
			services.AddScoped<IExamRepository, ExamRepository>();
			services.AddScoped<IExamService, ExamService>();
			services.AddScoped<IExamQuestionRepository, ExamQuestionRepository>();
			services.AddScoped<IExamQuestionService, ExamQuestionService>();
			services.AddScoped<IExamTakenRepository, ExamTakenRepository>();
			services.AddScoped<IExamTakenService, ExamTakenService>();
			services.AddScoped<ILanguageRepository, LanguageRepository>();
			services.AddScoped<ILanguageService, LanguageService>();
			services.AddScoped<ILearningRepository, LearningRepository>();
			services.AddScoped<ILearningService, LearningService>();
			services.AddScoped<ILikeViewRepository, LikeViewRepository>();
			services.AddScoped<ILikeViewService, LikeViewService>();
			services.AddScoped<IOptionRepository, OptionRepository>();
			services.AddScoped<IOptionService, OptionService>();
			services.AddScoped<IQuestionRepository, QuestionRepository>();
			services.AddScoped<IQuestionService, QuestionService>();
			services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
			services.AddScoped<IQuestionTypeService, QuestionTypeService>();
			services.AddScoped<IRateScoreRepository, RateScoreRepository>();
			services.AddScoped<IRateScoreService, RateScoreService>();
			services.AddScoped<IStateRepository, StateRepository>();
			services.AddScoped<IStateService, StateService>();
			services.AddScoped<ITagRepository, TagRepository>();
			services.AddScoped<ITagService, TagService>();
        }
    }
}