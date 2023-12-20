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
    /// VariableInstanceDtoAllOf
    /// </summary>
    [DataContract(Name = "VariableInstanceDto_allOf")]
    public partial class VariableInstanceDtoAllOf : IEquatable<VariableInstanceDtoAllOf>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableInstanceDtoAllOf" /> class.
        /// </summary>
        /// <param name="id">The id of the variable instance..</param>
        /// <param name="name">The name of the variable instance..</param>
        /// <param name="processDefinitionId">The id of the process definition that this variable instance belongs to..</param>
        /// <param name="processInstanceId">The id of the process instance that this variable instance belongs to..</param>
        /// <param name="executionId">The id of the execution that this variable instance belongs to..</param>
        /// <param name="caseInstanceId">The id of the case instance that this variable instance belongs to..</param>
        /// <param name="caseExecutionId">The id of the case execution that this variable instance belongs to..</param>
        /// <param name="taskId">The id of the task that this variable instance belongs to..</param>
        /// <param name="batchId">The id of the batch that this variable instance belongs to.&lt;.</param>
        /// <param name="activityInstanceId">The id of the activity instance that this variable instance belongs to..</param>
        /// <param name="tenantId">The id of the tenant that this variable instance belongs to..</param>
        /// <param name="errorMessage">An error message in case a Java Serialized Object could not be de-serialized..</param>
        public VariableInstanceDtoAllOf(string id = default(string), string name = default(string), string processDefinitionId = default(string), string processInstanceId = default(string), string executionId = default(string), string caseInstanceId = default(string), string caseExecutionId = default(string), string taskId = default(string), string batchId = default(string), string activityInstanceId = default(string), string tenantId = default(string), string errorMessage = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.ProcessDefinitionId = processDefinitionId;
            this.ProcessInstanceId = processInstanceId;
            this.ExecutionId = executionId;
            this.CaseInstanceId = caseInstanceId;
            this.CaseExecutionId = caseExecutionId;
            this.TaskId = taskId;
            this.BatchId = batchId;
            this.ActivityInstanceId = activityInstanceId;
            this.TenantId = tenantId;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// The id of the variable instance.
        /// </summary>
        /// <value>The id of the variable instance.</value>
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the variable instance.
        /// </summary>
        /// <value>The name of the variable instance.</value>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The id of the process definition that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the process definition that this variable instance belongs to.</value>
        [DataMember(Name = "processDefinitionId", EmitDefaultValue = true)]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// The id of the process instance that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the process instance that this variable instance belongs to.</value>
        [DataMember(Name = "processInstanceId", EmitDefaultValue = true)]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// The id of the execution that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the execution that this variable instance belongs to.</value>
        [DataMember(Name = "executionId", EmitDefaultValue = true)]
        public string ExecutionId { get; set; }

        /// <summary>
        /// The id of the case instance that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the case instance that this variable instance belongs to.</value>
        [DataMember(Name = "caseInstanceId", EmitDefaultValue = true)]
        public string CaseInstanceId { get; set; }

        /// <summary>
        /// The id of the case execution that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the case execution that this variable instance belongs to.</value>
        [DataMember(Name = "caseExecutionId", EmitDefaultValue = true)]
        public string CaseExecutionId { get; set; }

        /// <summary>
        /// The id of the task that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the task that this variable instance belongs to.</value>
        [DataMember(Name = "taskId", EmitDefaultValue = true)]
        public string TaskId { get; set; }

        /// <summary>
        /// The id of the batch that this variable instance belongs to.&lt;
        /// </summary>
        /// <value>The id of the batch that this variable instance belongs to.&lt;</value>
        [DataMember(Name = "batchId", EmitDefaultValue = true)]
        public string BatchId { get; set; }

        /// <summary>
        /// The id of the activity instance that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the activity instance that this variable instance belongs to.</value>
        [DataMember(Name = "activityInstanceId", EmitDefaultValue = true)]
        public string ActivityInstanceId { get; set; }

        /// <summary>
        /// The id of the tenant that this variable instance belongs to.
        /// </summary>
        /// <value>The id of the tenant that this variable instance belongs to.</value>
        [DataMember(Name = "tenantId", EmitDefaultValue = true)]
        public string TenantId { get; set; }

        /// <summary>
        /// An error message in case a Java Serialized Object could not be de-serialized.
        /// </summary>
        /// <value>An error message in case a Java Serialized Object could not be de-serialized.</value>
        [DataMember(Name = "errorMessage", EmitDefaultValue = true)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VariableInstanceDtoAllOf {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ProcessDefinitionId: ").Append(ProcessDefinitionId).Append("\n");
            sb.Append("  ProcessInstanceId: ").Append(ProcessInstanceId).Append("\n");
            sb.Append("  ExecutionId: ").Append(ExecutionId).Append("\n");
            sb.Append("  CaseInstanceId: ").Append(CaseInstanceId).Append("\n");
            sb.Append("  CaseExecutionId: ").Append(CaseExecutionId).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  BatchId: ").Append(BatchId).Append("\n");
            sb.Append("  ActivityInstanceId: ").Append(ActivityInstanceId).Append("\n");
            sb.Append("  TenantId: ").Append(TenantId).Append("\n");
            sb.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
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
            return this.Equals(input as VariableInstanceDtoAllOf);
        }

        /// <summary>
        /// Returns true if VariableInstanceDtoAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of VariableInstanceDtoAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VariableInstanceDtoAllOf input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ProcessDefinitionId == input.ProcessDefinitionId ||
                    (this.ProcessDefinitionId != null &&
                    this.ProcessDefinitionId.Equals(input.ProcessDefinitionId))
                ) && 
                (
                    this.ProcessInstanceId == input.ProcessInstanceId ||
                    (this.ProcessInstanceId != null &&
                    this.ProcessInstanceId.Equals(input.ProcessInstanceId))
                ) && 
                (
                    this.ExecutionId == input.ExecutionId ||
                    (this.ExecutionId != null &&
                    this.ExecutionId.Equals(input.ExecutionId))
                ) && 
                (
                    this.CaseInstanceId == input.CaseInstanceId ||
                    (this.CaseInstanceId != null &&
                    this.CaseInstanceId.Equals(input.CaseInstanceId))
                ) && 
                (
                    this.CaseExecutionId == input.CaseExecutionId ||
                    (this.CaseExecutionId != null &&
                    this.CaseExecutionId.Equals(input.CaseExecutionId))
                ) && 
                (
                    this.TaskId == input.TaskId ||
                    (this.TaskId != null &&
                    this.TaskId.Equals(input.TaskId))
                ) && 
                (
                    this.BatchId == input.BatchId ||
                    (this.BatchId != null &&
                    this.BatchId.Equals(input.BatchId))
                ) && 
                (
                    this.ActivityInstanceId == input.ActivityInstanceId ||
                    (this.ActivityInstanceId != null &&
                    this.ActivityInstanceId.Equals(input.ActivityInstanceId))
                ) && 
                (
                    this.TenantId == input.TenantId ||
                    (this.TenantId != null &&
                    this.TenantId.Equals(input.TenantId))
                ) && 
                (
                    this.ErrorMessage == input.ErrorMessage ||
                    (this.ErrorMessage != null &&
                    this.ErrorMessage.Equals(input.ErrorMessage))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ProcessDefinitionId != null)
                    hashCode = hashCode * 59 + this.ProcessDefinitionId.GetHashCode();
                if (this.ProcessInstanceId != null)
                    hashCode = hashCode * 59 + this.ProcessInstanceId.GetHashCode();
                if (this.ExecutionId != null)
                    hashCode = hashCode * 59 + this.ExecutionId.GetHashCode();
                if (this.CaseInstanceId != null)
                    hashCode = hashCode * 59 + this.CaseInstanceId.GetHashCode();
                if (this.CaseExecutionId != null)
                    hashCode = hashCode * 59 + this.CaseExecutionId.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.BatchId != null)
                    hashCode = hashCode * 59 + this.BatchId.GetHashCode();
                if (this.ActivityInstanceId != null)
                    hashCode = hashCode * 59 + this.ActivityInstanceId.GetHashCode();
                if (this.TenantId != null)
                    hashCode = hashCode * 59 + this.TenantId.GetHashCode();
                if (this.ErrorMessage != null)
                    hashCode = hashCode * 59 + this.ErrorMessage.GetHashCode();
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
