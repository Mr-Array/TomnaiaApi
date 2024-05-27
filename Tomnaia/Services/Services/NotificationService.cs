using AutoMapper;
using Tomnaia.Consts;
using Tomnaia.DTO;
using Tomnaia.Helpers;
using Tomnaia.IGenericRepository;
using Tomnaia.Interfaces;

namespace Tomnaia.Services.Services
{

    public class NotificationService : INotificationService
    {

        #region fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserHelpers _userHelpers;

        #endregion

        #region ctor
        public NotificationService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserHelpers userHelpers
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userHelpers = userHelpers;
        }
        #endregion

        #region Notification
        public async Task<List<NotificationResultDto>> GetCurrentUserNotificationsAsync()
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("user not found");
            var notifications = await _unitOfWork.Notification.FindAsync(n => n.ReceiverId == currentUser.Id, n => n.Timestamp, OrderDirection.Descending);
            var notificationResult = notifications.Select(notification => _mapper.Map<NotificationResultDto>(notification)).ToList();
            return notificationResult;
        }

        public async Task<NotificationResultDto> GetNotificationByIdAsync(string notificationId)
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("user not found");
            var notification = await _unitOfWork.Notification.FindFirstAsync(n => n.Id == notificationId);
            if (notification.ReceiverId != currentUser.Id) throw new Exception("cant access");
            var notificationResult = _mapper.Map<NotificationResultDto>(notification);
            return notificationResult;
        }

        public async Task<bool> DeleteNotificationByIdAsync(string notificationId)
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("user not found");
            var notification = await _unitOfWork.Notification.FindFirstAsync(n => n.Id == notificationId);
            if (notification.ReceiverId != currentUser.Id) throw new Exception("cant access");
            _unitOfWork.Notification.Remove(notification);
            if (_unitOfWork.Save() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteAllNotificationAsync()
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("user not found");
            var notifications = await _unitOfWork.Notification.FindAsync(n => n.ReceiverId == currentUser.Id);
            _unitOfWork.Notification.RemoveRange(notifications);
            if (_unitOfWork.Save() > 0) return true;
            return false;
        }

        #endregion
    }
}
