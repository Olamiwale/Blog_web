using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services
{
    public class MessageService
    {
        private readonly AppDbContext _context;
        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InboxResponse>> GetInboxAsync(int userId)
        {
            var message = await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();


            var conversations = message
                .GroupBy(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
                .Select(g => new InboxResponse
                {
                    OtherUserId = g.Key,
                    OtherUsername = g.First().SenderId == userId
                    ? g.First().Receiver.Username : g.First().Sender.Username,
                    LastMessage = g.First().Content,
                    LastMessageAt = g.First().CreatedAt
                }).ToList();

            return conversations;
        }

        public async Task<List<MessageResponse>> GetConversationAsync(int userId, int otherUserId)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Where(m =>
                    (m.SenderId == userId && m.ReceiverId == otherUserId) ||
                    (m.SenderId == otherUserId && m.ReceiverId == userId))
                .OrderBy(m => m.CreatedAt)
                .Select(m => new MessageResponse
                {
                    Id = m.Id,
                    Content = m.Content,
                    CreatedAt = m.CreatedAt,
                    SenderUsername = m.Sender.Username ?? string.Empty
                })
                .ToListAsync();
        }

        public async Task<MessageResponse> SendMessageAsync(SendMessageRequest request, int senderId)
        {
            var message = new Message
            {
                Content = request.Content,
                SenderId = senderId,
                ReceiverId = request.ReceiverId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            await _context.Entry(message).Reference(m => m.Sender).LoadAsync();

            return new MessageResponse
            {
                Id = message.Id,
                Content = message.Content,
                CreatedAt = message.CreatedAt,
                SenderUsername = message.Sender?.Username ?? string.Empty
            };
        }

        public async Task<bool> DeleteMessageAsync(int messageId, int userId)
        {
            var message = await _context.Messages.FindAsync(messageId);

            if (message == null) return false;
            if (message.SenderId != userId) return false; // can't delete someone else's message

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}