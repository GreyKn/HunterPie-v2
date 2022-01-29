﻿using HunterPie.Core.Client;
using HunterPie.Core.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HunterPie.Core.Remote
{
    public class CDN
    {
        const string CDN_BASE_URL = "https://cdn.hunterpie.com";

        private static HashSet<string> _notFoundCache = new();

        public static string GetMonsterIcon(string imageName)
        {
            return "";
        }

        public static async Task<string> GetMonsterIconUrl(string imagename)
        {
            if (_notFoundCache.Contains(imagename))
                return null;

            string url = $"{CDN_BASE_URL}/Assets/Monsters/Icons/{imagename}.png";
            string localImage = ClientInfo.GetPathFor($"Assets/Monsters/Icons/{imagename}.png");

            if (File.Exists(localImage))
                return localImage;

            using Poogie request = new PoogieBuilder()
                                .Get(url)
                                .WithTimeout(TimeSpan.FromSeconds(5))
                                .Build();

            using PoogieResponse response = await request.RequestAsync();
            {
                await response.Download(localImage);
            }

            return localImage;
        }
    }
}
