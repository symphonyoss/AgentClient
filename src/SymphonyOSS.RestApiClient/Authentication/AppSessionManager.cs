﻿// Licensed to the Symphony Software Foundation (SSF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The SSF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

using SymphonyOSS.RestApiClient.Api.AuthenticationApi;
using SymphonyOSS.RestApiClient.Generated.OpenApi.AuthenticatorApi;

namespace SymphonyOSS.RestApiClient.Authentication
{
    using System.Security.Cryptography.X509Certificates;
    using Factories;

    /// <summary>
    /// Contains the session token needed for an application to authenticate on behalf of a user, 
    /// and the logic for generating this token using the authentication endpoints.
    /// </summary>
    public class AppSessionManager : ISessionManager
    {
        private readonly IAppAuthenticationApi _sessionAuthApi;

        private string _appSessionToken;
        private string _userSessionToken;
        private readonly long _userId;

        public AppSessionManager(string sessionAuthUrl, X509Certificate2 appCertificate, long userId)
        {
            Certificate = appCertificate;
            _userId = userId;

            var sessionAuthApiFactory = new AuthenticatorApiFactory(sessionAuthUrl);
            _sessionAuthApi = sessionAuthApiFactory.CreateAppAuthenticationApi(appCertificate);
        }

        public AppSessionManager(IAppAuthenticationApi sessionAuthApi, X509Certificate2 certificate)
        {
            Certificate = certificate;
            _sessionAuthApi = sessionAuthApi;
        }

        public X509Certificate2 Certificate { get; }

        public string SessionToken
        {
            get
            {
                if (_userSessionToken == null)
                {
                    GenerateTokens();
                }

                return _userSessionToken;
            }
        }

        public string KeyManagerToken => null;

        /// <summary>
        /// Generates both the session and key manager tokens.
        /// </summary>
        public void GenerateTokens()
        {
            // This could be made more efficient by reusing the cached appSessionToken and
            // only regenerating it if the call to V1AppUsernameUsernameAuthenticatePost fails.

            _appSessionToken = _sessionAuthApi.Authenticate();
            _userSessionToken = _sessionAuthApi.UserAuthenticate(_userId, _appSessionToken);
        }
    }
}
