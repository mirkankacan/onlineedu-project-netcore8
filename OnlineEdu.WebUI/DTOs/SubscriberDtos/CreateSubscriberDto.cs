﻿namespace OnlineEdu.WebUI.DTOs.SubscriberDtos
{
    public class CreateSubscriberDto
    {
        public string Email { get; set; }
        private bool IsActive { get => false; }
    }
}