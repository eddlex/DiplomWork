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
    /// SetRetriesForExternalTasksDto
    /// </summary>
    [DataContract(Name = "SetRetriesForExternalTasksDto")]
    public partial class SetRetriesForExternalTasksDto : IEquatable<SetRetriesForExternalTasksDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetRetriesForExternalTasksDto" /> class.
        /// </summary>
        /// <param name="retries">The number of retries to set for the external task.  Must be &gt;&#x3D; 0. If this is 0, an incident is created and the task cannot be fetched anymore unless the retries are increased again. Can not be null..</param>
        /// <param name="externalTaskIds">The ids of the external tasks to set the number of retries for..</param>
        /// <param name="processInstanceIds">The ids of process instances containing the tasks to set the number of retries for..</param>
        /// <param name="externalTaskQuery">externalTaskQuery.</param>
        /// <param name="processInstanceQuery">processInstanceQuery.</param>
        /// <param name="historicProcessInstanceQuery">historicProcessInstanceQuery.</param>
        public SetRetriesForExternalTasksDto(int? retries = default(int?), List<string> externalTaskIds = default(List<string>), List<string> processInstanceIds = default(List<string>), ExternalTaskQueryDto externalTaskQuery = default(ExternalTaskQueryDto), ProcessInstanceQueryDto processInstanceQuery = default(ProcessInstanceQueryDto), HistoricProcessInstanceQueryDto historicProcessInstanceQuery = default(HistoricProcessInstanceQueryDto))
        {
            this.Retries = retries;
            this.ExternalTaskIds = externalTaskIds;
            this.ProcessInstanceIds = processInstanceIds;
            this.ExternalTaskQuery = externalTaskQuery;
            this.ProcessInstanceQuery = processInstanceQuery;
            this.HistoricProcessInstanceQuery = historicProcessInstanceQuery;
        }

        /// <summary>
        /// The number of retries to set for the external task.  Must be &gt;&#x3D; 0. If this is 0, an incident is created and the task cannot be fetched anymore unless the retries are increased again. Can not be null.
        /// </summary>
        /// <value>The number of retries to set for the external task.  Must be &gt;&#x3D; 0. If this is 0, an incident is created and the task cannot be fetched anymore unless the retries are increased again. Can not be null.</value>
        [DataMember(Name = "retries", EmitDefaultValue = true)]
        public int? Retries { get; set; }

        /// <summary>
        /// The ids of the external tasks to set the number of retries for.
        /// </summary>
        /// <value>The ids of the external tasks to set the number of retries for.</value>
        [DataMember(Name = "externalTaskIds", EmitDefaultValue = true)]
        public List<string> ExternalTaskIds { get; set; }

        /// <summary>
        /// The ids of process instances containing the tasks to set the number of retries for.
        /// </summary>
        /// <value>The ids of process instances containing the tasks to set the number of retries for.</value>
        [DataMember(Name = "processInstanceIds", EmitDefaultValue = true)]
        public List<string> ProcessInstanceIds { get; set; }

        /// <summary>
        /// Gets or Sets ExternalTaskQuery
        /// </summary>
        [DataMember(Name = "externalTaskQuery", EmitDefaultValue = false)]
        public ExternalTaskQueryDto ExternalTaskQuery { get; set; }

        /// <summary>
        /// Gets or Sets ProcessInstanceQuery
        /// </summary>
        [DataMember(Name = "processInstanceQuery", EmitDefaultValue = false)]
        public ProcessInstanceQueryDto ProcessInstanceQuery { get; set; }

        /// <summary>
        /// Gets or Sets HistoricProcessInstanceQuery
        /// </summary>
        [DataMember(Name = "historicProcessInstanceQuery", EmitDefaultValue = false)]
        public HistoricProcessInstanceQueryDto HistoricProcessInstanceQuery { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetRetriesForExternalTasksDto {\n");
            sb.Append("  Retries: ").Append(Retries).Append("\n");
            sb.Append("  ExternalTaskIds: ").Append(ExternalTaskIds).Append("\n");
            sb.Append("  ProcessInstanceIds: ").Append(ProcessInstanceIds).Append("\n");
            sb.Append("  ExternalTaskQuery: ").Append(ExternalTaskQuery).Append("\n");
            sb.Append("  ProcessInstanceQuery: ").Append(ProcessInstanceQuery).Append("\n");
            sb.Append("  HistoricProcessInstanceQuery: ").Append(HistoricProcessInstanceQuery).Append("\n");
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
            return this.Equals(input as SetRetriesForExternalTasksDto);
        }

        /// <summary>
        /// Returns true if SetRetriesForExternalTasksDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SetRetriesForExternalTasksDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetRetriesForExternalTasksDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Retries == input.Retries ||
                    (this.Retries != null &&
                    this.Retries.Equals(input.Retries))
                ) && 
                (
                    this.ExternalTaskIds == input.ExternalTaskIds ||
                    this.ExternalTaskIds != null &&
                    input.ExternalTaskIds != null &&
                    this.ExternalTaskIds.SequenceEqual(input.ExternalTaskIds)
                ) && 
                (
                    this.ProcessInstanceIds == input.ProcessInstanceIds ||
                    this.ProcessInstanceIds != null &&
                    input.ProcessInstanceIds != null &&
                    this.ProcessInstanceIds.SequenceEqual(input.ProcessInstanceIds)
                ) && 
                (
                    this.ExternalTaskQuery == input.ExternalTaskQuery ||
                    (this.ExternalTaskQuery != null &&
                    this.ExternalTaskQuery.Equals(input.ExternalTaskQuery))
                ) && 
                (
                    this.ProcessInstanceQuery == input.ProcessInstanceQuery ||
                    (this.ProcessInstanceQuery != null &&
                    this.ProcessInstanceQuery.Equals(input.ProcessInstanceQuery))
                ) && 
                (
                    this.HistoricProcessInstanceQuery == input.HistoricProcessInstanceQuery ||
                    (this.HistoricProcessInstanceQuery != null &&
                    this.HistoricProcessInstanceQuery.Equals(input.HistoricProcessInstanceQuery))
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
                if (this.Retries != null)
                    hashCode = hashCode * 59 + this.Retries.GetHashCode();
                if (this.ExternalTaskIds != null)
                    hashCode = hashCode * 59 + this.ExternalTaskIds.GetHashCode();
                if (this.ProcessInstanceIds != null)
                    hashCode = hashCode * 59 + this.ProcessInstanceIds.GetHashCode();
                if (this.ExternalTaskQuery != null)
                    hashCode = hashCode * 59 + this.ExternalTaskQuery.GetHashCode();
                if (this.ProcessInstanceQuery != null)
                    hashCode = hashCode * 59 + this.ProcessInstanceQuery.GetHashCode();
                if (this.HistoricProcessInstanceQuery != null)
                    hashCode = hashCode * 59 + this.HistoricProcessInstanceQuery.GetHashCode();
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
