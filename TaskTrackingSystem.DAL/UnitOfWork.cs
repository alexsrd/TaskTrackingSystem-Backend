using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Repositories;
using TaskTrackingSystem.DAL.Repositories.Interfaces;

namespace TaskTrackingSystem.DAL
{
    /// <summary>
    /// Implementation of UOW pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UserManager<ApplicationUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;

        public UnitOfWork(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ITaskRepository Tasks =>  _taskRepository ??= new TaskRepository(_context);

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public IProjectRepository Projects => _projectRepository ??= new ProjectRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}