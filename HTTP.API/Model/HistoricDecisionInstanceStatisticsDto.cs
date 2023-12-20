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
    /// HistoricDecisionInstanceStatisticsDto
    /// </summary>
    [DataContract(Name = "HistoricDecisionInstanceStatisticsDto")]
    public partial class HistoricDecisionInstanceStatisticsDto : IEquatable<HistoricDecisionInstanceStatisticsDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoricDecisionInstanceStatisticsDto" /> class.
        /// </summary>
        /// <param name="decisionDefinitionKey">A key of decision definition..</param>
        /// <param name="evaluations">A number of evaluation for decision definition..</param>
        public HistoricDecisionInstanceStatisticsDto(string decisionDefinitionKey = default(string), int? evaluations = default(int?))
        {
            this.DecisionDefinitionKey = decisionDefinitionKey;
            this.Evaluations = evaluations;
        }

        /// <summary>
        /// A key of decision definition.
        /// </summary>
        /// <value>A key of decision definition.</value>
        [DataMember(Name = "decisionDefinitionKey", EmitDefaultValue = true)]
        public string DecisionDefinitionKey { get; set; }

        /// <summary>
        /// A number of evaluation for decision definition.
        /// </summary>
        /// <value>A number of evaluation for decision definition.</value>
        [DataMember(Name = "evaluations", EmitDefaultValue = true)]
        public int? Evaluations { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HistoricDecisionInstanceStatisticsDto {\n");
            sb.Append("  DecisionDefinitionKey: ").Append(DecisionDefinitionKey).Append("\n");
            sb.Append("  Evaluations: ").Append(Evaluations).Append("\n");
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
            return this.Equals(input as HistoricDecisionInstanceStatisticsDto);
        }

        /// <summary>
        /// Returns true if HistoricDecisionInstanceStatisticsDto instances are equal
        /// </summary>
        /// <param name="input">Instance of HistoricDecisionInstanceStatisticsDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HistoricDecisionInstanceStatisticsDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DecisionDefinitionKey == input.DecisionDefinitionKey ||
                    (this.DecisionDefinitionKey != null &&
                    this.DecisionDefinitionKey.Equals(input.DecisionDefinitionKey))
                ) && 
                (
                    this.Evaluations == input.Evaluations ||
                    (this.Evaluations != null &&
                    this.Evaluations.Equals(input.Evaluations))
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
                if (this.DecisionDefinitionKey != null)
                    hashCode = hashCode * 59 + this.DecisionDefinitionKey.GetHashCode();
                if (this.Evaluations != null)
                    hashCode = hashCode * 59 + this.Evaluations.GetHashCode();
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
