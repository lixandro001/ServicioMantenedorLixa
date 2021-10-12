﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Configurations
{
    [DataContract]
    public class TokenManagement
    {

        [DataMember(Name = "Secret")]
        public string Secret { get; set; }

        [DataMember(Name = "EncryptionSecret")]
        public string EncryptionSecret { get; set; }

        [DataMember(Name = "Issuer")]
        public string Issuer { get; set; }

        [DataMember(Name = "Audience")]
        public string Audience { get; set; }

        [DataMember(Name = "AccessExpiration")]
        public int AccessExpiration { get; set; }

        [DataMember(Name = "RefreshExpiration")]
        public int RefreshExpiration { get; set; }

    }
}
