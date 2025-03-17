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

        [JsonPropertyName("extension_1184f436af73453a821c14a648936912_SpecialDiet")]
        public UserSignUpInfo_Attribute? specialDiet { get; set; }
        [JsonPropertyName("extension_1184f436af73453a821c14a648936912_PromoCode")]
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
