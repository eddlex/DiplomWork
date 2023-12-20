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
    /// SetRemovalTimeToHistoricDecisionInstancesDto
    /// </summary>
    [DataContract(Name = "SetRemovalTimeToHistoricDecisionInstancesDto")]
    public partial class SetRemovalTimeToHistoricDecisionInstancesDto : IEquatable<SetRemovalTimeToHistoricDecisionInstancesDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetRemovalTimeToHistoricDecisionInstancesDto" /> class.
        /// </summary>
        /// <param name="hierarchical">Sets the removal time to all historic decision instances in the hierarchy. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior..</param>
        /// <param name="historicDecisionInstanceQuery">historicDecisionInstanceQuery.</param>
        /// <param name="historicDecisionInstanceIds">The ids of the historic decision instances to set the removal time for..</param>
        /// <param name="absoluteRemovalTime">The date for which the instances shall be removed. Value may not be &#x60;null&#x60;.  **Note:** Cannot be set in conjunction with &#x60;clearedRemovalTime&#x60; or &#x60;calculatedRemovalTime&#x60;..</param>
        /// <param name="clearedRemovalTime">Sets the removal time to &#x60;null&#x60;. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.  **Note:** Cannot be set in conjunction with &#x60;absoluteRemovalTime&#x60; or &#x60;calculatedRemovalTime&#x60;..</param>
        /// <param name="calculatedRemovalTime">The removal time is calculated based on the engine&#39;s configuration settings. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.  **Note:** Cannot be set in conjunction with &#x60;absoluteRemovalTime&#x60; or &#x60;clearedRemovalTime&#x60;..</param>
        public SetRemovalTimeToHistoricDecisionInstancesDto(bool? hierarchical = default(bool?), HistoricDecisionInstanceQueryDto historicDecisionInstanceQuery = default(HistoricDecisionInstanceQueryDto), List<string> historicDecisionInstanceIds = default(List<string>), DateTimeOffset? absoluteRemovalTime = default(DateTimeOffset?), bool? clearedRemovalTime = default(bool?), bool? calculatedRemovalTime = default(bool?))
        {
            this.Hierarchical = hierarchical;
            this.HistoricDecisionInstanceQuery = historicDecisionInstanceQuery;
            this.HistoricDecisionInstanceIds = historicDecisionInstanceIds;
            this.AbsoluteRemovalTime = absoluteRemovalTime;
            this.ClearedRemovalTime = clearedRemovalTime;
            this.CalculatedRemovalTime = calculatedRemovalTime;
        }

        /// <summary>
        /// Sets the removal time to all historic decision instances in the hierarchy. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.
        /// </summary>
        /// <value>Sets the removal time to all historic decision instances in the hierarchy. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.</value>
        [DataMember(Name = "hierarchical", EmitDefaultValue = true)]
        public bool? Hierarchical { get; set; }

        /// <summary>
        /// Gets or Sets HistoricDecisionInstanceQuery
        /// </summary>
        [DataMember(Name = "historicDecisionInstanceQuery", EmitDefaultValue = false)]
        public HistoricDecisionInstanceQueryDto HistoricDecisionInstanceQuery { get; set; }

        /// <summary>
        /// The ids of the historic decision instances to set the removal time for.
        /// </summary>
        /// <value>The ids of the historic decision instances to set the removal time for.</value>
        [DataMember(Name = "historicDecisionInstanceIds", EmitDefaultValue = true)]
        public List<string> HistoricDecisionInstanceIds { get; set; }

        /// <summary>
        /// The date for which the instances shall be removed. Value may not be &#x60;null&#x60;.  **Note:** Cannot be set in conjunction with &#x60;clearedRemovalTime&#x60; or &#x60;calculatedRemovalTime&#x60;.
        /// </summary>
        /// <value>The date for which the instances shall be removed. Value may not be &#x60;null&#x60;.  **Note:** Cannot be set in conjunction with &#x60;clearedRemovalTime&#x60; or &#x60;calculatedRemovalTime&#x60;.</value>
        [DataMember(Name = "absoluteRemovalTime", EmitDefaultValue = true)]
        public DateTimeOffset? AbsoluteRemovalTime { get; set; }

        /// <summary>
        /// Sets the removal time to &#x60;null&#x60;. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.  **Note:** Cannot be set in conjunction with &#x60;absoluteRemovalTime&#x60; or &#x60;calculatedRemovalTime&#x60;.
        /// </summary>
        /// <value>Sets the removal time to &#x60;null&#x60;. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.  **Note:** Cannot be set in conjunction with &#x60;absoluteRemovalTime&#x60; or &#x60;calculatedRemovalTime&#x60;.</value>
        [DataMember(Name = "clearedRemovalTime", EmitDefaultValue = true)]
        public bool? ClearedRemovalTime { get; set; }

        /// <summary>
        /// The removal time is calculated based on the engine&#39;s configuration settings. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.  **Note:** Cannot be set in conjunction with &#x60;absoluteRemovalTime&#x60; or &#x60;clearedRemovalTime&#x60;.
        /// </summary>
        /// <value>The removal time is calculated based on the engine&#39;s configuration settings. Value may only be &#x60;true&#x60;, as &#x60;false&#x60; is the default behavior.  **Note:** Cannot be set in conjunction with &#x60;absoluteRemovalTime&#x60; or &#x60;clearedRemovalTime&#x60;.</value>
        [DataMember(Name = "calculatedRemovalTime", EmitDefaultValue = true)]
        public bool? CalculatedRemovalTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetRemovalTimeToHistoricDecisionInstancesDto {\n");
            sb.Append("  Hierarchical: ").Append(Hierarchical).Append("\n");
            sb.Append("  HistoricDecisionInstanceQuery: ").Append(HistoricDecisionInstanceQuery).Append("\n");
            sb.Append("  HistoricDecisionInstanceIds: ").Append(HistoricDecisionInstanceIds).Append("\n");
            sb.Append("  AbsoluteRemovalTime: ").Append(AbsoluteRemovalTime).Append("\n");
            sb.Append("  ClearedRemovalTime: ").Append(ClearedRemovalTime).Append("\n");
            sb.Append("  CalculatedRemovalTime: ").Append(CalculatedRemovalTime).Append("\n");
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
            return this.Equals(input as SetRemovalTimeToHistoricDecisionInstancesDto);
        }

        /// <summary>
        /// Returns true if SetRemovalTimeToHistoricDecisionInstancesDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SetRemovalTimeToHistoricDecisionInstancesDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetRemovalTimeToHistoricDecisionInstancesDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Hierarchical == input.Hierarchical ||
                    (this.Hierarchical != null &&
                    this.Hierarchical.Equals(input.Hierarchical))
                ) && 
                (
                    this.HistoricDecisionInstanceQuery == input.HistoricDecisionInstanceQuery ||
                    (this.HistoricDecisionInstanceQuery != null &&
                    this.HistoricDecisionInstanceQuery.Equals(input.HistoricDecisionInstanceQuery))
                ) && 
                (
                    this.HistoricDecisionInstanceIds == input.HistoricDecisionInstanceIds ||
                    this.HistoricDecisionInstanceIds != null &&
                    input.HistoricDecisionInstanceIds != null &&
                    this.HistoricDecisionInstanceIds.SequenceEqual(input.HistoricDecisionInstanceIds)
                ) && 
                (
                    this.AbsoluteRemovalTime == input.AbsoluteRemovalTime ||
                    (this.AbsoluteRemovalTime != null &&
                    this.AbsoluteRemovalTime.Equals(input.AbsoluteRemovalTime))
                ) && 
                (
                    this.ClearedRemovalTime == input.ClearedRemovalTime ||
                    (this.ClearedRemovalTime != null &&
                    this.ClearedRemovalTime.Equals(input.ClearedRemovalTime))
                ) && 
                (
                    this.CalculatedRemovalTime == input.CalculatedRemovalTime ||
                    (this.CalculatedRemovalTime != null &&
                    this.CalculatedRemovalTime.Equals(input.CalculatedRemovalTime))
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
                if (this.Hierarchical != null)
                    hashCode = hashCode * 59 + this.Hierarchical.GetHashCode();
                if (this.HistoricDecisionInstanceQuery != null)
                    hashCode = hashCode * 59 + this.HistoricDecisionInstanceQuery.GetHashCode();
                if (this.HistoricDecisionInstanceIds != null)
                    hashCode = hashCode * 59 + this.HistoricDecisionInstanceIds.GetHashCode();
                if (this.AbsoluteRemovalTime != null)
                    hashCode = hashCode * 59 + this.AbsoluteRemovalTime.GetHashCode();
                if (this.ClearedRemovalTime != null)
                    hashCode = hashCode * 59 + this.ClearedRemovalTime.GetHashCode();
                if (this.CalculatedRemovalTime != null)
                    hashCode = hashCode * 59 + this.CalculatedRemovalTime.GetHashCode();
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
