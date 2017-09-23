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

using System.Net.Http;
using SymphonyOSS.RestApiClient.Entities;

namespace SymphonyOSS.RestApiClient.Tests
{
    using Api;
    using Api.PodApi;
    using Authentication;
    using Generated.OpenApi.PodApi;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Presence = Entities.Presence;

    public class PresenceApiTest
    {
        private readonly PresenceApi _presenceApi;

        private readonly Mock<IApiExecutor> _apiExecutorMock;

        public PresenceApiTest()
        {
            var sessionManagerMock = new Mock<IAuthTokens>();
            sessionManagerMock.Setup(obj => obj.SessionToken).Returns("sessionToken");
            _apiExecutorMock = new Mock<IApiExecutor>();
            _presenceApi = new PresenceApi(sessionManagerMock.Object, "", new HttpClient(), _apiExecutorMock.Object);
        }

        [Fact]
        public void EnsureGetPresences_uses_retry_strategy()
        {
            _presenceApi.GetPresences();
            _apiExecutorMock.Verify(obj => obj.Execute(It.IsAny<Func<string, CancellationToken, Task<System.Collections.ObjectModel.ObservableCollection<UserPresence>>>>(), "sessionToken", default(CancellationToken)));
        }

        [Fact]
        public void EnsureGetPresence_uses_retry_strategy()
        {
            const long uid = 1;
            _apiExecutorMock.Setup(obj => obj.Execute(It.IsAny<Func<long, string, CancellationToken, Task<Generated.OpenApi.PodApi.Presence>>>(), uid, "sessionToken", default(CancellationToken)))
                .Returns(new Generated.OpenApi.PodApi.Presence() {Category  = Generated.OpenApi.PodApi.PresenceCategory.AVAILABLE});
            _presenceApi.GetPresence(uid);
            _apiExecutorMock.Verify(obj => obj.Execute(It.IsAny<Func<long, string, CancellationToken, Task<Generated.OpenApi.PodApi.Presence>>>(), uid, "sessionToken", default(CancellationToken)));
        }

        [Fact]
        public void EnsureSetPresence_uses_retry_strategy()
        {
            const long uid = 1;
            var presence = new Presence(uid, SymphonyOSS.RestApiClient.Entities.PresenceCategory.Available);
            _apiExecutorMock.Setup(obj => obj.Execute(It.IsAny<Func<long, string, Generated.OpenApi.PodApi.Presence, CancellationToken, Task<Generated.OpenApi.PodApi.Presence>>>(), uid, "sessionToken", It.IsAny<Generated.OpenApi.PodApi.Presence>(), default(CancellationToken)))
                .Returns(new Generated.OpenApi.PodApi.Presence() { Category = Generated.OpenApi.PodApi.PresenceCategory.AVAILABLE});
            _presenceApi.SetPresence(presence);
            _apiExecutorMock.Verify(obj =>
                obj.Execute(
                    It.IsAny<Func<long, string, Generated.OpenApi.PodApi.Presence, CancellationToken,
                        Task<Generated.OpenApi.PodApi.Presence>>>(), uid, "sessionToken",
                    It.IsAny<Generated.OpenApi.PodApi.Presence>(), default(CancellationToken)));
        }

    }
}
