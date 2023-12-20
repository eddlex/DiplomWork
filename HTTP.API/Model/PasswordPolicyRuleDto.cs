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
    /// Describes a rule of a password policy.
    /// </summary>
    [DataContract(Name = "PasswordPolicyRuleDto")]
    public partial class PasswordPolicyRuleDto : IEquatable<PasswordPolicyRuleDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordPolicyRuleDto" /> class.
        /// </summary>
        /// <param name="placeholder">A placeholder string that contains the name of a password policy rule..</param>
        /// <param name="_parameter">A map that describes the characteristics of a password policy rule, such as the minimum number of digits..</param>
        public PasswordPolicyRuleDto(string placeholder = default(string), Dictionary<string, string> _parameter = default(Dictionary<string, string>))
        {
            this.Placeholder = placeholder;
            this.Parameter = _parameter;
        }

        /// <summary>
        /// A placeholder string that contains the name of a password policy rule.
        /// </summary>
        /// <value>A placeholder string that contains the name of a password policy rule.</value>
        [DataMember(Name = "placeholder", EmitDefaultValue = true)]
        public string Placeholder { get; set; }

        /// <summary>
        /// A map that describes the characteristics of a password policy rule, such as the minimum number of digits.
        /// </summary>
        /// <value>A map that describes the characteristics of a password policy rule, such as the minimum number of digits.</value>
        [DataMember(Name = "parameter", EmitDefaultValue = false)]
        public Dictionary<string, string> Parameter { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PasswordPolicyRuleDto {\n");
            sb.Append("  Placeholder: ").Append(Placeholder).Append("\n");
            sb.Append("  Parameter: ").Append(Parameter).Append("\n");
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
            return this.Equals(input as PasswordPolicyRuleDto);
        }

        /// <summary>
        /// Returns true if PasswordPolicyRuleDto instances are equal
        /// </summary>
        /// <param name="input">Instance of PasswordPolicyRuleDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PasswordPolicyRuleDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Placeholder == input.Placeholder ||
                    (this.Placeholder != null &&
                    this.Placeholder.Equals(input.Placeholder))
                ) && 
                (
                    this.Parameter == input.Parameter ||
                    this.Parameter != null &&
                    input.Parameter != null &&
                    this.Parameter.SequenceEqual(input.Parameter)
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
                if (this.Placeholder != null)
                    hashCode = hashCode * 59 + this.Placeholder.GetHashCode();
                if (this.Parameter != null)
                    hashCode = hashCode * 59 + this.Parameter.GetHashCode();
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
