using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace woodgroveapi.Models
{

    public class UserSignUpInfo
    {
        public UserSignUpInfo_Attributes attributes { get; set; }
        public List<UserSignUpInfo_Identities>? identities { get; set; }
    }

    public class UserSignUpInfo_Attributes
    {
        public UserSignUpInfo_Attribute? email { get; set; }
        public UserSignUpInfo_Attribute? city { get; set; }
        public UserSignUpInfo_Attribute? country { get; set; }
        public UserSignUpInfo_Attribute? displayName { get; set; }

        [JsonPropertyName("extension_5565d5c40f0b4a0abf27f68ff8bb35eb_SpecialDiet")]
        public UserSignUpInfo_Attribute? specialDiet { get; set; }
        [JsonPropertyName("extension_5565d5c40f0b4a0abf27f68ff8bb35eb_PromoCode")]
        public UserSignUpInfo_Attribute? promoCode { get; set; }
    }

    public class UserSignUpInfo_Attribute
    {
        public string? value { get; set; }

        [JsonPropertyName("@odata.type")]
        public string odatatype { get; set; }
        public string attributeType { get; set; }
    }

    public class UserSignUpInfo_Identities
    {
        public string signInType { get; set; }
        public string issuer { get; set; }
        public string issuerAssignedId { get; set; }
    }
}
