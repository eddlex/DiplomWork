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
    /// ProcessDefinitionDto
    /// </summary>
    [DataContract(Name = "ProcessDefinitionDto")]
    public partial class ProcessDefinitionDto : IEquatable<ProcessDefinitionDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessDefinitionDto" /> class.
        /// </summary>
        /// <param name="id">The id of the process definition.</param>
        /// <param name="key">The key of the process definition, i.e., the id of the BPMN 2.0 XML process definition..</param>
        /// <param name="category">The category of the process definition..</param>
        /// <param name="description">The description of the process definition..</param>
        /// <param name="name">The name of the process definition..</param>
        /// <param name="version">The version of the process definition that the engine assigned to it..</param>
        /// <param name="resource">The file name of the process definition..</param>
        /// <param name="deploymentId">The deployment id of the process definition..</param>
        /// <param name="diagram">The file name of the process definition diagram, if it exists..</param>
        /// <param name="suspended">A flag indicating whether the definition is suspended or not..</param>
        /// <param name="tenantId">The tenant id of the process definition..</param>
        /// <param name="versionTag">The version tag of the process definition..</param>
        /// <param name="historyTimeToLive">History time to live value of the process definition. Is used within [History cleanup](https://docs.camunda.org/manual/latest/user-guide/process-engine/history/#history-cleanup)..</param>
        /// <param name="startableInTasklist">A flag indicating whether the process definition is startable in Tasklist or not..</param>
        public ProcessDefinitionDto(string id = default(string), string key = default(string), string category = default(string), string description = default(string), string name = default(string), int? version = default(int?), string resource = default(string), string deploymentId = default(string), string diagram = default(string), bool? suspended = default(bool?), string tenantId = default(string), string versionTag = default(string), int? historyTimeToLive = default(int?), bool? startableInTasklist = default(bool?))
        {
            this.Id = id;
            this.Key = key;
            this.Category = category;
            this.Description = description;
            this.Name = name;
            this.Version = version;
            this.Resource = resource;
            this.DeploymentId = deploymentId;
            this.Diagram = diagram;
            this.Suspended = suspended;
            this.TenantId = tenantId;
            this.VersionTag = versionTag;
            this.HistoryTimeToLive = historyTimeToLive;
            this.StartableInTasklist = startableInTasklist;
        }

        /// <summary>
        /// The id of the process definition
        /// </summary>
        /// <value>The id of the process definition</value>
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The key of the process definition, i.e., the id of the BPMN 2.0 XML process definition.
        /// </summary>
        /// <value>The key of the process definition, i.e., the id of the BPMN 2.0 XML process definition.</value>
        [DataMember(Name = "key", EmitDefaultValue = true)]
        public string Key { get; set; }

        /// <summary>
        /// The category of the process definition.
        /// </summary>
        /// <value>The category of the process definition.</value>
        [DataMember(Name = "category", EmitDefaultValue = true)]
        public string Category { get; set; }

        /// <summary>
        /// The description of the process definition.
        /// </summary>
        /// <value>The description of the process definition.</value>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// The name of the process definition.
        /// </summary>
        /// <value>The name of the process definition.</value>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The version of the process definition that the engine assigned to it.
        /// </summary>
        /// <value>The version of the process definition that the engine assigned to it.</value>
        [DataMember(Name = "version", EmitDefaultValue = true)]
        public int? Version { get; set; }

        /// <summary>
        /// The file name of the process definition.
        /// </summary>
        /// <value>The file name of the process definition.</value>
        [DataMember(Name = "resource", EmitDefaultValue = true)]
        public string Resource { get; set; }

        /// <summary>
        /// The deployment id of the process definition.
        /// </summary>
        /// <value>The deployment id of the process definition.</value>
        [DataMember(Name = "deploymentId", EmitDefaultValue = true)]
        public string DeploymentId { get; set; }

        /// <summary>
        /// The file name of the process definition diagram, if it exists.
        /// </summary>
        /// <value>The file name of the process definition diagram, if it exists.</value>
        [DataMember(Name = "diagram", EmitDefaultValue = true)]
        public string Diagram { get; set; }

        /// <summary>
        /// A flag indicating whether the definition is suspended or not.
        /// </summary>
        /// <value>A flag indicating whether the definition is suspended or not.</value>
        [DataMember(Name = "suspended", EmitDefaultValue = true)]
        public bool? Suspended { get; set; }

        /// <summary>
        /// The tenant id of the process definition.
        /// </summary>
        /// <value>The tenant id of the process definition.</value>
        [DataMember(Name = "tenantId", EmitDefaultValue = true)]
        public string TenantId { get; set; }

        /// <summary>
        /// The version tag of the process definition.
        /// </summary>
        /// <value>The version tag of the process definition.</value>
        [DataMember(Name = "versionTag", EmitDefaultValue = true)]
        public string VersionTag { get; set; }

        /// <summary>
        /// History time to live value of the process definition. Is used within [History cleanup](https://docs.camunda.org/manual/latest/user-guide/process-engine/history/#history-cleanup).
        /// </summary>
        /// <value>History time to live value of the process definition. Is used within [History cleanup](https://docs.camunda.org/manual/latest/user-guide/process-engine/history/#history-cleanup).</value>
        [DataMember(Name = "historyTimeToLive", EmitDefaultValue = true)]
        public int? HistoryTimeToLive { get; set; }

        /// <summary>
        /// A flag indicating whether the process definition is startable in Tasklist or not.
        /// </summary>
        /// <value>A flag indicating whether the process definition is startable in Tasklist or not.</value>
        [DataMember(Name = "startableInTasklist", EmitDefaultValue = true)]
        public bool? StartableInTasklist { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProcessDefinitionDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Resource: ").Append(Resource).Append("\n");
            sb.Append("  DeploymentId: ").Append(DeploymentId).Append("\n");
            sb.Append("  Diagram: ").Append(Diagram).Append("\n");
            sb.Append("  Suspended: ").Append(Suspended).Append("\n");
            sb.Append("  TenantId: ").Append(TenantId).Append("\n");
            sb.Append("  VersionTag: ").Append(VersionTag).Append("\n");
            sb.Append("  HistoryTimeToLive: ").Append(HistoryTimeToLive).Append("\n");
            sb.Append("  StartableInTasklist: ").Append(StartableInTasklist).Append("\n");
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
            return this.Equals(input as ProcessDefinitionDto);
        }

        /// <summary>
        /// Returns true if ProcessDefinitionDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ProcessDefinitionDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProcessDefinitionDto input)
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
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                ) && 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) && 
                (
                    this.Resource == input.Resource ||
                    (this.Resource != null &&
                    this.Resource.Equals(input.Resource))
                ) && 
                (
                    this.DeploymentId == input.DeploymentId ||
                    (this.DeploymentId != null &&
                    this.DeploymentId.Equals(input.DeploymentId))
                ) && 
                (
                    this.Diagram == input.Diagram ||
                    (this.Diagram != null &&
                    this.Diagram.Equals(input.Diagram))
                ) && 
                (
                    this.Suspended == input.Suspended ||
                    (this.Suspended != null &&
                    this.Suspended.Equals(input.Suspended))
                ) && 
                (
                    this.TenantId == input.TenantId ||
                    (this.TenantId != null &&
                    this.TenantId.Equals(input.TenantId))
                ) && 
                (
                    this.VersionTag == input.VersionTag ||
                    (this.VersionTag != null &&
                    this.VersionTag.Equals(input.VersionTag))
                ) && 
                (
                    this.HistoryTimeToLive == input.HistoryTimeToLive ||
                    (this.HistoryTimeToLive != null &&
                    this.HistoryTimeToLive.Equals(input.HistoryTimeToLive))
                ) && 
                (
                    this.StartableInTasklist == input.StartableInTasklist ||
                    (this.StartableInTasklist != null &&
                    this.StartableInTasklist.Equals(input.StartableInTasklist))
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
                if (this.Key != null)
                    hashCode = hashCode * 59 + this.Key.GetHashCode();
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.Resource != null)
                    hashCode = hashCode * 59 + this.Resource.GetHashCode();
                if (this.DeploymentId != null)
                    hashCode = hashCode * 59 + this.DeploymentId.GetHashCode();
                if (this.Diagram != null)
                    hashCode = hashCode * 59 + this.Diagram.GetHashCode();
                if (this.Suspended != null)
                    hashCode = hashCode * 59 + this.Suspended.GetHashCode();
                if (this.TenantId != null)
                    hashCode = hashCode * 59 + this.TenantId.GetHashCode();
                if (this.VersionTag != null)
                    hashCode = hashCode * 59 + this.VersionTag.GetHashCode();
                if (this.HistoryTimeToLive != null)
                    hashCode = hashCode * 59 + this.HistoryTimeToLive.GetHashCode();
                if (this.StartableInTasklist != null)
                    hashCode = hashCode * 59 + this.StartableInTasklist.GetHashCode();
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
            // HistoryTimeToLive (int?) minimum
            if(this.HistoryTimeToLive < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HistoryTimeToLive, must be a value greater than or equal to 0.", new [] { "HistoryTimeToLive" });
            }

            yield break;
        }
    }

}
