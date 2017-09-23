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

namespace SymphonyOSS.RestApiClient.Factories
{
    using Generated.OpenApi.PodApi;
    using User = Entities.User;
    using Generated.OpenApi.AgentApi;

    public abstract class UserFactory
    {
        public static User Create(UserV2 userV2)
        {
            return new User(
                userV2.Id ?? -1, userV2.EmailAddress,
                userV2.FirstName, userV2.LastName, userV2.DisplayName,
                userV2.Title, userV2.Company,
                userV2.Username, userV2.Location);
        }

        public static User Create(V4User user)
        {
            return new User(user.UserId.Value, user.Email, user.FirstName, user.LastName, user.DisplayName, null, null, user.Username, null);
        }
    }
}
