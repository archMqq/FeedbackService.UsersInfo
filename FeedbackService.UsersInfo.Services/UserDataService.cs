using FeedbackService.ServiceResult;
using FeedbackService.UserInfo.UserInfoModels;
using FeedbackService.UserInfo.UserInfoModels.Models;
using FeedbackService.UserInfo.UserInfoModels.RequestResModels;
using Microsoft.Extensions.Logging;
using System.Data;

namespace FeedbackService.UsersInfo.Services
{
    public class UserDataService
    {
        private readonly UserdInfoContext _context;
        private readonly ILogger<UserDataService> _logger;
        public UserDataService(UserdInfoContext context, ILogger<UserDataService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ServiceResult<int>> SaveUserDefaultData(User user)
        {
            try
            {
                await _context.AddAsync<User>(user);
                await _context.SaveChangesAsync();

                return new ServiceResult<int>
                {
                    Result = user.Id
                };
            }
            catch(DBConcurrencyException ex)
            {
                _logger.LogError($"Ошибка при сохранении нового пользователя в БД с текстом: {ex.Message}");
                return new ServiceResult<int>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Ошибка при вставке нового пользователя в БД"
                    }
                };
            }
            catch(OperationCanceledException ex)
            {
                _logger.LogError($"Операция вставки была отменена с текстом: {ex.Message}");
                return new ServiceResult<int>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Операция вставки была отменена"
                    }
                };
            }
        }

        public async Task<ServiceResult<bool>> UpdateUserInfo(int id, string? newName, string? newSurname, int? businessId)
        {
            var user = await _context.FindAsync<User>(id);
            if (user == null)
                return new ServiceResult<bool>
                {
                    BadRequest = true,
                    Errors = new ServiceErrors
                    {
                        Fields = new[] { "name" },
                        Error = "Такого Id пользователя не существует"
                    }
                };

            if (newName !=  null) 
                user.Name = newName;
            if (newSurname != null)
                user.Surname = newSurname;
            if (businessId != null)
                user.BusinessId = businessId;

            try
            {
                await _context.SaveChangesAsync();

                return new ServiceResult<bool>
                {
                    Result = true
                };
            }
            catch (DBConcurrencyException ex)
            {
                _logger.LogError($"Ошибка при изменении данных пользователя в БД с текстом: {ex.Message}");
                return new ServiceResult<bool>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Ошибка при изменении данных пользователя в БД"
                    }
                };
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError($"Операция изменения была отменена с текстом: {ex.Message}");
                return new ServiceResult<bool>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Операция изменения была отменена"
                    }
                };
            }
        }

    }
}
