﻿using BackEnd.Services.Services;
using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ISmtpService
    {
        Task<int> DeleteSmtpConfig(SmtpConfigDelete model);
        Task<SmtpConfig> EditSmtpConfig(SmtpConfigPut config);
        Task<List<SmtpConfig>> GetSmtpConfig();
    }
}
