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
/* 
 * Agent API
 *
 * This document refers to Symphony API calls to send and receive messages and content. They need the on-premise Agent installed to perform decryption/encryption of content.  - sessionToken and keyManagerToken can be obtained by calling the authenticationAPI on the symphony back end and the key manager respectively. Refer to the methods described in authenticatorAPI.yaml. - Actions are defined to be atomic, ie will succeed in their entirety or fail and have changed nothing. - If it returns a 40X status then it will have sent no message to any stream even if a request to aome subset of the requested streams would have succeeded. - If this contract cannot be met for any reason then this is an error and the response code will be 50X. - MessageML is a markup language for messages. See reference here: https://developers.symphony.com/documentation/message_format_reference 
 *
 * OpenAPI spec version: current
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SymphonyOSS.RestApiClient.Generated.OpenApi.AgentApi.Model
{
    /// <summary>
    /// V4RoomProperties
    /// </summary>
    [DataContract]
    public partial class V4RoomProperties :  IEquatable<V4RoomProperties>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V4RoomProperties" /> class.
        /// </summary>
        /// <param name="Name">Name.</param>
        /// <param name="Description">Description.</param>
        /// <param name="CreatorUser">CreatorUser.</param>
        /// <param name="CreatedDate">Timestamp.</param>
        /// <param name="External">External.</param>
        /// <param name="_Public">_Public.</param>
        /// <param name="CopyProtected">CopyProtected.</param>
        /// <param name="_ReadOnly">_ReadOnly.</param>
        /// <param name="Discoverable">Discoverable.</param>
        /// <param name="MembersCanInvite">MembersCanInvite.</param>
        public V4RoomProperties(string Name = default(string), string Description = default(string), V4User CreatorUser = default(V4User), long? CreatedDate = default(long?), bool? External = default(bool?), bool? _Public = default(bool?), bool? CopyProtected = default(bool?), bool? _ReadOnly = default(bool?), bool? Discoverable = default(bool?), bool? MembersCanInvite = default(bool?))
        {
            this.Name = Name;
            this.Description = Description;
            this.CreatorUser = CreatorUser;
            this.CreatedDate = CreatedDate;
            this.External = External;
            this._Public = _Public;
            this.CopyProtected = CopyProtected;
            this._ReadOnly = _ReadOnly;
            this.Discoverable = Discoverable;
            this.MembersCanInvite = MembersCanInvite;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets CreatorUser
        /// </summary>
        [DataMember(Name="creatorUser", EmitDefaultValue=false)]
        public V4User CreatorUser { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        /// <value>Timestamp</value>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public long? CreatedDate { get; set; }
        /// <summary>
        /// Gets or Sets External
        /// </summary>
        [DataMember(Name="external", EmitDefaultValue=false)]
        public bool? External { get; set; }
        /// <summary>
        /// Gets or Sets _Public
        /// </summary>
        [DataMember(Name="public", EmitDefaultValue=false)]
        public bool? _Public { get; set; }
        /// <summary>
        /// Gets or Sets CopyProtected
        /// </summary>
        [DataMember(Name="copyProtected", EmitDefaultValue=false)]
        public bool? CopyProtected { get; set; }
        /// <summary>
        /// Gets or Sets _ReadOnly
        /// </summary>
        [DataMember(Name="readOnly", EmitDefaultValue=false)]
        public bool? _ReadOnly { get; set; }
        /// <summary>
        /// Gets or Sets Discoverable
        /// </summary>
        [DataMember(Name="discoverable", EmitDefaultValue=false)]
        public bool? Discoverable { get; set; }
        /// <summary>
        /// Gets or Sets MembersCanInvite
        /// </summary>
        [DataMember(Name="membersCanInvite", EmitDefaultValue=false)]
        public bool? MembersCanInvite { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class V4RoomProperties {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CreatorUser: ").Append(CreatorUser).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  External: ").Append(External).Append("\n");
            sb.Append("  _Public: ").Append(_Public).Append("\n");
            sb.Append("  CopyProtected: ").Append(CopyProtected).Append("\n");
            sb.Append("  _ReadOnly: ").Append(_ReadOnly).Append("\n");
            sb.Append("  Discoverable: ").Append(Discoverable).Append("\n");
            sb.Append("  MembersCanInvite: ").Append(MembersCanInvite).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as V4RoomProperties);
        }

        /// <summary>
        /// Returns true if V4RoomProperties instances are equal
        /// </summary>
        /// <param name="other">Instance of V4RoomProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V4RoomProperties other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.CreatorUser == other.CreatorUser ||
                    this.CreatorUser != null &&
                    this.CreatorUser.Equals(other.CreatorUser)
                ) && 
                (
                    this.CreatedDate == other.CreatedDate ||
                    this.CreatedDate != null &&
                    this.CreatedDate.Equals(other.CreatedDate)
                ) && 
                (
                    this.External == other.External ||
                    this.External != null &&
                    this.External.Equals(other.External)
                ) && 
                (
                    this._Public == other._Public ||
                    this._Public != null &&
                    this._Public.Equals(other._Public)
                ) && 
                (
                    this.CopyProtected == other.CopyProtected ||
                    this.CopyProtected != null &&
                    this.CopyProtected.Equals(other.CopyProtected)
                ) && 
                (
                    this._ReadOnly == other._ReadOnly ||
                    this._ReadOnly != null &&
                    this._ReadOnly.Equals(other._ReadOnly)
                ) && 
                (
                    this.Discoverable == other.Discoverable ||
                    this.Discoverable != null &&
                    this.Discoverable.Equals(other.Discoverable)
                ) && 
                (
                    this.MembersCanInvite == other.MembersCanInvite ||
                    this.MembersCanInvite != null &&
                    this.MembersCanInvite.Equals(other.MembersCanInvite)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.CreatorUser != null)
                    hash = hash * 59 + this.CreatorUser.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.External != null)
                    hash = hash * 59 + this.External.GetHashCode();
                if (this._Public != null)
                    hash = hash * 59 + this._Public.GetHashCode();
                if (this.CopyProtected != null)
                    hash = hash * 59 + this.CopyProtected.GetHashCode();
                if (this._ReadOnly != null)
                    hash = hash * 59 + this._ReadOnly.GetHashCode();
                if (this.Discoverable != null)
                    hash = hash * 59 + this.Discoverable.GetHashCode();
                if (this.MembersCanInvite != null)
                    hash = hash * 59 + this.MembersCanInvite.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
