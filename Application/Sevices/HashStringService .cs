﻿using Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Sevices
{

    public class HashStringService : IHashStringService
    {
        public Task<string> GetHashStringAsync(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hashbytes = sha256.ComputeHash(bytes);
                text = Convert.ToBase64String(hashbytes);

            }
            return Task.FromResult(text);
        }

    }
}
