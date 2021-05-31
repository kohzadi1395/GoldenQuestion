using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.Tag;
using Domain.Entities;

namespace Application.Services
{
    public partial class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IEnumerable<TagDto> GetAllTags()
        {
            var tags = _tagRepository.GetAll().Select(x => new TagDto
            {
                Name = x.Name,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return tags;
        }

        public Tag GetTag(Guid id)
        {
            return _tagRepository.GetById(id);
        }

        public Tag AddTag(Tag tag, Expression<Func<Tag, bool>> predicate = null)
        {
            return _tagRepository.AddTag(tag, predicate);
        }

        public bool RemoveTag(Tag tag)
        {
            return _tagRepository.RemoveTag(tag);
        }

        public bool RemoveTag(Expression<Func<Tag, bool>> predicate)
        {
            return _tagRepository.RemoveTag(predicate);
        }

        public bool UpdateTag(Tag tag)
        {
            return _tagRepository.UpdateTag(tag);
        }

        public IEnumerable<Tag> Find(Expression<Func<Tag, bool>> criteria)
        {
            return _tagRepository.Find(criteria);
        }
    }
}