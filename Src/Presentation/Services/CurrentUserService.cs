﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ProductsCleanArch.Application.Common.Interfaces;

namespace ProductsCleanArch.Presentation.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
