using System;

namespace Application.Interfaces.General
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}