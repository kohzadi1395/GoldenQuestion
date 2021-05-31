using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity : IBaseEntity
    {
        private DateTime _createDate;
        private Guid _id;

        [Key]
        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = Guid.NewGuid();
                return _id;
            }

            set => _id = value;
        }

        public Guid CreateUser { get; set; }

        public DateTime CreateDate
        {
            get
            {
                if (_createDate == default) _createDate = DateTime.Now;
                return _createDate;
            }
            set => _createDate = value;
        }

        public Guid ModifyUser { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool Deleted { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public interface IBaseEntity
    {
        Guid Id { get; set; }

        Guid CreateUser { get; set; }

        DateTime CreateDate { get; set; }

        Guid ModifyUser { get; set; }

        DateTime ModifyDate { get; set; }
        bool Deleted { get; set; }

        byte[] RowVersion { get; set; }
    }
}