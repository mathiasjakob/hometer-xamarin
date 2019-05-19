using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace Hometer.Models {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Temperature {
    /// <summary>
    /// Gets or Sets Date
    /// </summary>
    [DataMember(Name="date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date")]
    public DateTime? Date { get; set; }

    /// <summary>
    /// temperature in C°
    /// </summary>
    /// <value>temperature in C°</value>
    [DataMember(Name="value", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "value")]
    public double? Value { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Temperature {\n");
      sb.Append("  Date: ").Append(Date).Append("\n");
      sb.Append("  Value: ").Append(Value).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, (Newtonsoft.Json.Formatting) Formatting.Indented);
    }

}
}
