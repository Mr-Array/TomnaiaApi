using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Tomnaia.Consts;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Helpers;
using Tomnaia.IGenericRepository;
using Tomnaia.Interfaces;

namespace Tomnaia.Services.Services
{
    public class MessageService : IMessageService
    {
        #region fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserHelpers _userHelpers;

        #endregion

        #region ctor
        public MessageService(IUnitOfWork unitOfWork,
            UserManager<User> userManager, IMapper mapper,
            IUserHelpers userHelpers
            )
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _userHelpers = userHelpers;
        }
        #endregion

        #region Message handling
        public async Task<List<MessageResultDto>> GetMessagesAsync(string receiverId)
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("current user not found");
            var receiver = await _userManager.FindByIdAsync(receiverId);
            if (receiver == null) throw new Exception("receiver not found");

            var messages = await _unitOfWork.Message.FindAsync(
                m => (m.ReceiverPassengerId == receiverId && m.SenderPassengerId == currentUser.Id) ||
                     (m.ReceiverDriverId == receiverId && m.SenderDriverId == currentUser.Id) ||
                     (m.ReceiverPassengerId == currentUser.Id && m.SenderPassengerId == receiverId) ||
                     (m.ReceiverDriverId == currentUser.Id && m.SenderDriverId == receiverId),
                m => m.Timestamp, OrderDirection.Descending);

            var messageResult = messages.Select(message => _mapper.Map<MessageResultDto>(message)).ToList();
            return messageResult;
        }

        public async Task<bool> SendMessageAsync(string receiverId, SendMessageDto sendMessageDto)
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("current user not found");
            var receiver = await _userManager.FindByIdAsync(receiverId);
            if (receiver == null) throw new Exception("receiver not found");

            var message = _mapper.Map<Message>(sendMessageDto);

            if (currentUser.AccountType == AccountType.Passenger)
            {
                message.SenderPassengerId = currentUser.Id;
            }
            else
            {
                message.SenderDriverId = currentUser.Id;
            }

            if (receiver.AccountType == AccountType.Passenger)
            {
                message.ReceiverPassengerId = receiver.Id;
            }
            else
            {
                message.ReceiverDriverId = receiver.Id;
            }

            _unitOfWork.Message.Add(message);
            if (_unitOfWork.Save() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateMessageAsync(string messageId, SendMessageDto sendMessageDto)
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("current user not found");
            var message = await _unitOfWork.Message.FindFirstAsync(m => m.Id == messageId);
            if (message == null) throw new Exception("message not found");

            _mapper.Map(sendMessageDto, message);
            _unitOfWork.Message.Update(message);
            if (_unitOfWork.Save() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteMessageAsync(string messageId)
        {
            var currentUser = await _userHelpers.GetCurrentUserAsync();
            if (currentUser == null) throw new Exception("current user not found");
            var message = await _unitOfWork.Message.FindFirstAsync(m => m.Id == messageId);
            if (message == null) throw new Exception("message not found");

            _unitOfWork.Message.Remove(message);
            if (_unitOfWork.Save() > 0) return true;
            return false;
        }
        #endregion
    }
}