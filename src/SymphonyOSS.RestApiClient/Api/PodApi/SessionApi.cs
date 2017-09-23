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

namespace SymphonyOSS.RestApiClient.Api.PodApi
{
    using Authentication;
    using Generated.OpenApi.PodApi;
    using System.Net.Http;

    /// <summary>
    /// Provides a method for getting the current user's session information, by encapsulating
    /// <see cref="Generated.OpenApi.PodApi.Api.SessionApi"/>,
    /// adding authentication token management and a custom execution strategy.
    /// </summary>
    public class SessionApi
    {
        private readonly Generated.OpenApi.PodApi.SessioninfoClient _sessionApi;

        private readonly IAuthTokens _authTokens;

        private readonly IApiExecutor _apiExecutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionApi" /> class.
        /// See <see cref="Factories.PodApiFactory"/> for conveniently constructing
        /// an instance.
        /// </summary>
        /// <param name="authTokens">Authentication tokens.</param>
        /// <param name="configuration">Api configuration.</param>
        /// <param name="apiExecutor">Execution strategy.</param>
        public SessionApi(IAuthTokens authTokens, string baseUrl, HttpClient httpClient, IApiExecutor apiExecutor)
        {
            _sessionApi = new Generated.OpenApi.PodApi.SessioninfoClient(baseUrl, httpClient);
            _authTokens = authTokens;
            _apiExecutor = apiExecutor;
        }

        /// <summary>
        /// Get the ID of the current user. 
        /// </summary>
        /// <returns>The user ID.</returns>
        public long GetUserId()
        {
            var sessionInfo = _apiExecutor.Execute(_sessionApi.V1Async, _authTokens.SessionToken);
            return sessionInfo.UserId.Value;
        }
    }
}
