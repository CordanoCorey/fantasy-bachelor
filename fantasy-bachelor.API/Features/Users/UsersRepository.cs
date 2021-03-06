using AutoMapper;
using fantasy_bachelor.API.Infrastructure;
using fantasy_bachelor.Entity.Context;
using fantasy_bachelor.Entity.DataClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantasy_bachelor.API.Features.Users
{
  public interface IUsersRepository : IBaseRepository<ApplicationUser, UserModel>
  {
    ApplicationUser FindByEmail(string email);
    ApplicationUser FindByPasswordResetCode(string code);
    UserModel FindUserByEmail(string email);
    IEnumerable<int> FindAdminUserIds();
  }

  public class UsersRepository : BaseRepository<FantasyBachelorContext, ApplicationUser, UserModel>, IUsersRepository
  {
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersRepository(FantasyBachelorContext context, IMapper mapper, UserManager<ApplicationUser> userManager) : base(context, mapper)
    {
      _userManager = userManager;
    }

    protected override IQueryable<ApplicationUser> IncludeAll(IQueryable<ApplicationUser> queryable)
    {
      return queryable;
    }

    protected override IQueryable<ApplicationUser> Include(IQueryable<ApplicationUser> queryable)
    {
      return queryable;
    }

    protected override IQueryable<ApplicationUser> IncludeSingle(IQueryable<ApplicationUser> queryable)
    {
      return queryable
       ;
    }

    public string FindEmailByPasswordResetCode(string code)
    {
      return FindByPasswordResetCode(code)?.Email;
    }

    public string FindPasswordResetCodeByEmail(string email)
    {
      return FindByEmail(email)?.PasswordResetCode;
    }

    public string HashPassword(string plaintextPassword)
    {
      return _userManager.PasswordHasher.HashPassword(null, plaintextPassword);
    }

    public void UpdatePassword(string passwordResetCode, string passwordHash)
    {
      var entity = FindByPasswordResetCode(passwordResetCode);
      entity.PasswordHash = passwordHash;
      entity.PasswordResetCode = "";
      _context.Entry(entity).State = EntityState.Modified;
      _context.Entry(entity).Property(x => x.AccessFailedCount).IsModified = false;
      _context.Entry(entity).Property(x => x.Email).IsModified = false;
      _context.Entry(entity).Property(x => x.EmailConfirmed).IsModified = false;
      _context.Entry(entity).Property(x => x.FirstName).IsModified = false;
      _context.Entry(entity).Property(x => x.LastName).IsModified = false;
      _context.Entry(entity).Property(x => x.LockoutEnabled).IsModified = false;
      _context.Entry(entity).Property(x => x.LockoutEnd).IsModified = false;
      _context.Entry(entity).Property(x => x.NormalizedEmail).IsModified = false;
      _context.Entry(entity).Property(x => x.NormalizedUserName).IsModified = false;
      _context.Entry(entity).Property(x => x.PhoneNumber).IsModified = false;
      _context.Entry(entity).Property(x => x.PhoneNumberConfirmed).IsModified = false;
      _context.Entry(entity).Property(x => x.SecurityStamp).IsModified = false;
      _context.Entry(entity).Property(x => x.TwoFactorEnabled).IsModified = false;
      _context.Entry(entity).Property(x => x.UserName).IsModified = false;
      _context.SaveChanges();
    }

    public void UpdatePasswordResetCode(string email, string passwordResetCode)
    {
      var entity = FindByEmail(email);
      entity.PasswordResetCode = passwordResetCode;
      _context.Entry(entity).State = EntityState.Modified;
      _context.Entry(entity).Property(x => x.AccessFailedCount).IsModified = false;
      _context.Entry(entity).Property(x => x.Email).IsModified = false;
      _context.Entry(entity).Property(x => x.EmailConfirmed).IsModified = false;
      _context.Entry(entity).Property(x => x.FirstName).IsModified = false;
      _context.Entry(entity).Property(x => x.LastName).IsModified = false;
      _context.Entry(entity).Property(x => x.LockoutEnabled).IsModified = false;
      _context.Entry(entity).Property(x => x.LockoutEnd).IsModified = false;
      _context.Entry(entity).Property(x => x.NormalizedEmail).IsModified = false;
      _context.Entry(entity).Property(x => x.NormalizedUserName).IsModified = false;
      _context.Entry(entity).Property(x => x.PasswordHash).IsModified = false;
      _context.Entry(entity).Property(x => x.PhoneNumber).IsModified = false;
      _context.Entry(entity).Property(x => x.PhoneNumberConfirmed).IsModified = false;
      _context.Entry(entity).Property(x => x.SecurityStamp).IsModified = false;
      _context.Entry(entity).Property(x => x.TwoFactorEnabled).IsModified = false;
      _context.Entry(entity).Property(x => x.UserName).IsModified = false;
      _context.SaveChanges();
    }

    public ApplicationUser FindByEmail(string email)
    {
      return FindSingleEntity(x => x.Email == email);
    }

    public UserModel FindUserByEmail(string email)
    {
      return FindSingle(x => x.Email == email);
    }

    public ApplicationUser FindByPasswordResetCode(string code)
    {
      return FindSingleEntity(x => x.PasswordResetCode == code);
    }

    public IEnumerable<int> FindAdminUserIds()
    {
      throw new NotImplementedException();
    }
  }
}
