﻿using System.Collections.Generic;

namespace HunterPie.Core.Address.Map.Internal
{
    internal static class AddressMapKeyWords
    {
        public enum AddressMapType
        {
            Long,
            VecInt32,
            Unknown
        }

        private static Dictionary<string, AddressMapType> types = new Dictionary<string, AddressMapType>()
        {
            { "Address", AddressMapType.Long },
            { "Offset", AddressMapType.VecInt32 }
        };

        public static bool IsKeyWord(string word) => types.ContainsKey(word);
        public static AddressMapType GetType(string word) => IsKeyWord(word) ? types[word] : AddressMapType.Unknown;
    }
}
