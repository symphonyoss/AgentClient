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
 * Pod API
 *
 * This document refers to Symphony API calls that do not need encryption or decryption of content.  - sessionToken can be obtained by calling the authenticationAPI on the symphony back end and the key manager respectively. Refer to the methods described in authenticatorAPI.yaml. - Actions are defined to be atomic, ie will succeed in their entirety or fail and have changed nothing. - If it returns a 40X status then it will have made no change to the system even if ome subset of the request would have succeeded. - If this contract cannot be met for any reason then this is an error and the response code will be 50X. 
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

namespace SymphonyOSS.RestApiClient.Generated.OpenApi.PodApi.Model
{
    /// <summary>
    /// The suppression state of a message
    /// </summary>
    [DataContract]
    public partial class MessageSuppressionResponse :  IEquatable<MessageSuppressionResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSuppressionResponse" /> class.
        /// </summary>
        /// <param name="MessageId">MessageId.</param>
        /// <param name="Suppressed">Suppressed.</param>
        /// <param name="SuppressionDate">The date when this message was suppressed..</param>
        public MessageSuppressionResponse(string MessageId = default(string), bool? Suppressed = default(bool?), long? SuppressionDate = default(long?))
        {
            this.MessageId = MessageId;
            this.Suppressed = Suppressed;
            this.SuppressionDate = SuppressionDate;
        }
        
        /// <summary>
        /// Gets or Sets MessageId
        /// </summary>
        [DataMember(Name="messageId", EmitDefaultValue=false)]
        public string MessageId { get; set; }
        /// <summary>
        /// Gets or Sets Suppressed
        /// </summary>
        [DataMember(Name="suppressed", EmitDefaultValue=false)]
        public bool? Suppressed { get; set; }
        /// <summary>
        /// The date when this message was suppressed.
        /// </summary>
        /// <value>The date when this message was suppressed.</value>
        [DataMember(Name="suppressionDate", EmitDefaultValue=false)]
        public long? SuppressionDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MessageSuppressionResponse {\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  Suppressed: ").Append(Suppressed).Append("\n");
            sb.Append("  SuppressionDate: ").Append(SuppressionDate).Append("\n");
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
            return this.Equals(obj as MessageSuppressionResponse);
        }

        /// <summary>
        /// Returns true if MessageSuppressionResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of MessageSuppressionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MessageSuppressionResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.MessageId == other.MessageId ||
                    this.MessageId != null &&
                    this.MessageId.Equals(other.MessageId)
                ) && 
                (
                    this.Suppressed == other.Suppressed ||
                    this.Suppressed != null &&
                    this.Suppressed.Equals(other.Suppressed)
                ) && 
                (
                    this.SuppressionDate == other.SuppressionDate ||
                    this.SuppressionDate != null &&
                    this.SuppressionDate.Equals(other.SuppressionDate)
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
                if (this.MessageId != null)
                    hash = hash * 59 + this.MessageId.GetHashCode();
                if (this.Suppressed != null)
                    hash = hash * 59 + this.Suppressed.GetHashCode();
                if (this.SuppressionDate != null)
                    hash = hash * 59 + this.SuppressionDate.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
