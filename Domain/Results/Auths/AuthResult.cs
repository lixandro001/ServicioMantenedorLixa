using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Auths
{
    [DataContract]
   public class AuthResult
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; private set; }

        [DataMember(Name = "token_type")]
        public string TokenType { get; private set; }

        [DataMember(Name = "expires_at")]
        public long ExpiresAt { get; private set; }

        public AuthResult(string accessToken, long expiresAt)
        {
            AccessToken = accessToken;
            ExpiresAt = expiresAt;
            TokenType = "Bearer";
        }

    }
}
