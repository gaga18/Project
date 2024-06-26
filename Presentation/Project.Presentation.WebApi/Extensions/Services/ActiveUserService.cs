﻿using Project.Core.Application.Interfaces.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Project.Presentation.WebApi.Extensions.Services
{
    public class ActiveUserService : IActiveUserService
    {
        /// <summary>
        /// იუზერის მონაცემების და მოთხოვნის ინფორმაციის ამოღება
        /// საჭიროა ორივე კონსტრუქტორი: პირველი IoC კონტეინერისთვის გამოიყენება, მეორე ხელიტ შექმნისთვის.
        /// </summary>
        public ActiveUserService(IHttpContextAccessor httpContextAccessor) : this(httpContextAccessor.HttpContext) { }
        public ActiveUserService(HttpContext context)
        {
            if (context == null) return;

            this.UserId = Guid.TryParse(context.User?.FindFirstValue(ClaimTypes.NameIdentifier), out Guid result) ? result : Guid.Empty;
            this.IpAddress = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
            this.Port = context.Connection?.RemotePort ?? 0;

            this.RequestUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
            this.RequestMethod = context.Request.Method;
        }


        public Guid UserId { get; }
        public string IpAddress { get; }
        public int Port { get; }

        public string RequestUrl { get; }
        public string RequestMethod { get; }
    }
}
