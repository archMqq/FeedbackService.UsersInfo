using FeedbackService.ServiceResult;
using FeedbackService.UserInfo.BusinessInfo;
using FeedbackService.UserInfo.BusinessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UsersInfo.Services
{
    public class BusinessService
    {
        private readonly UserBusinessContext _context;
        private readonly ILogger<BusinessService> _logger;
        public BusinessService(UserBusinessContext context, ILogger<BusinessService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResult<int>> SetBusiness(Business userBusiness, int userId)
        {
            try
            {
                await _context.AddAsync<Business>(userBusiness);
                await _context.SaveChangesAsync();

                return new ServiceResult<int>
                {
                    Result = userBusiness.Id
                };
            }
            catch (DBConcurrencyException ex) 
            {
                _logger.LogError($"Ошибка при сохранении информации о бизнесе с тектом: {ex.Message}");
                return new ServiceResult<int>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors()
                    {
                        Error = ex.Message
                    }
                };
            }
            catch (DbUpdateException ex) 
            {
                _logger.LogError($"Ошибка обновления информации о бизнесе с тектом: {ex.Message}");
                return new ServiceResult<int>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors()
                    {
                        Error = ex.Message
                    }
                };
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError($"Операция сохранения бизнеса была отменена с текстом: {ex.Message}");
                return new ServiceResult<int>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Операция изменения была отменена"
                    }
                };
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Неизвестная ошибка при сохранении информации о бизнесе с тектом: {ex.Message}");
                return new ServiceResult<int>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors()
                    {
                        Error = ex.Message
                    }
                };
            }
        }

        public async Task<ServiceResult<bool>> UpdateBusinessInfo(Business userBusiness)
        {
            Business? userBusinessDB = await _context.FindAsync<Business>(userBusiness.Id);
            if (userBusinessDB == null)
            {
                return new ServiceResult<bool>
                {
                    NotFound = true,
                    Errors = new ServiceErrors()
                    {
                        Error = "Такой записи не существует."
                    }

                };
            }

            userBusinessDB = userBusiness;

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
                _logger.LogError($"Ошибка при обновлении информации о бизнесе с тектом: {ex.Message}");
                return new ServiceResult<bool>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors()
                    {
                        Error = ex.Message
                    }
                };
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Ошибка обновления информации о бизнесе с тектом: {ex.Message}");
                return new ServiceResult<bool>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors()
                    {
                        Error = ex.Message
                    }
                };
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError($"Операция обновления информации о бизнесе была отменена с текстом: {ex.Message}");
                return new ServiceResult<bool>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Операция изменения была отменена"
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Неизвестная ошибка при обновлении информации о бизнесе с тектом: {ex.Message}");
                return new ServiceResult<bool>
                {
                    InternalServerError = true,
                    Errors = new ServiceErrors()
                    {
                        Error = ex.Message
                    }
                };
            }
        }
    }
}
