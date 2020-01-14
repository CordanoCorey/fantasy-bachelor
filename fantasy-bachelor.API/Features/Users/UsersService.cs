using fantasy_bachelor.API.Features.Rankings;
using fantasy_bachelor.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantasy_bachelor.API.Features.Users
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUser(int id);
        UserModel GetUserByEmail(string email);
        UserModel InsertUser(UserModel model);
        UserModel UpdateUser(UserModel model);
        void DeleteUser(int id);
        UserModel GetUserModelFromUser(ApplicationUser user);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repo;
        private readonly IRankingsRepository _rankings;

        public UsersService(IUsersRepository repo, IRankingsRepository rankings)
        {
            _repo = repo;
            _rankings = rankings;
        }

        public void DeleteUser(int id)
        {
            _repo.Delete(id);
        }
        public UserModel GetUserModelFromUser(ApplicationUser user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordResetCode = user.PasswordResetCode
            };
        }

        public UserModel GetUser(int id)
        {
            return _repo.FindByKey(id);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            List<UserModel> users = _repo.All().ToList();
            foreach(var user in users) {
                user.PickToWinName = _rankings.FindPickToWinName(user.Id);
                user.TotalPoints = _rankings.CalculatePoints(user.Id);
            }
            return users;
        }

        public UserModel InsertUser(UserModel model)
        {
            var inserted = _repo.Insert(model);
            return GetUser(inserted.Id);
        }

        public UserModel UpdateUser(UserModel model)
        {
            var updated = _repo.Update(model);
            return GetUser(updated.Id);
        }

        public UserModel GetUserByEmail(string email)
        {
            return _repo.FindUserByEmail(email);
        }
    }
}
