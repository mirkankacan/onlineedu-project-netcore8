﻿namespace OnlineEdu.WebUI.DTOs.MessageDtos
{
    public class UpdateMessageDto
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}