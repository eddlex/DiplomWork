/*
 * Camunda Platform REST API
 *
 * OpenApi Spec for Camunda Platform REST API.
 *
 * The version of the OpenAPI document: 7.16.0-alpha1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Camunda.Http.Api.Client.OpenAPIDateConverter;

namespace Camunda.Http.Api.Model
{
    /// <summary>
    /// SchemaLogEntryDto
    /// </summary>
    [DataContract(Name = "SchemaLogEntryDto")]
    public partial class SchemaLogEntryDto : IEquatable<SchemaLogEntryDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaLogEntryDto" /> class.
        /// </summary>
        /// <param name="id">The id of the schema log entry..</param>
        /// <param name="timestamp">The date and time of the schema update..</param>
        /// <param name="version">The version of the schema..</param>
        public SchemaLogEntryDto(string id = default(string), DateTimeOffset? timestamp = default(DateTimeOffset?), string version = default(string))
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.Version = version;
        }

        /// <summary>
        /// The id of the schema log entry.
        /// </summary>
        /// <value>The id of the schema log entry.</value>
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The date and time of the schema update.
        /// </summary>
        /// <value>The date and time of the schema update.</value>
        [DataMember(Name = "timestamp", EmitDefaultValue = true)]
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// The version of the schema.
        /// </summary>
        /// <value>The version of the schema.</value>
        [DataMember(Name = "version", EmitDefaultValue = true)]
        public string Version { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchemaLogEntryDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SchemaLogEntryDto);
        }

        /// <summary>
        /// Returns true if SchemaLogEntryDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SchemaLogEntryDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchemaLogEntryDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
