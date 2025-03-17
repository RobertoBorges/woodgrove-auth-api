using System.Text.Json.Serialization;

namespace woodgroveapi.Models
{

    public class AttributeCollectionStartResponse
    {
        [JsonPropertyName("data")]
        public AttributeCollectionStartResponse_Data data { get; set; }
        public AttributeCollectionStartResponse()
        {
            data = new AttributeCollectionStartResponse_Data();
            data.odatatype = "microsoft.graph.onAttributeCollectionStartResponseData";

            this.data.actions = new List<AttributeCollectionStartResponse_Action>();
            this.data.actions.Add(new AttributeCollectionStartResponse_Action());
        }
    }

    public class AttributeCollectionStartResponse_Data
    {
        [JsonPropertyName("@odata.type")]
        public string odatatype { get; set; }
        public List<AttributeCollectionStartResponse_Action> actions { get; set; }
    }

    public class AttributeCollectionStartResponse_Action
    {
        [JsonPropertyName("@odata.type")]
        public string odatatype { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AttributeCollectionStartResponse_Inputs inputs { get; set; }
    }

    public class AttributeCollectionStartResponse_Inputs
    {
        /// <summary>
        ///  Country
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string country { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string city { get; set; }
        
        /// <summary>
        /// Promotion code
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("extension_5565d5c40f0b4a0abf27f68ff8bb35eb_PromoCode")]
        public string promoCode { get; set; }
    }

    public class AttributeCollectionStartResponse_ActionTypes
    {
        public const string SetPrefillValues = "microsoft.graph.attributeCollectionStart.setPrefillValues";
        public const string ContinueWithDefaultBehavior = "microsoft.graph.attributeCollectionStart.continueWithDefaultBehavior";
        public const string ShowBlockPage = "microsoft.graph.attributeCollectionStart.showBlockPage";
    }
}