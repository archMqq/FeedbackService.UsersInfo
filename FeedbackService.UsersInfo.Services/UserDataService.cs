using FeedbackService.ServiceResult;
using FeedbackService.UserInfo.UserProfileModels;
using FeedbackService.UserInfo.UserProfileModels.Models;
using FeedbackService.UserInfo.UserProfileModels.RequestResModels;
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
        public async Task<ServiceResult<int>> SaveUserDefaultData(UserInformation user)
        {
            try
            {
                await _context.AddAsync<UserInformation>(user);
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

        public async Task<ServiceResult<bool>> UpdateUserInfo(UserInformation _user)
        {
            var user = await _context.FindAsync<UserInformation>(_user.Id);
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

            user = _user;

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

        public async Task<ServiceResult<bool>> SetBusinessId(int userId, int businessId)
        {
            var user = await _context.FindAsync<UserInformation>(userId);
            if (user == null)
            {
                return new ServiceResult<bool>
                {
                    NotFound = true,
                    Errors = new ServiceErrors
                    {
                        Fields = new[] { userId.ToString() },
                        Error = "Пользователя с указанным id не существует"
                    }
                };
            }
            user.BusinessId = businessId;
            try
            {
                _context.SaveChanges();

                return new ServiceResult<bool>
                {
                    Result = true
                };
            }
            catch (DBConcurrencyException ex)
            {
                _logger.LogError($"Ошибка при изменении businessId пользователя в БД с текстом: {ex.Message}");
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
                _logger.LogError($"Операция изменения businessId была отменена с текстом: {ex.Message}");
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
