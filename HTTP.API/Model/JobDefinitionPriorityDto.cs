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
    /// JobDefinitionPriorityDto
    /// </summary>
    [DataContract(Name = "JobDefinitionPriorityDto")]
    public partial class JobDefinitionPriorityDto : IEquatable<JobDefinitionPriorityDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobDefinitionPriorityDto" /> class.
        /// </summary>
        /// <param name="priority">The new execution priority number for jobs of the given definition. The definition&#39;s priority can be reset by using the value &#x60;null&#x60;. In that case, the job definition&#39;s priority no longer applies but a new job&#39;s priority is determined as specified in the process model..</param>
        /// <param name="includeJobs">A boolean value indicating whether existing jobs of the given definition should receive the priority as well. Default value is &#x60;false&#x60;. Can only be &#x60;true&#x60; when the __priority__ parameter is not &#x60;null&#x60;..</param>
        public JobDefinitionPriorityDto(long? priority = default(long?), bool? includeJobs = default(bool?))
        {
            this.Priority = priority;
            this.IncludeJobs = includeJobs;
        }

        /// <summary>
        /// The new execution priority number for jobs of the given definition. The definition&#39;s priority can be reset by using the value &#x60;null&#x60;. In that case, the job definition&#39;s priority no longer applies but a new job&#39;s priority is determined as specified in the process model.
        /// </summary>
        /// <value>The new execution priority number for jobs of the given definition. The definition&#39;s priority can be reset by using the value &#x60;null&#x60;. In that case, the job definition&#39;s priority no longer applies but a new job&#39;s priority is determined as specified in the process model.</value>
        [DataMember(Name = "priority", EmitDefaultValue = true)]
        public long? Priority { get; set; }

        /// <summary>
        /// A boolean value indicating whether existing jobs of the given definition should receive the priority as well. Default value is &#x60;false&#x60;. Can only be &#x60;true&#x60; when the __priority__ parameter is not &#x60;null&#x60;.
        /// </summary>
        /// <value>A boolean value indicating whether existing jobs of the given definition should receive the priority as well. Default value is &#x60;false&#x60;. Can only be &#x60;true&#x60; when the __priority__ parameter is not &#x60;null&#x60;.</value>
        [DataMember(Name = "includeJobs", EmitDefaultValue = true)]
        public bool? IncludeJobs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobDefinitionPriorityDto {\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  IncludeJobs: ").Append(IncludeJobs).Append("\n");
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
            return this.Equals(input as JobDefinitionPriorityDto);
        }

        /// <summary>
        /// Returns true if JobDefinitionPriorityDto instances are equal
        /// </summary>
        /// <param name="input">Instance of JobDefinitionPriorityDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JobDefinitionPriorityDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Priority == input.Priority ||
                    (this.Priority != null &&
                    this.Priority.Equals(input.Priority))
                ) && 
                (
                    this.IncludeJobs == input.IncludeJobs ||
                    (this.IncludeJobs != null &&
                    this.IncludeJobs.Equals(input.IncludeJobs))
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
                if (this.Priority != null)
                    hashCode = hashCode * 59 + this.Priority.GetHashCode();
                if (this.IncludeJobs != null)
                    hashCode = hashCode * 59 + this.IncludeJobs.GetHashCode();
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
