using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicateWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null)
            {
                throw new BusinessException("Mail already exist.");
            }
        }

        public Task UserPasswordShouldBeMatch(User user, string password)
        {
            bool isMatched = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isMatched == false)
                throw new BusinessException("User password not match.");
            return Task.CompletedTask;
        }

        public Task UserShouldBeExists(User user)
        {
            if (user == null)
                throw new BusinessException("User Should be not exist.");
            return Task.CompletedTask;
        }


    }
}
