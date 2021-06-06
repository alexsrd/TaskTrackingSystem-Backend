using System;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Repositories;
using TaskTrackingSystem.DAL.Repositories.Interfaces;

namespace TaskTrackingSystem.DAL
{
    /// <summary>
    /// Interface for implementation of UOW pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        UserManager<ApplicationUser> UserManager { get;}
        RoleManager<IdentityRole> RoleManager { get;} 
        ITaskRepository Tasks { get; }
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        void Save();
    }
}