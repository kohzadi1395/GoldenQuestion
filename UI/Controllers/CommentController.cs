using System;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.Comment;
using Application.Interfaces.Exam;
using Application.Interfaces.General;
using Application.Interfaces.Learning;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CommentsController : GoldenControl
    {
        private readonly ICommentService _commentService;
        private readonly IExamService _examService;
        private readonly ILearningService _learningService;
        private readonly IUnitOfWork _unitOfWork;

        public CommentsController(ICommentService commentService, IUnitOfWork unitOfWork,
            ILearningService learningService, IExamService examService)
        {
            _commentService = commentService;
            _unitOfWork = unitOfWork;
            _learningService = learningService;
            _examService = examService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var comment = _commentService.GetComment(id);
            if (comment == null)
                return NotFound("Comment not found");

            return Ok(comment);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var comment = _commentService.GetAllComments();

            return Ok(comment);
        }

        [HttpGet]
        public ActionResult MyComment()
        {
            var comment = _commentService.Find(x => x.CreateUser == UserId);

            if (comment == null)
                return NotFound("Comment not found");

            return Ok(comment);
        }

        [HttpGet]
        public ActionResult MyObjectComment()
        {
            var myLearns = _learningService.Find(x =>
                    x.CreateUser == UserId)
                .Select(x => new Learning {Id = x.Id, Title = x.Title}).ToList();

            var myExams = _examService.Find(x =>
                    x.CreateUser == UserId)
                .Select(x => new Exam {Id = x.Id, Name = x.Name}).ToList();

            var examId = myExams.Select(x => x.Id);
            var learnId = myLearns.Select(x => x.Id);
            var comments = _commentService.Find(
                x => examId.Contains(x.TableId)
                     || learnId.Contains(x.TableId)).ToList();
            var users = _commentService.GetSummaryUsers(comments.Select(x => x.CreateUser).ToList()).Result;

            var commentsDto = from comment in comments
                join learn in myLearns on comment.TableId equals learn.Id into l
                from learn in l.DefaultIfEmpty()
                join exam in myExams on comment.TableId equals exam.Id into ex
                from exam in ex.DefaultIfEmpty()
                join user in users on comment.CreateUser equals user.Id into usr
                from user in usr.DefaultIfEmpty()
                select CommentDto.GetDto(comment, learn, exam, user);

            return Ok(commentsDto);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(Comment comment)
        {
            if (comment.CommentText.Length > 400)
                comment.CommentText = comment.CommentText.Substring(0, 400);
            comment.CreateUser = UserId;
            comment.ModifyUser = UserId;
            if (_commentService.AddComment(comment) != null && _unitOfWork.Commit() > 0)
                return Ok("New Comment is Added");

            return Problem();
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(Comment comment)
        {
            comment.ModifyUser = UserId;
            if (_commentService.UpdateComment(comment) && _unitOfWork.Commit() > 0)
                return Ok("Comment is Update");

            return Problem();
        }

        [HttpDelete]
        public ActionResult Remove(Guid commentId, Guid userId)
        {
            if (UserId != userId)
                return Problem("you do not have grands");

            var comment = new Comment
            {
                Id = commentId,
                ModifyUser = UserId
            };
            return _commentService.RemoveComment(comment) && _unitOfWork.Commit() > 0
                ? Ok("Comment is Removed")
                : Problem();
        }
    }
}