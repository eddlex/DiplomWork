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
    /// TaskQueryDtoSorting
    /// </summary>
    [DataContract(Name = "TaskQueryDto_sorting")]
    public partial class TaskQueryDtoSorting : IEquatable<TaskQueryDtoSorting>, IValidatableObject
    {
        /// <summary>
        /// Sort the results lexicographically by a given criterion. Must be used in conjunction with the sortOrder parameter.
        /// </summary>
        /// <value>Sort the results lexicographically by a given criterion. Must be used in conjunction with the sortOrder parameter.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortByEnum
        {
            /// <summary>
            /// Enum InstanceId for value: instanceId
            /// </summary>
            [EnumMember(Value = "instanceId")]
            InstanceId = 1,

            /// <summary>
            /// Enum CaseInstanceId for value: caseInstanceId
            /// </summary>
            [EnumMember(Value = "caseInstanceId")]
            CaseInstanceId = 2,

            /// <summary>
            /// Enum DueDate for value: dueDate
            /// </summary>
            [EnumMember(Value = "dueDate")]
            DueDate = 3,

            /// <summary>
            /// Enum ExecutionId for value: executionId
            /// </summary>
            [EnumMember(Value = "executionId")]
            ExecutionId = 4,

            /// <summary>
            /// Enum CaseExecutionId for value: caseExecutionId
            /// </summary>
            [EnumMember(Value = "caseExecutionId")]
            CaseExecutionId = 5,

            /// <summary>
            /// Enum Assignee for value: assignee
            /// </summary>
            [EnumMember(Value = "assignee")]
            Assignee = 6,

            /// <summary>
            /// Enum Created for value: created
            /// </summary>
            [EnumMember(Value = "created")]
            Created = 7,

            /// <summary>
            /// Enum Description for value: description
            /// </summary>
            [EnumMember(Value = "description")]
            Description = 8,

            /// <summary>
            /// Enum Id for value: id
            /// </summary>
            [EnumMember(Value = "id")]
            Id = 9,

            /// <summary>
            /// Enum Name for value: name
            /// </summary>
            [EnumMember(Value = "name")]
            Name = 10,

            /// <summary>
            /// Enum NameCaseInsensitive for value: nameCaseInsensitive
            /// </summary>
            [EnumMember(Value = "nameCaseInsensitive")]
            NameCaseInsensitive = 11,

            /// <summary>
            /// Enum Priority for value: priority
            /// </summary>
            [EnumMember(Value = "priority")]
            Priority = 12,

            /// <summary>
            /// Enum ProcessVariable for value: processVariable
            /// </summary>
            [EnumMember(Value = "processVariable")]
            ProcessVariable = 13,

            /// <summary>
            /// Enum ExecutionVariable for value: executionVariable
            /// </summary>
            [EnumMember(Value = "executionVariable")]
            ExecutionVariable = 14,

            /// <summary>
            /// Enum TaskVariable for value: taskVariable
            /// </summary>
            [EnumMember(Value = "taskVariable")]
            TaskVariable = 15,

            /// <summary>
            /// Enum CaseExecutionVariable for value: caseExecutionVariable
            /// </summary>
            [EnumMember(Value = "caseExecutionVariable")]
            CaseExecutionVariable = 16,

            /// <summary>
            /// Enum CaseInstanceVariable for value: caseInstanceVariable
            /// </summary>
            [EnumMember(Value = "caseInstanceVariable")]
            CaseInstanceVariable = 17

        }


        /// <summary>
        /// Sort the results lexicographically by a given criterion. Must be used in conjunction with the sortOrder parameter.
        /// </summary>
        /// <value>Sort the results lexicographically by a given criterion. Must be used in conjunction with the sortOrder parameter.</value>
        [DataMember(Name = "sortBy", EmitDefaultValue = true)]
        public SortByEnum? SortBy { get; set; }
        /// <summary>
        /// Sort the results in a given order. Values may be &#x60;asc&#x60; for ascending order or &#x60;desc&#x60; for descending order. Must be used in conjunction with the sortBy parameter.
        /// </summary>
        /// <value>Sort the results in a given order. Values may be &#x60;asc&#x60; for ascending order or &#x60;desc&#x60; for descending order. Must be used in conjunction with the sortBy parameter.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortOrderEnum
        {
            /// <summary>
            /// Enum Asc for value: asc
            /// </summary>
            [EnumMember(Value = "asc")]
            Asc = 1,

            /// <summary>
            /// Enum Desc for value: desc
            /// </summary>
            [EnumMember(Value = "desc")]
            Desc = 2

        }


        /// <summary>
        /// Sort the results in a given order. Values may be &#x60;asc&#x60; for ascending order or &#x60;desc&#x60; for descending order. Must be used in conjunction with the sortBy parameter.
        /// </summary>
        /// <value>Sort the results in a given order. Values may be &#x60;asc&#x60; for ascending order or &#x60;desc&#x60; for descending order. Must be used in conjunction with the sortBy parameter.</value>
        [DataMember(Name = "sortOrder", EmitDefaultValue = true)]
        public SortOrderEnum? SortOrder { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskQueryDtoSorting" /> class.
        /// </summary>
        /// <param name="sortBy">Sort the results lexicographically by a given criterion. Must be used in conjunction with the sortOrder parameter..</param>
        /// <param name="sortOrder">Sort the results in a given order. Values may be &#x60;asc&#x60; for ascending order or &#x60;desc&#x60; for descending order. Must be used in conjunction with the sortBy parameter..</param>
        /// <param name="parameters">parameters.</param>
        public TaskQueryDtoSorting(SortByEnum? sortBy = default(SortByEnum?), SortOrderEnum? sortOrder = default(SortOrderEnum?), SortTaskQueryParametersDto parameters = default(SortTaskQueryParametersDto))
        {
            this.SortBy = sortBy;
            this.SortOrder = sortOrder;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Gets or Sets Parameters
        /// </summary>
        [DataMember(Name = "parameters", EmitDefaultValue = false)]
        public SortTaskQueryParametersDto Parameters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaskQueryDtoSorting {\n");
            sb.Append("  SortBy: ").Append(SortBy).Append("\n");
            sb.Append("  SortOrder: ").Append(SortOrder).Append("\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
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
            return this.Equals(input as TaskQueryDtoSorting);
        }

        /// <summary>
        /// Returns true if TaskQueryDtoSorting instances are equal
        /// </summary>
        /// <param name="input">Instance of TaskQueryDtoSorting to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskQueryDtoSorting input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SortBy == input.SortBy ||
                    this.SortBy.Equals(input.SortBy)
                ) && 
                (
                    this.SortOrder == input.SortOrder ||
                    this.SortOrder.Equals(input.SortOrder)
                ) && 
                (
                    this.Parameters == input.Parameters ||
                    (this.Parameters != null &&
                    this.Parameters.Equals(input.Parameters))
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
                hashCode = hashCode * 59 + this.SortBy.GetHashCode();
                hashCode = hashCode * 59 + this.SortOrder.GetHashCode();
                if (this.Parameters != null)
                    hashCode = hashCode * 59 + this.Parameters.GetHashCode();
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
