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
    /// AuthorizationDto
    /// </summary>
    [DataContract(Name = "AuthorizationDto")]
    public partial class AuthorizationDto : IEquatable<AuthorizationDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationDto" /> class.
        /// </summary>
        /// <param name="id">The id of the authorization..</param>
        /// <param name="type">The type of the authorization (0&#x3D;global, 1&#x3D;grant, 2&#x3D;revoke). See the [User Guide](https://docs.camunda.org/manual/latest/user-guide/process-engine/authorization-service.md#authorization-type) for more information about authorization types..</param>
        /// <param name="permissions">An array of Strings holding the permissions provided by this authorization..</param>
        /// <param name="userId">The id of the user this authorization has been created for. The value &#x60;*&#x60; represents a global authorization ranging over all users..</param>
        /// <param name="groupId">The id of the group this authorization has been created for..</param>
        /// <param name="resourceType">An integer representing the resource type. See the [User Guide](https://docs.camunda.org/manual/latest/user-guide/process-engine/authorization-service/#resources) for a list of integer representations of resource types..</param>
        /// <param name="resourceId">The resource Id. The value &#x60;*&#x60; represents an authorization ranging over all instances of a resource..</param>
        /// <param name="removalTime">The removal time indicates the date a historic instance authorization is cleaned up. A removal time can only be assigned to a historic instance authorization. Can be &#x60;null&#x60; when not related to a historic instance resource or when the removal time strategy is end and the root process instance is not finished. Default format &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;..</param>
        /// <param name="rootProcessInstanceId">The process instance id of the root process instance the historic instance authorization is related to. Can be &#x60;null&#x60; if not related to a historic instance resource..</param>
        public AuthorizationDto(string id = default(string), int? type = default(int?), List<string> permissions = default(List<string>), string userId = default(string), string groupId = default(string), int? resourceType = default(int?), string resourceId = default(string), DateTimeOffset? removalTime = default(DateTimeOffset?), string rootProcessInstanceId = default(string))
        {
            this.Id = id;
            this.Type = type;
            this.Permissions = permissions;
            this.UserId = userId;
            this.GroupId = groupId;
            this.ResourceType = resourceType;
            this.ResourceId = resourceId;
            this.RemovalTime = removalTime;
            this.RootProcessInstanceId = rootProcessInstanceId;
        }

        /// <summary>
        /// The id of the authorization.
        /// </summary>
        /// <value>The id of the authorization.</value>
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The type of the authorization (0&#x3D;global, 1&#x3D;grant, 2&#x3D;revoke). See the [User Guide](https://docs.camunda.org/manual/latest/user-guide/process-engine/authorization-service.md#authorization-type) for more information about authorization types.
        /// </summary>
        /// <value>The type of the authorization (0&#x3D;global, 1&#x3D;grant, 2&#x3D;revoke). See the [User Guide](https://docs.camunda.org/manual/latest/user-guide/process-engine/authorization-service.md#authorization-type) for more information about authorization types.</value>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public int? Type { get; set; }

        /// <summary>
        /// An array of Strings holding the permissions provided by this authorization.
        /// </summary>
        /// <value>An array of Strings holding the permissions provided by this authorization.</value>
        [DataMember(Name = "permissions", EmitDefaultValue = true)]
        public List<string> Permissions { get; set; }

        /// <summary>
        /// The id of the user this authorization has been created for. The value &#x60;*&#x60; represents a global authorization ranging over all users.
        /// </summary>
        /// <value>The id of the user this authorization has been created for. The value &#x60;*&#x60; represents a global authorization ranging over all users.</value>
        [DataMember(Name = "userId", EmitDefaultValue = true)]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the group this authorization has been created for.
        /// </summary>
        /// <value>The id of the group this authorization has been created for.</value>
        [DataMember(Name = "groupId", EmitDefaultValue = true)]
        public string GroupId { get; set; }

        /// <summary>
        /// An integer representing the resource type. See the [User Guide](https://docs.camunda.org/manual/latest/user-guide/process-engine/authorization-service/#resources) for a list of integer representations of resource types.
        /// </summary>
        /// <value>An integer representing the resource type. See the [User Guide](https://docs.camunda.org/manual/latest/user-guide/process-engine/authorization-service/#resources) for a list of integer representations of resource types.</value>
        [DataMember(Name = "resourceType", EmitDefaultValue = true)]
        public int? ResourceType { get; set; }

        /// <summary>
        /// The resource Id. The value &#x60;*&#x60; represents an authorization ranging over all instances of a resource.
        /// </summary>
        /// <value>The resource Id. The value &#x60;*&#x60; represents an authorization ranging over all instances of a resource.</value>
        [DataMember(Name = "resourceId", EmitDefaultValue = true)]
        public string ResourceId { get; set; }

        /// <summary>
        /// The removal time indicates the date a historic instance authorization is cleaned up. A removal time can only be assigned to a historic instance authorization. Can be &#x60;null&#x60; when not related to a historic instance resource or when the removal time strategy is end and the root process instance is not finished. Default format &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.
        /// </summary>
        /// <value>The removal time indicates the date a historic instance authorization is cleaned up. A removal time can only be assigned to a historic instance authorization. Can be &#x60;null&#x60; when not related to a historic instance resource or when the removal time strategy is end and the root process instance is not finished. Default format &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.</value>
        [DataMember(Name = "removalTime", EmitDefaultValue = true)]
        public DateTimeOffset? RemovalTime { get; set; }

        /// <summary>
        /// The process instance id of the root process instance the historic instance authorization is related to. Can be &#x60;null&#x60; if not related to a historic instance resource.
        /// </summary>
        /// <value>The process instance id of the root process instance the historic instance authorization is related to. Can be &#x60;null&#x60; if not related to a historic instance resource.</value>
        [DataMember(Name = "rootProcessInstanceId", EmitDefaultValue = true)]
        public string RootProcessInstanceId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AuthorizationDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Permissions: ").Append(Permissions).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  GroupId: ").Append(GroupId).Append("\n");
            sb.Append("  ResourceType: ").Append(ResourceType).Append("\n");
            sb.Append("  ResourceId: ").Append(ResourceId).Append("\n");
            sb.Append("  RemovalTime: ").Append(RemovalTime).Append("\n");
            sb.Append("  RootProcessInstanceId: ").Append(RootProcessInstanceId).Append("\n");
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
            return this.Equals(input as AuthorizationDto);
        }

        /// <summary>
        /// Returns true if AuthorizationDto instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthorizationDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthorizationDto input)
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
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Permissions == input.Permissions ||
                    this.Permissions != null &&
                    input.Permissions != null &&
                    this.Permissions.SequenceEqual(input.Permissions)
                ) && 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) && 
                (
                    this.GroupId == input.GroupId ||
                    (this.GroupId != null &&
                    this.GroupId.Equals(input.GroupId))
                ) && 
                (
                    this.ResourceType == input.ResourceType ||
                    (this.ResourceType != null &&
                    this.ResourceType.Equals(input.ResourceType))
                ) && 
                (
                    this.ResourceId == input.ResourceId ||
                    (this.ResourceId != null &&
                    this.ResourceId.Equals(input.ResourceId))
                ) && 
                (
                    this.RemovalTime == input.RemovalTime ||
                    (this.RemovalTime != null &&
                    this.RemovalTime.Equals(input.RemovalTime))
                ) && 
                (
                    this.RootProcessInstanceId == input.RootProcessInstanceId ||
                    (this.RootProcessInstanceId != null &&
                    this.RootProcessInstanceId.Equals(input.RootProcessInstanceId))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Permissions != null)
                    hashCode = hashCode * 59 + this.Permissions.GetHashCode();
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode();
                if (this.GroupId != null)
                    hashCode = hashCode * 59 + this.GroupId.GetHashCode();
                if (this.ResourceType != null)
                    hashCode = hashCode * 59 + this.ResourceType.GetHashCode();
                if (this.ResourceId != null)
                    hashCode = hashCode * 59 + this.ResourceId.GetHashCode();
                if (this.RemovalTime != null)
                    hashCode = hashCode * 59 + this.RemovalTime.GetHashCode();
                if (this.RootProcessInstanceId != null)
                    hashCode = hashCode * 59 + this.RootProcessInstanceId.GetHashCode();
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
